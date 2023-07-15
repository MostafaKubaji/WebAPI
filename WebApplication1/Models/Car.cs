
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class Car
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int Year { get; set; } 
        public string Gear { get; set; } 
        public int Km { get; set; } 

        public Sale Sale { get; set; } // علاقة واحد إلى واحد مع جدول البيع
        public List<Part> Part { get; set; } // قائمة تحتوي على القطع المرتبطة بالسيارة
    }
}
