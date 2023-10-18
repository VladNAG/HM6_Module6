using Moq;
using HM4_M6.Models;
using HM4_M6.Servises;
using HM4_M6.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class CarServisesTests
    {
        private readonly Mock<IDataCars> _dataCarsMock= new Mock<IDataCars>();
        private List<CarViewModel> GetALLTestCarViewModel()
        {
            var carsViewModel = new List<CarViewModel>
            {
                new CarViewModel {Id=1, Name = "Tesla", Model = "Model X",  Price = 45200},
                    new CarViewModel {Id=2, Name = "Lusid", Model = "Luxury",Price = 125000, imgLink = "https://auto.ria.com/uk/auto_lucid_air_35293722.html"},
                    new CarViewModel {Id=3, Name = "BMW", Model = "X5",Price = 98000, imgLink = "https://auto.ria.com/auto_bmw_x5_32789005.html" },
                    new CarViewModel {Id = 4,  Name = "Ford", Model = "Mustang", Price = 30000}
            };
            return carsViewModel;
        }
        private List<CarViewModel> GetALLNullTestCarViewModel()
        {
            List<CarViewModel> carsViewModel = null;
            return carsViewModel;
        }

        [Fact]
        public void Create_CarViewModelIsNull_ShouldNotCallCreateCarViewModel()
        {
            // Arrange
            
            var carServices = new CarServises(_dataCarsMock.Object);
            CarViewModel car = null;

            // Act
            carServices.Create(car);

            // Assert
            _dataCarsMock.Verify(x => x.CreateCarViewModel(It.IsAny<CarViewModel>()), Times.Never);
        }

        [Fact]
        public void Create_CarViewModelIsNotNull_ShouldCallCreateCarViewModel()
        {
            // Arrange
            
            var carServices = new CarServises(_dataCarsMock.Object);
            var car = new CarViewModel { Id = 1 };

            // Act
            carServices.Create(car);

            // Assert
            _dataCarsMock.Verify(x => x.CreateCarViewModel(car), Times.Once);
        }

        [Fact]
        public void Delete_CarViewModelIs0_ShouldCallDeleteCarViewModel()
        {
            // Arrange

            var carServices = new CarServises(_dataCarsMock.Object);
            int car = 0;

            // Act
            carServices.Delete(car);

            // Assert
            _dataCarsMock.Verify(x => x.DeleteCarViewModel(car), Times.Never);
        }
        [Fact]
        public void Delete_CarViewModelIsNotNull_ShouldCallDeleteCarViewModel()
        {
            // Arrange

            var carServices = new CarServises(_dataCarsMock.Object);
            var car = 1;

            // Act
            carServices.Delete(car);

            // Assert
            _dataCarsMock.Verify(x => x.DeleteCarViewModel(car), Times.Once);
        }

        [Fact]
        public void GetAllCarViewModel_IsNotNull_ShouldCallGetAllCarViewModel()
        {
            // Arrange
            _dataCarsMock.Setup(repo => repo.GetAllCarViewModel()).Returns(GetALLTestCarViewModel());
            var carServices = new CarServises(_dataCarsMock.Object);

            // Act
            var result = carServices.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<CarViewModel>>(result);
            Assert.Equal("Tesla", result[0].Name);
        }
        [Fact]
        public void GetAllCarViewModel_IsNull_ShouldCallGetAllCarViewModel()
        {
            // Arrange
            _dataCarsMock.Setup(repo => repo.GetAllCarViewModel()).Returns(GetALLNullTestCarViewModel());
            var carServices = new CarServises(_dataCarsMock.Object);

            // Act
            var result = carServices.GetAll();

            // Assert

            Assert.IsType<List<CarViewModel>>(result);
        }

        [Fact]
        public void UpdateCarViewModel_ShouldCallUpdateCarViewModel()
        {
            // Arrange
            
            var carServices = new CarServises(_dataCarsMock.Object);
            var car = new CarViewModel { Id = 4, Name="3333", Model="44444", Price=343434};
            _dataCarsMock.Setup(x => x.GetCarViewModel(4)).Returns(car);

            // Act
            carServices.Update(car);

            // Assert
            _dataCarsMock.Verify(x => x.UpdateCarViewModel(car), Times.Once);
        }

        [Fact]
        public void UpdateCarViewModel_ShouldCallNullUpdateCarViewModel()
        {
            // Arrange
            var carServices = new CarServises(_dataCarsMock.Object);
            CarViewModel? newcar = null;

            // Act
            carServices.Update(newcar);

            // Assert

            _dataCarsMock.Verify(repo => repo.UpdateCarViewModel(newcar), Times.Never);
        }

    }
}