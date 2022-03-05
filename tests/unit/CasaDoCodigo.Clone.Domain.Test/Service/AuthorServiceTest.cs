using Bogus;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Notifications;
using CasaDoCodigo.Clone.Domain.Repository;
using CasaDoCodigo.Clone.Domain.Service;
using FluentAssertions;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace CasaDoCodigo.Clone.Domain.Test.Service;
public class AuthorServiceTest
{
    Notifier Notifier = new Notifier();
    IAuthorRepository AuthorRepository = Substitute.For<IAuthorRepository>();
    Person FakePerson = new Faker().Person;


    [Fact(DisplayName = "Don't create an author if email already exists.")]
    public async Task Test1()
    {
        Email email = FakePerson.Email;

        var sut = AuthorServiceBuild();

        AuthorRepository.GetAuthorByEmailAsync(email)
            .Returns(AuthorBuild().ToTask());

        await sut.CreateAuthorAsync(AuthorBuild());

        Notifier.HasNotification().Should().BeTrue(because: "can't add an existent email for an author.");
        await AuthorRepository
            .DidNotReceiveWithAnyArgs()
            .CreateAuthorAsync(Arg.Any<AuthorEntity>());
    }



    [Fact(DisplayName = "Create an author")]
    public async Task Test2()
    {
        Email email = FakePerson.Email;

        var sut = AuthorServiceBuild();

        AuthorEntity authorResult = null;
        AuthorRepository.GetAuthorByEmailAsync(email)
            .Returns(authorResult.ToTask());

        var author = AuthorBuild();
        await sut.CreateAuthorAsync(author);

        Notifier.HasNotification().Should().BeFalse(because: "should create a athor");
        await AuthorRepository
            .Received()
            .CreateAuthorAsync(author);
    }


    private AuthorService AuthorServiceBuild()
        => new AuthorService(Notifier, AuthorRepository);

    private AuthorEntity AuthorBuild()
    {
        Email email = FakePerson.Email;
        var name = FakePerson.FullName;
        var description = new Faker().Lorem.Text();

        return new AuthorEntity(name, email.Value, description);
    }

}

public static class ClassHelpers
{

    public static Task<T> ToTask<T>(this T value)
        => Task.FromResult(value);
}
