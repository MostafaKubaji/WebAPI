using System.Collections.Generic;

namespace AutoPartsStore
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; } 
        public string Address { get; set; } 

        public List<Sale> Sales { get; set; } // قائمة بكل البيعات التي قام بها العميل
    }
}
