$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
$nuget = "../Nuget/NuGet.exe"
$xunit = "../packages/xunit.runner.console.2.1.0/tools/xunit.console.exe"
$withTrait = "-trait Category=runThis" #Add required trait for specific tests to run
$withNoTrait = "-notrait Category=doNotRunThis" #Add required trait for specific tests NOT to run
$maxNumberParallelThreads = "-maxthreads 1" #Change thread-number (ie.2) to specify number of parallel threads to run
$buildConfig = "/p:Configuration=Debug"
$warning = "/p:WarningLevel=1"
#Warning
#0:no warnings
#1:severe
#2:lv1 + less severe (ie. hiding class member)
#3:lv2 + less than lv2 (ie. expression always true|false)
#4:default - show everything

$uiTestPath = "../Cin7Test"
$uiTestCsProjPath = @($uiTestPath,"/Cin7Test.csproj") -join ''
$uiTestDll = @($uiTestPath,"/bin/Debug/Cin7Test.dll") -join ''

if (!(Test-Path -Path $uiTestPath))
{
	throw "Build {UI Test} path $uiTestPath does not exist"
}
else
{
	Write-Host "UI Test Path $uiTestPath valid"
	Write-Host "----------------------------------------"
	Write-Host "Restoring nuget packages"
	Write-Host "----------------------------------------"
	& $nuget restore $uiTestCsProjPath 

	#Cleaning any old test data
	Remove-Item -path ..\Cin7Test\TestResults\TestReport-* -Recurse

	Write-Host "----------------------------------------"
	Write-Host "Building" $uiTestPath
	Write-Host "----------------------------------------"
	 
	& $msbuild $uiTestCsProjPath /t:clean,build $warning $buildConfig

	$date = (Get-Date -Format "dd-MMM-yyyy-hh-mm-ss-tt").ToString()
	$uiTestReportPath = @($uiTestPath,"/TestResults/","TestReport-",$date) -join ''	
	New-Item  $uiTestReportPath -ItemType directory 
	
	$commonParams = "-html $uiTestReportPath/$date.html -xml $uiTestReportPath/$date.xml"
	$testAgrs = @($uiTestDll, $commonParams, $maxNumberParallelThreads, $withTrait, $withNoTrait) -join ' '
	$testCmmds = @($xunit, $testAgrs) -join ' '

	$testBlock = [scriptblock]::Create($testCmmds)
	$err = ""

	Write-Host "----------------------------------------"
	Write-Host "Running tests of " $uiTestDll
	Write-Host "----------------------------------------"
	Write-Host "Executing command: "$testCmmds
	Write-Host "----------------------------------------"

	Invoke-Command -ScriptBlock $testBlock -ErrorVariable err -ErrorAction Stop

	if ($err -ne "")
	{
		Write-Host "----------------------------------------"
		Write-Host "Test run errors"
		Write-Host "----------------------------------------"
		Write-Output "Error: $err"
	}

	if (Test-Path $uiTestReportPath)
	{
		Write-Host "----------------------------------------"
		Write-Host "Test output reports"
		Write-Host "----------------------------------------"
		ls $uiTestReportPath
		start-sleep 2
		Invoke-Item $uiTestReportPath/*.html
	}
}