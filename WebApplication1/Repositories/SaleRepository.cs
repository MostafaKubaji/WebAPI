using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPartsStore
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AutoPartsStoreContext _context;

        public SaleRepository(AutoPartsStoreContext context)
        {
            _context = context;
        }

        // إضافة عملية بيع جديدة
        public void AddSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        // تحديث بيانات عملية بيع
        public void UpdateSale(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        // حذف عملية بيع
        public void DeleteSale(int saleId)
        {
            var sale = _context.Sales.Find(saleId);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }

        // الحصول على عملية بيع بواسطة معرفها
        public Sale GetSaleById(int saleId)
        {
            return _context.Sales.Find(saleId);
        }

        // الحصول على قائمة بجميع عمليات البيع
        public List<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }
    }
}
