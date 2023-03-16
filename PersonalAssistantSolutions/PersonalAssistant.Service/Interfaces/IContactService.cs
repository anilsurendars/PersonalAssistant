namespace PersonalAssistant.Service.Interfaces
{
    public interface IContactService
    {
        Task<ContactModel> Create(ContactModel contactModel);
        Task<ContactModel> Update(ContactModel contactModel, int contactId);
        bool Delete(int contactId);

        Task<ContactModel> GetContact(int contactId);
        Task<IList<ContactModel>> GetAll();
    }
}
