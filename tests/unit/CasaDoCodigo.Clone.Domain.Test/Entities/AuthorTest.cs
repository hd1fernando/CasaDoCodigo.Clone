using System;
using Bogus;
using CasaDoCodigo.Clone.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CasaDoCodigo.Clone.Domain.Test.Entities;
public class AuthorTest
{
    
    [Theory(DisplayName = "Throw exception when the name is null or empty")]
    [InlineData("")]
    [InlineData(null)]
    public void Test1(string name)
    {
        Action sut = () => new Author(name, "teste@teste.com", "simple description");

        sut.Should()
            .Throw<ArgumentException>(because: "Name can't be null")
            .WithMessage("name is required.");
    }

    [Theory(DisplayName = "Throw exception when the email is null or empty")]
    [InlineData("")]
    [InlineData(null)]
    public void Test2(string email)
    {
        Action sut = () => new Author("test", email, "simple description");

        sut.Should()
            .Throw<ArgumentException>(because: "Email can't be null")
            .WithMessage("email is required.");
    }

    [Theory(DisplayName = "Throw exception when the description is null or empty")]
    [InlineData("")]
    [InlineData(null)]
    public void Test3(string description)
    {
        Action sut = () => new Author("tes", "teste@teste.com", description);

        sut.Should()
            .Throw<ArgumentException>(because: "Description can't be null")
            .WithMessage("description is required.");
    }


    [Fact(DisplayName = "Throw exception when the description has more than 400 characteres")]
    public void Test4()
    {
        var description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet ab";
        Action sut = () => new Author("test", "teste@teste.com", description);

        sut.Should()
            .Throw<ArgumentException>(because: "Description can't have more than 400 characteres")
            .WithMessage("description can't have more than 400 characteres.");
    }

    [Fact(DisplayName = "Throw exception when email is invalid")]
    public void Test5()
    {
        var email = "teste.teste";
        Action sut = () => new Author("tes", email, "simple description");

        sut.Should()
            .Throw<ArgumentException>(because: "Email can't have invalid formation")
            .WithMessage("Invalid email format.");
    }

    [Fact(DisplayName = "Create a valid author when description has 400 characteres")]
    public void Test6()
    {
        var fakePerson = new Faker().Person;

        var name = fakePerson.FullName;
        var email = fakePerson.Email;
        var description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a";

        Action sut = () => new Author(name, email, description);

        sut.Should()
            .NotThrow<ArgumentException>(because: "Author was created in a valid format");
    }
}