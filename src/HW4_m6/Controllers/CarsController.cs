using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HM4_M6.Controllers;
using HM4_M6.Interface;
using HM4_M6.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HM4_M6.Filter;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HM4_M6.Controllers
{
    
    public class CaarsController : Controller
    {
        private ICarSevises _iCarSevises;
        public CaarsController(ICarSevises CarSevises)
        {
            _iCarSevises = CarSevises;
        }
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            List<CarViewModel> model = _iCarSevises.GetAll();
            return View(model);
        }

        [HttpPost]
        [Route("Caars/Test")]
        public IActionResult GreateTest(CarViewModel ca)
        {
            if (ModelState.IsValid)
            {
                _iCarSevises.Create(ca);
                List<CarViewModel> model = _iCarSevises.GetAll();
            
                return View("~/Views/Caars/Test.cshtml", model);
            }
            string errorMessages = "";
            // проходим по всем элементам в ModelState
            foreach (var item in ModelState)
            {
                // если для определенного элемента имеются ошибки
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
                    // пробегаемся по всем ошибкам
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            return View(errorMessages);
        }

        [HttpPost]
        [Route("DeleteTest")]
        [CustomExceptionFilter]
        public IActionResult DeleteTest(int id)
        {
            if(id == 1 || id == 2)
            throw new Exception();
            _iCarSevises.Delete(id);
            return RedirectToAction("Test");
        }

        
        [HttpGet]
        [Route("Info")]
        public IActionResult Info(int id)
        {
            
            var model = _iCarSevises.Get(id);
            return View(model);
        }

        [HttpPost]
        [Route("UpdateTest")]
        public IActionResult UpdateTest(CarViewModel ca)
        {

            _iCarSevises.Update(ca);
            List<CarViewModel> model = _iCarSevises.GetAll();
            return View("~/Views/Caars/Test.cshtml", model);
        }

    }
}
