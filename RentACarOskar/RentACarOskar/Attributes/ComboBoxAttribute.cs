using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ComboBoxAttribute : Attribute
    {
        public List<string> vrijednosti = new List<string>();

        public ComboBoxAttribute(params string[] vrijednosti)
        {
            foreach (var item in vrijednosti)
            {
                this.vrijednosti.Add(item);
            }
        }
    }
}
