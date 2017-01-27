using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCoreContactMgrApi.Models;
using NetCoreContactMgrApi.Repo;
using Bowozer.Latihan.Moja;

namespace NetCoreContactMgrApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private ContactRepo _contactRepo = new ContactRepo();

        // GET api/values
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            var mojacko = new Mojacko()
            {
                Shape = "Kotak",
                Eye = "Besar",
                Colour = "Kuning"
            };

            mojacko.Move();
            return _contactRepo.ContactList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactRepo.ContactList.Where(contact => contact.ID == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Contact value)
        {
            value.ID = _contactRepo.GetMaxID();
            _contactRepo.ContactList.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Contact value)
        {
            Contact contact = _contactRepo.ContactList.Where(ctact => ctact.ID == id).FirstOrDefault();
            if (contact == null)
            {
                throw new InvalidOperationException("Contact is not found");
            }

            int indexLocation = _contactRepo.ContactList.IndexOf(contact);
            _contactRepo.ContactList.Remove(contact);

            value.ID = contact.ID;
            _contactRepo.ContactList.Insert(indexLocation, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Contact contact = _contactRepo.ContactList.Where(ctact => ctact.ID == id).FirstOrDefault();
            if (contact == null)
            {
                throw new InvalidOperationException("Contact is not found");
            }

            _contactRepo.ContactList.Remove(contact);
        }
    }
}
