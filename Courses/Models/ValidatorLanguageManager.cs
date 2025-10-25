namespace Courses.Models;

public class ValidatorLanguageManager : FluentValidation.Resources.LanguageManager
{
    public ValidatorLanguageManager()
    {
        AddTranslation("en-US", "NotEmptyValidator", "can't be blank");
        AddTranslation("en-US", "LengthValidator", "must be {MinLength}–{MaxLength} characters long");

        AddTranslation("pl-PL", "NotEmptyValidator", "to pole jest wymagane");
        AddTranslation("pl-PL", "LengthValidator", "musi mieć od {MinLength} do {MaxLength} znaków");
    }
}