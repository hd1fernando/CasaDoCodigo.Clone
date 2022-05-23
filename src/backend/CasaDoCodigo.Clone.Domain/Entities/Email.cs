using System.Text.RegularExpressions;

namespace CasaDoCodigo.Clone.Domain.Entities;

public record Email
{
    public int Id { get; }
    public string Value { get; }
    public AuthorEntity Author { get; }
    public PaymentEntity Payment { get; }
    public Email()
    {

    }
    public Email(string email)
    {
        PreConditions(email);
        Value = email;
    }


    private void PreConditions(string email)
    {
        var match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        if (match.IsMatch(email) == false)
            throw new ArgumentException("Invalid email format.");
    }

    public static implicit operator Email(string email)
        => new Email(email);
}
