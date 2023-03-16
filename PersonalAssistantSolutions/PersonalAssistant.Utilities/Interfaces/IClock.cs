namespace PersonalAssistant.Utilities.Interfaces;

public interface IClock
{
    DateTime Now { get; }
    string NowInString { get; }
}
