using HM4_M6.Interface;
using HM4_M6.Models;
using static System.Net.WebRequestMethods;

namespace HM4_M6.Data

{
    public class DataCars: IDataCars
    {
        public List<CarViewModel> _cars =  new List<CarViewModel>()
                {
                    new CarViewModel {Id=1, Name = "Tesla", Model = "Model X",  Price = 45200},
                    new CarViewModel {Id=2, Name = "Lusid", Model = "Luxury",Price = 125000, imgLink = "https://auto.ria.com/uk/auto_lucid_air_35293722.html"},
                    new CarViewModel {Id=3, Name = "BMW", Model = "X5",Price = 98000, imgLink = "https://auto.ria.com/auto_bmw_x5_32789005.html" },
                    new CarViewModel {Id = 4,  Name = "Ford", Model = "Mustang", Price = 30000}
                };
            
        

        public void CreateCarViewModel(CarViewModel product)
        {
           _cars.Add(product);
        }

        public void DeleteCarViewModel(int id)
        {
            var itemToDelete = _cars.FirstOrDefault(p => p.Id == id);
            if (itemToDelete != null)
            {
                _cars.Remove(itemToDelete);
            }
        }

        public List<CarViewModel> GetAllCarViewModel()
        {
            return _cars;
        }

        public CarViewModel GetCarViewModel(int id)
        {
            return _cars.FirstOrDefault(p => p.Id == id);

        }

        public void UpdateCarViewModel(CarViewModel car)
        {
            var existingCar = _cars.FirstOrDefault(p => p.Id == car.Id);
            if (existingCar != null)
            {
                existingCar.Id = car.Id;
                existingCar.Name = car.Name;
                existingCar.Price = car.Price;
                existingCar.Model = car.Model;

            }
        }
    }
}
