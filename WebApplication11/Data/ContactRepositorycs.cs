using Microsoft.EntityFrameworkCore;
using WebApplication11.model;

namespace WebApplication11.Data
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private ContactsAPIDbContext context;

        public ContactRepository(ContactsAPIDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public Contact GetContactByID(Guid id)
        {
            return context.Contacts.Find(id);
        }

        public void InsertContact(Contact contact)
        {
            context.Contacts.Add(contact);
        }

        public void DeleteContact(Guid contactID)
        {
            Contact contact = context.Contacts.Find(contactID);
            context.Contacts.Remove(contact);
        }

        public void UpdateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
