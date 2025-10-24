namespace Courses.Models;

public class ValidatorLanguageManager : FluentValidation.Resources.LanguageManager
{
    public ValidatorLanguageManager()
    {
        AddTranslation("en", "NotNullValidator", "can't be blank");
        AddTranslation("pl", "NotNullValidator", "to pole jest wymagane");
    }
}