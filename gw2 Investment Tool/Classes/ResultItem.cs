using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
   public class ResultItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int? PriceEach { get; set; }
        public int? Total { get; set; }
        public int Quantity { get; set; }
        public string PriceFormated { get; set; }
        public string PriceTotalFormated { get; set; }
        public bool RecalculateChecked { get; set; }
       
    }
}
