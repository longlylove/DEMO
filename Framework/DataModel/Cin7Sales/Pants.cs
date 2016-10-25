using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataModel.Cin7Sales
{
    public class Pants
    {
        public enum PantsTypeIndex
        {
            BluePants = 0,
            RedPants = 1,
            GreenPants = 2,
            GreyPants = 3
        }

        public class PantsAttr
        {
            public PantsTypeIndex PantsTypeIndex;
            public string ProductName;
            public string CustomerName;
            public int ProductPrice;
            public int DiscountPrice;
            public int TotalPrice;
        }
    }
}
