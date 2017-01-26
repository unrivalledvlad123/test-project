using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
    public class Item : Save
    {
        public string Name { get; set; }
        public float? TotalKarma { get; set; }
    }
}
