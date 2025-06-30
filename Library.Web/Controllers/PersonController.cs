using Library.DataBase.Models;
using Library.Repository.Repositories;
using Library.ViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly Context _context;
        private readonly IPersonRepository _personRepository;
        public PersonController(Context context, IPersonRepository personRepository)
        {
            _context = context;
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _personRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateVm person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _personRepository.Add(person);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = " Error saving: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "The form is invalid.";
            }

            return View(person);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();

            var person = await _personRepository.FindById(id);
            if (person == null) return NotFound();

            var personVm = new PersonEditVm
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                Address = person.Address,
                phoneNumber = person.phoneNumber,
                Email = person.Email
            };

            return View(personVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PersonEditVm person)
        {
            if (id != person.PersonId) return NotFound();

            if (ModelState.IsValid)
            {

                await _personRepository.Edit(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();

            var person = await _personRepository.FindById(id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person != null)
            {
                _personRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


