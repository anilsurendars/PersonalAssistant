namespace PersonalAssistant.Service.Services
{
    public class ContactService : IContactService
    {
        public Task<ContactModel> Create(ContactModel contactModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ContactModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContactModel> GetContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactModel> Update(ContactModel contactModel, int contactId)
        {
            throw new NotImplementedException();
        }
    }
}
