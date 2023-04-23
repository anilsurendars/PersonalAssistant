namespace PersonalAssistant.Models.PresentationModels.Validators;

public class WebsiteModelValidator : AbstractValidator<WebsiteModel>
{
    public WebsiteModelValidator()
    {
        RuleFor(x => x).NotEmpty();
        RuleFor(x => x.WebsiteName).NotEmpty();
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
