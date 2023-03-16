namespace PersonalAssistant.Service.Interfaces;

public interface ILookupService
{
    Task<IList<ContactTypeModel>> GetContactTypes();
    Task<IList<IntervalTypeModel>> GetIntervalTypes();
    Task<IList<InvestmentTypeModel>> GetInvestmentTypes();
}
