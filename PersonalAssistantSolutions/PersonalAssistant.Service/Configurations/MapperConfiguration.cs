namespace PersonalAssistant.Service.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<Contact, ContactModel>().ReverseMap();
        CreateMap<Contact, ContactAudit>().ReverseMap();
        CreateMap<ContactModel, ContactAudit>().ReverseMap();
        CreateMap<ContactType, ContactTypeModel>().ReverseMap();

        CreateMap<InvestmentType, InvestmentTypeModel>().ReverseMap();
        CreateMap<Investment, InvestmentModel>().ReverseMap();
        CreateMap<Investment, InvestmentAudit>().ReverseMap();
        CreateMap<InvestmentModel, InvestmentAudit>().ReverseMap();
        CreateMap<IntervalType, IntervalTypeModel>().ReverseMap();
        CreateMap<Website, WebsiteModel>().ReverseMap();
        CreateMap<Website, WebsiteAudit>().ReverseMap();
        CreateMap<WebsiteModel, WebsiteAudit>().ReverseMap();

        CreateMap<ApiUser, UserModel>().ReverseMap();
        CreateMap<ApiUser, LoginModel>().ReverseMap();
    }
}
