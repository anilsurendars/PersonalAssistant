namespace PersonalAssistant.Service.Interfaces
{
    public interface IInvestmentService
    {
        Task<InvestmentModel> Create(InvestmentModel investmentModel);
        Task<InvestmentModel> Update(InvestmentModel investmentModel, int investmentId);
        bool Delete(int investmentId);

        Task<InvestmentModel> GetInvestment(int investmentId);
        Task<IList<InvestmentModel>> GetAll();

    }
}
