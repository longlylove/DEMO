using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataModel.Cin7Sales
{
    public class PantsFactory
    {
        public static Pants.PantsAttr GetPants(Pants.PantsTypeIndex pantsTypeIndex)
        {
            switch (pantsTypeIndex)
            {
                 case Pants.PantsTypeIndex.BluePants:
                    return new Pants.PantsAttr
                    {
                        CustomerName = "Mr. Blue Pants",
                        ProductName = "Blue Pants",
                        ProductPrice = 200,
                        DiscountPrice = 20,
                        TotalPrice = 180
                    };

                 case Pants.PantsTypeIndex.RedPants:
                    return new Pants.PantsAttr
                    {
                        CustomerName = "Ms. Red Pants",
                        ProductName = "Red Pants",
                        ProductPrice = 300,
                        DiscountPrice = 30,
                        TotalPrice = 270
                    };

                 case Pants.PantsTypeIndex.GreenPants:
                    return new Pants.PantsAttr
                    {
                        CustomerName = "Mrs. Green Pants",
                        ProductName = "Green Pants",
                        ProductPrice = 800,
                        DiscountPrice = 50,
                        TotalPrice = 750
                    };

                 case Pants.PantsTypeIndex.GreyPants:
                    return new Pants.PantsAttr
                    {
                        CustomerName = "Sir Grey Pants",
                        ProductName = "Grey Pants",
                        ProductPrice = 90,
                        DiscountPrice = 20,
                        TotalPrice = 70
                    };

                default:
                    throw new Exception("Pants attributes are not found!");
            }
        }
    }
}
