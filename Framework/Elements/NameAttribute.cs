using System;

namespace Framework.Elements
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class NameAttribute : Attribute
    {
        private readonly string _name;

        public NameAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
