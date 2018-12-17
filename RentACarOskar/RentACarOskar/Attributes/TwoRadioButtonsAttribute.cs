using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class TwoRadioButtonsAttribute : Attribute
    {
        public string Value1;
        public string Value2;

        public TwoRadioButtonsAttribute(string value1, string value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}
