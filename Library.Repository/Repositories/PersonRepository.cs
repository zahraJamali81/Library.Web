using Microsoft.EntityFrameworkCore;
using Library.DataBase.Models;
using Library.ViewModel.ViewModels;

namespace Library.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> Add(PersonCreateVm personCreateVm)
        {
            PersonModel person = new PersonModel();
            person.Address = personCreateVm.Address;
            person.PhoneNumber = personCreateVm.phoneNumber;
            person.FirstName = personCreateVm.FirstName;
            person.LastName = personCreateVm.LastName;
            person.Email = personCreateVm.Email;
            person.NationalCode = personCreateVm.NationalCode;

            _context.Add(person);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int personId)
        {
            //var person = await _context.Persons.SingleOrDefaultAsync(s => s.PersonId == personId);
            //if (person == null)
            //{
            //    return false;
            //}

            //_context.Persons.Remove(person);
            //await _context.SaveChangesAsync();

            var rows = await _context.Persons.Where(w => w.PersonId == personId).ExecuteDeleteAsync();

            return rows > 0;
        }

        public async Task<bool> Edit(PersonEditVm personEditVm)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(s=> s.PersonId == personEditVm.PersonId);
            if (person == null)
            {
                return false;
            }

            person.Address = personEditVm.Address;
            person.PhoneNumber = personEditVm.phoneNumber;
            person.FirstName = personEditVm.FirstName;
            person.LastName = personEditVm.LastName;
            person.Email = personEditVm.Email;
            person.NationalCode = personEditVm.NationalCode;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PersonVm?> FindById(int personId)
        {
            return await _context.Persons.AsNoTracking()
                .Where(w => w.PersonId == personId)
                .Select(s => new PersonVm
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    PersonId = s.PersonId,
                    phoneNumber = s.PhoneNumber,
                    Address = s.Address,
                    NationalCode = s.NationalCode,
                    Email = s.Email,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<List<PersonVm>> GetAll()
        {
            return await _context.Persons.AsNoTracking()
                .Select(s => new PersonVm
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    PersonId = s.PersonId,
                    phoneNumber = s.PhoneNumber,
                    NationalCode = s.NationalCode
                }).ToListAsync();
        }
    }
}
