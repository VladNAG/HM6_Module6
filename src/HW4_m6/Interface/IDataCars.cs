using HM4_M6.Models;

namespace HM4_M6.Interface
{
    public interface IDataCars
    {
        
        public List<CarViewModel> GetAllCarViewModel();
        public CarViewModel GetCarViewModel(int id);
        public void CreateCarViewModel(CarViewModel product);
        public void UpdateCarViewModel(CarViewModel product);
        public void DeleteCarViewModel(int id);
    }
}


