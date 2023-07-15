using AutoPartsStore;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartsController : ControllerBase
    {
        private readonly IPartRepository _partRepository;

        public PartsController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        [HttpGet]
        public IActionResult GetAllParts()
        {
            // استرداد جميع القطع من قاعدة البيانات
            var parts = _partRepository.GetAllParts();
            return Ok(parts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPartById(int id)
        {
            // استرداد قطعة بواسطة معرفها من قاعدة البيانات
            var part = _partRepository.GetPartById(id);
            if (part == null)
                return NotFound();

            return Ok(part);
        }

        [HttpPost]
        public IActionResult AddPart(Part part)
        {
            // إضافة قطعة جديدة إلى قاعدة البيانات
            _partRepository.AddPart(part);
            return Ok(part);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePart(int id, Part updatedPart)
        {
            // تحديث معلومات قطعة محددة في قاعدة البيانات
            var part = _partRepository.GetPartById(id);
            if (part == null)
                return NotFound();

            part.Name = updatedPart.Name;
            part.Quantity = updatedPart.Quantity;
            part.Price = updatedPart.Price;
            part.SupplierId = updatedPart.SupplierId;

            _partRepository.UpdatePart(part);

            return Ok(part);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePart(int id)
        {
            // حذف قطعة بواسطة معرفها من قاعدة البيانات
            var part = _partRepository.GetPartById(id);
            if (part == null)
                return NotFound();

            _partRepository.DeletePart(id);

            return Ok();
        }
    }
}
