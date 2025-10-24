namespace Courses.Models;

public class ValidatorLanguageManager : FluentValidation.Resources.LanguageManager
{
    public ValidatorLanguageManager()
    {
        AddTranslation("en-US", "NotEmptyValidator", "can't be blank");
        AddTranslation("pl-PL", "NotEmptyValidator", "to pole jest wymagane");
    }
}