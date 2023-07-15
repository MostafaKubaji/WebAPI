using AutoPartsStore;
using Microsoft.AspNetCore.Mvc; 

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            // استرداد جميع عمليات البيع من قاعدة البيانات
            var sales = _saleRepository.GetAllSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            // استرداد عملية البيع بواسطة معرفها من قاعدة البيانات
            var sale = _saleRepository.GetSaleById(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public IActionResult AddSale(Sale sale)
        {
            // إضافة عملية بيع جديدة إلى قاعدة البيانات
            _saleRepository.AddSale(sale);
            return Ok(sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, Sale updatedSale)
        {
            // تحديث معلومات عملية البيع المحددة في قاعدة البيانات
            var sale = _saleRepository.GetSaleById(id);
            if (sale == null)
                return NotFound();

            sale.Total = updatedSale.Total;
            sale.CarId = updatedSale.CarId;
            sale.CustomerId = updatedSale.CustomerId;

            _saleRepository.UpdateSale(sale);

            return Ok(sale);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            // حذف عملية البيع بواسطة معرفها من قاعدة البيانات
            var sale = _saleRepository.GetSaleById(id);
            if (sale == null)
                return NotFound();

            _saleRepository.DeleteSale(id);

            return Ok();
        }
    }
}
