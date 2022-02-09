using System.Text.RegularExpressions;

namespace CasaDoCodigo.Clone.Domain.Entities;

public struct Email
{
    public Email(string email)
    {
        PreConditions(email);
    }

    private void PreConditions(string email)
    {
        var match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        if (match.IsMatch(email) == false)
            throw new Exception("Invalid email format");
    }

    public static implicit operator Email(string email)
        => new Email(email);
}
