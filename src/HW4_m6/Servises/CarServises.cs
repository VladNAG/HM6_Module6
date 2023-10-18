using HM4_M6.Interface;
using HM4_M6.Models;

namespace HM4_M6.Servises
{
    public class CarServises : ICarSevises
    {
        private readonly IDataCars _dataCars;
        public CarServises(IDataCars dataCars)
        {
            _dataCars = dataCars;
        }

        public void Create(CarViewModel car)
        {
            if (_dataCars.GetCarViewModel(car.Id) != null)
            {
                return;
            }

            _dataCars.CreateCarViewModel(car);
        }

        public void Delete(int id)
        {
            _dataCars.DeleteCarViewModel(id);
        }

        public CarViewModel Get(int id)
        {
          return  _dataCars.GetCarViewModel(id);
        }

        public List<CarViewModel> GetAll()
        {
            return _dataCars.GetAllCarViewModel();
        }

        public void Update(CarViewModel car)
        {
            if (_dataCars.GetCarViewModel(car.Id) == null)
            {
                return;
            }
            _dataCars.UpdateCarViewModel(car);
        }

    }
}
