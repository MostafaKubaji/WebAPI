using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPartsStore
{
    public class CarRepository : ICarRepository
    {
        private readonly AutoPartsStoreContext _context;

        public CarRepository(AutoPartsStoreContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car); // إضافة سيارة جديدة إلى قاعدة البيانات
            _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car); // تحديث بيانات سيارة موجودة في قاعدة البيانات
            _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
        }

        public void DeleteCar(int carId)
        {
            var car = _context.Cars.Find(carId); // البحث عن سيارة باستخدام المعرّف
            if (car != null)
            {
                _context.Cars.Remove(car); // حذف سيارة من قاعدة البيانات
                _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
            }
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId); // العثور على سيارة باستخدام المعرّف
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList(); // الحصول على قائمة بجميع السيارات في قاعدة البيانات
        }
    }
}
