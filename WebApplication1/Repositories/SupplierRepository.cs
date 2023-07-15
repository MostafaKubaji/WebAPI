using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPartsStore
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AutoPartsStoreContext _context;

        public SupplierRepository(AutoPartsStoreContext context)
        {
            _context = context;
        }

        // إضافة مورد جديد إلى قاعدة البيانات
        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        // تحديث بيانات مورد موجود في قاعدة البيانات
        public void UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        // حذف مورد من قاعدة البيانات
        public void DeleteSupplier(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

        // الحصول على مورد بواسطة معرفه
        public Supplier GetSupplierById(int supplierId)
        {
            return _context.Suppliers.Find(supplierId);
        }

        // الحصول على قائمة بجميع الموردين في قاعدة البيانات
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
