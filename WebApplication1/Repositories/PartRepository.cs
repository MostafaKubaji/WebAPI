using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPartsStore
{
    public class PartRepository : IPartRepository
    {
        private readonly AutoPartsStoreContext _context;

        public PartRepository(AutoPartsStoreContext context)
        {
            _context = context;
        }

        public void AddPart(Part part)
        {
            _context.Parts.Add(part); // إضافة القطعة إلى مجموعة القطع في السياق
            _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
        }

        public void UpdatePart(Part part)
        {
            _context.Parts.Update(part); // تحديث بيانات القطعة في مجموعة القطع في السياق
            _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
        }

        public void DeletePart(int partId)
        {
            var part = _context.Parts.Find(partId); // العثور على القطعة بواسطة معرفها
            if (part != null)
            {
                _context.Parts.Remove(part); // إزالة القطعة من مجموعة القطع في السياق
                _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
            }
        }

        public Part GetPartById(int partId)
        {
            return _context.Parts.Find(partId); // العثور على القطعة بواسطة معرفها
        }

        public List<Part> GetAllParts()
        {
            return _context.Parts.ToList(); // الحصول على قائمة بجميع القطع الموجودة في قاعدة البيانات
        }
    }
}
