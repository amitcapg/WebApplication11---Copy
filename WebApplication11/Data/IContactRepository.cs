using WebApplication11.model;

namespace WebApplication11.Data
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactByID(Guid Id);
        void InsertContact(Contact contact);
        void DeleteContact(Guid ID);
        void UpdateContact(Contact contact);
        void Save();
    }
}
