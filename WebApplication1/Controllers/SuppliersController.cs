using AutoPartsStore;
using Microsoft.AspNetCore.Mvc; 

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            // استرداد جميع الموردين من قاعدة البيانات
            var suppliers = _supplierRepository.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            // استرداد مورد بواسطة معرفه من قاعدة البيانات
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            // إضافة مورد جديد إلى قاعدة البيانات
            _supplierRepository.AddSupplier(supplier);
            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, Supplier updatedSupplier)
        {
            // تحديث معلومات مورد محدد في قاعدة البيانات
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
                return NotFound();

            supplier.Name = updatedSupplier.Name;
            supplier.Address = updatedSupplier.Address;

            _supplierRepository.UpdateSupplier(supplier);

            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            // حذف مورد بواسطة معرفه من قاعدة البيانات
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
                return NotFound();

            _supplierRepository.DeleteSupplier(id);

            return Ok();
        }
    }
}
