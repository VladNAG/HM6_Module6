using HM4_M6.Models;

namespace HM4_M6.Interface
{
    public interface ICarSevises
    {
        
        public List<CarViewModel> GetAll();
        public CarViewModel Get(int id);
        public void Create(CarViewModel car);
        public void Update(CarViewModel car);
        public void Delete(int id);
    }
}

