using AutoPartsStore;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarsController (ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public IActionResult GetAllCars()
    {
        // استرداد جميع السيارات من قاعدة البيانات
        var cars = _carRepository.GetAllCars();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        // استرداد سيارة بواسطة معرفها من قاعدة البيانات
        var car = _carRepository.GetCarById(id);
        if (car == null)
            return NotFound();

        return Ok(car);
    }

    [HttpPost]
    public IActionResult AddCar(Car car)
    {
        // إضافة سيارة جديدة إلى قاعدة البيانات
        _carRepository.AddCar(car);
        return Ok(car);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCar(int id, Car updatedCar)
    {
        // تحديث معلومات سيارة محددة في قاعدة البيانات
        var car = _carRepository.GetCarById(id);
        if (car == null)
            return NotFound();

        car.Name = updatedCar.Name;
        car.Year = updatedCar.Year;
        car.Gear = updatedCar.Gear;
        car.Km = updatedCar.Km;

        _carRepository.UpdateCar(car);

        return Ok(car);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {
        // حذف سيارة بواسطة معرفها من قاعدة البيانات
        var car = _carRepository.GetCarById(id);
        if (car == null)
            return NotFound();

        _carRepository.DeleteCar(id);

        return Ok();
    }
}
