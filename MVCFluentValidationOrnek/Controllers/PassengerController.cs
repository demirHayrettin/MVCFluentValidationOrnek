using Mapster;
using Microsoft.AspNetCore.Mvc;
using MVCFluentValidationOrnek.Entities;
using MVCFluentValidationOrnek.Models;

namespace MVCFluentValidationOrnek.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {

            if (DataBase.Passengers.Count <= 0)
            {
                Passenger passenger = new Passenger()
                {
                    Gender = Enums.Gender.Male,
                    FirstName = "Ahmet",
                    LastName = "Demir",
                    TicketNumber = 101
                    
                };

                Passenger passenger2 = new Passenger()
                {
                    Gender = Enums.Gender.Male,
                    FirstName = "Mehmet",
                    LastName = "Aksoy",
                    TicketNumber = 102
                    
                };
                DataBase.Passengers.Add(passenger);
                DataBase.Passengers.Add(passenger2);
            }
            return View(DataBase.Passengers.Adapt<List<PassengerListVM>>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PassengerCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            DataBase.Passengers.Add(model.Adapt<Passenger>());
            return RedirectToAction("Index");   
        }
        public IActionResult Update(Guid id)
        {
            var updatedPassenger = DataBase.Passengers.FirstOrDefault(x => x.Id == id);
            if(updatedPassenger == null)
            {
                NotFound();
                return RedirectToAction("Index");
            }

            var vm = updatedPassenger.Adapt<PassengerUpdateVM>();

            return View(vm);    
        }

        [HttpPost]
        public IActionResult Update(PassengerUpdateVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedPassenger = DataBase.Passengers.FirstOrDefault(p => p.Id == model.Id);
            model.Adapt(updatedPassenger);

            return RedirectToAction("Index");

        }

        
        public IActionResult Delete(Guid id)
        {
            var deletingPassenger = DataBase.Passengers.FirstOrDefault(x => x.Id == id);
            DataBase.Passengers.Remove(deletingPassenger);
            return RedirectToAction("Index");
        }

       
    }
}
