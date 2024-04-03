namespace LegacyApp;

public class UserValidator
{
    private string _name;
    private string _surname;
    private string _email;
    public UserValidator(string name, string surname, string email)
    {
        _name = name;
        _surname = surname;
        _email = email;
    }

    public bool UserValidate()
    {
        if (string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_surname))
        {
            return false;
        }

        if (!_email.Contains("@") && !_email.Contains("."))
        {
            return false;
        }

        return true;
    }
}