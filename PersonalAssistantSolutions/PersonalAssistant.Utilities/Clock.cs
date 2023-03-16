namespace PersonalAssistant.Utilities;

public class Clock : IClock
{
    private const string AppFormat = "MM/dd/yyyy";

    public DateTime Now => DateTime.Now;
    public string NowInString => DateTime.Now.ToString(AppFormat);
}
