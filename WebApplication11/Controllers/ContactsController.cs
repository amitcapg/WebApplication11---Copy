using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.model;

namespace WebApplication11.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactsController : Controller
    {
        

        private IContactRepository contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;

        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contactRepository.GetContacts());

        }

        [HttpPost]

        public IActionResult AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Name = addContactRequest.Name,
                Address = addContactRequest.Address,
                email = addContactRequest.email,
                phone = addContactRequest.phone,



            };
            contactRepository.InsertContact(contact);
            contactRepository.Save();
            return Ok(contact);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            var contact = contactRepository.GetContactByID(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = contactRepository.GetContactByID(id);
            if (contact != null)
            {
                contact.Name = updateContactRequest.Name;
                contact.phone = updateContactRequest.phone;
                contact.Address = updateContactRequest.Address;
                contact.email = updateContactRequest.email;
                contactRepository.UpdateContact(contact);
                contactRepository.Save();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public  IActionResult DeleteContact(Guid id)
        {
            var contact =  contactRepository.GetContactByID(id);
            if (contact != null)
            {
                contactRepository.DeleteContact(id);
                contactRepository.Save();
                return Ok(contact);
            }
            return NotFound();
        }



        





    }
}
