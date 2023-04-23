namespace PersonalAssistant.Utilities.Extensions;

public static class TypeExtensions
{
    public static int ToInt<TEnum>(this TEnum value) where TEnum : Enum => (int)(object)value;
}
