namespace AutoPartsStore
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        void DeleteCar(int carId);
        List<Car> GetAllCars();
        Car GetCarById(int carId);
        void UpdateCar(Car car);
    }
}