using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the UserValidator class.
/// Tests cover validation of all user properties including username, email,
/// password, phone, status, and role requirements.
/// </summary>
public class UserValidatorTests
{
    private readonly UserValidator _validator;

    public UserValidatorTests()
    {
        _validator = new UserValidator();
    }

    /// <summary>
    /// Tests that validation passes when all user properties are valid.
    /// This test verifies that a user with valid:
    /// - Username (3-50 characters)
    /// - Password (meets complexity requirements)
    /// - Email (valid format)
    /// - Phone (valid Brazilian format)
    /// - Status (Active/Suspended)
    /// - Role (Customer/Admin)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid user should pass all validation rules")]
    public void Given_ValidUser_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid username formats.
    /// This test verifies that usernames that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// The username is a required field and must be between 3 and 50 characters.
    /// </summary>
    /// <param name="username">The invalid username to test.</param>
    [Theory(DisplayName = "Invalid username formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidUsername_When_Validated_Then_ShouldHaveError(string username)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Username = username;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    /// <summary>
    /// Tests that validation fails when username exceeds maximum length.
    /// This test verifies that usernames longer than 50 characters fail validation.
    /// The test uses TestDataGenerator to create a username that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Username longer than maximum length should fail validation")]
    public void Given_UsernameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Username = UserTestData.GenerateLongUsername();

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    /// <summary>
    /// Tests that validation fails for invalid email formats.
    /// This test verifies that emails that:
    /// - Don't follow the standard email format (user@domain.com)
    /// - Don't contain @ symbol
    /// - Don't have a valid domain part
    /// fail validation with appropriate error messages.
    /// The test uses TestDataGenerator to create invalid email formats.
    /// </summary>
    [Fact(DisplayName = "Invalid email formats should fail validation")]
    public void Given_InvalidEmail_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Email = UserTestData.GenerateInvalidEmail();

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    /// <summary>
    /// Tests that validation fails for invalid password formats.
    /// This test verifies that passwords that don't meet the complexity requirements:
    /// - Minimum length of 8 characters
    /// - At least one uppercase letter
    /// - At least one lowercase letter
    /// - At least one number
    /// - At least one special character
    /// fail validation with appropriate error messages.
    /// The test uses TestDataGenerator to create passwords that don't meet these requirements.
    /// </summary>
    [Fact(DisplayName = "Invalid password formats should fail validation")]
    public void Given_InvalidPassword_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Password = UserTestData.GenerateInvalidPassword();

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    /// <summary>
    /// Tests that validation fails for invalid phone formats.
    /// This test verifies that phone numbers that:
    /// - Don't follow the Brazilian phone number format (+55XXXXXXXXXXXX)
    /// - Don't have the correct length
    /// - Don't start with the country code (+55)
    /// fail validation with appropriate error messages.
    /// The test uses TestDataGenerator to create invalid phone number formats.
    /// </summary>
    [Fact(DisplayName = "Invalid phone formats should fail validation")]
    public void Given_InvalidPhone_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Phone = UserTestData.GenerateInvalidPhone();

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone);
    }

    /// <summary>
    /// Tests that validation fails when user status is Unknown.
    /// This test verifies that:
    /// - The UserStatus cannot be set to Unknown
    /// - Only Active or Suspended are valid status values
    /// The test ensures that the system maintains valid user states
    /// and prevents undefined or invalid status values.
    /// </summary>
    [Fact(DisplayName = "Unknown status should fail validation")]
    public void Given_UnknownStatus_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Status = UserStatus.Unknown;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Status);
    }

    /// <summary>
    /// Tests that validation fails when user role is None.
    /// This test verifies that:
    /// - The UserRole cannot be set to None
    /// - Only Customer or Admin are valid role values
    /// The test ensures that every user must have a defined role
    /// in the system and prevents undefined or invalid role assignments.
    /// </summary>
    [Fact(DisplayName = "None role should fail validation")]
    public void Given_NoneRole_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Role = UserRole.None;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Role);
    }

    /// <summary>
    /// Testa que a valida��o falha quando o objeto Name � nulo.
    /// O nome do usu�rio � um objeto composto obrigat�rio.
    /// </summary>
    [Fact(DisplayName = "Name nulo deve falhar a valida��o")]
    public void Given_NullName_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Name = null;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name cannot be null.");
    }

    /// <summary>
    /// Testa que a valida��o falha para formatos inv�lidos de Firstname.
    /// Verifica se nomes com menos de 3 caracteres falham na valida��o.
    /// </summary>
    /// <param name="firstname">O primeiro nome inv�lido a ser testado.</param>
    [Theory(DisplayName = "Formatos inv�lidos de Firstname devem falhar a valida��o")]
    [InlineData("ab")] // Menos de 3 caracteres
    public void Given_InvalidFirstname_When_Validated_Then_ShouldHaveError(string firstname)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Name.Firstname = firstname;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name.Firstname);
    }

    /// <summary>
    /// Testa que a valida��o falha quando Firstname excede o comprimento m�ximo.
    /// O primeiro nome n�o pode ter mais de 50 caracteres.
    /// </summary>
    [Fact(DisplayName = "Firstname maior que o m�ximo deve falhar a valida��o")]
    public void Given_FirstnameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Name.Firstname = new string('a', 51);

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name.Firstname)
            .WithErrorMessage("Firstname cannot be longer than 50 characters.");
    }

    /// <summary>
    /// Testa que a valida��o falha para formatos inv�lidos de Lastname.
    /// Verifica se sobrenomes com menos de 3 caracteres falham na valida��o.
    /// </summary>
    /// <param name="lastname">O sobrenome inv�lido a ser testado.</param>
    [Theory(DisplayName = "Formatos inv�lidos de Lastname devem falhar a valida��o")]
    [InlineData("ab")] // Menos de 3 caracteres
    public void Given_InvalidLastname_When_Validated_Then_ShouldHaveError(string lastname)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Name.Lastname = lastname;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name.Lastname);
    }

    /// <summary>
    /// Testa que a valida��o falha quando Lastname excede o comprimento m�ximo.
    /// O sobrenome n�o pode ter mais de 50 caracteres.
    /// </summary>
    [Fact(DisplayName = "Lastname maior que o m�ximo deve falhar a valida��o")]
    public void Given_LastnameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Name.Lastname = new string('a', 51);

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name.Lastname)
            .WithErrorMessage("Lastname cannot be longer than 50 characters.");
    }

    /// <summary>
    /// Testa que a valida��o falha quando o objeto Address � nulo.
    /// O endere�o do usu�rio � um objeto composto obrigat�rio.
    /// </summary>
    [Fact(DisplayName = "Address nulo deve falhar a valida��o")]
    public void Given_NullAddress_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address = null;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address)
            .WithErrorMessage("Address cannot be null.");
    }

    /// <summary>
    /// Testa a valida��o da propriedade Street.
    /// Verifica que a rua n�o pode ser vazia ou menor que 3 caracteres.
    /// </summary>
    [Theory(DisplayName = "Street inv�lido deve falhar a valida��o")]
    [InlineData("")]
    [InlineData("ab")]
    public void Given_InvalidStreet_When_Validated_Then_ShouldHaveError(string street)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.Street = street;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.Street);
    }

    /// <summary>
    /// Testa que a valida��o falha quando Street excede o comprimento m�ximo.
    /// </summary>
    [Fact(DisplayName = "Street maior que o m�ximo deve falhar a valida��o")]
    public void Given_StreetLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.Street = new string('a', 101);

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.Street);
    }

    /// <summary>
    /// Testa a valida��o da propriedade City.
    /// Verifica que a cidade n�o pode ser vazia ou menor que 2 caracteres.
    /// </summary>
    [Theory(DisplayName = "City inv�lido deve falhar a valida��o")]
    [InlineData("")]
    [InlineData("a")]
    public void Given_InvalidCity_When_Validated_Then_ShouldHaveError(string city)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.City = city;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.City);
    }

    /// <summary>
    /// Testa que a valida��o falha quando City excede o comprimento m�ximo.
    /// </summary>
    [Fact(DisplayName = "City maior que o m�ximo deve falhar a valida��o")]
    public void Given_CityLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.City = new string('a', 51);

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.City);
    }

    /// <summary>
    /// Testa a valida��o da propriedade Zipcode.
    /// Verifica que o CEP n�o pode ser vazio e deve corresponder ao formato 00000-000.
    /// </summary>
    [Theory(DisplayName = "Zipcode inv�lido deve falhar a valida��o")]
    [InlineData("")]
    [InlineData("12345")]
    [InlineData("12345-67")]
    [InlineData("123456789")]
    [InlineData("abcde-fgh")]
    public void Given_InvalidZipcode_When_Validated_Then_ShouldHaveError(string zipcode)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.Zipcode = zipcode;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.Zipcode);
    }

    /// <summary>
    /// Testa a valida��o da propriedade Latitude da Geolocaliza��o.
    /// Verifica se a Latitude est� dentro do intervalo num�rico permitido (-90 a 90).
    /// </summary>
    [Theory(DisplayName = "Latitude inv�lida (fora do intervalo) deve falhar a valida��o")]
    [InlineData(-90.1)]  // Abaixo do limite m�nimo
    [InlineData(90.1)]   // Acima do limite m�ximo
    public void Given_InvalidLatitude_When_Validated_Then_ShouldHaveError(decimal latitude)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.Geolocation.Lat = latitude;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.Geolocation.Lat);
    }

    /// <summary>
    /// Testa a valida��o da propriedade Longitude da Geolocaliza��o.
    /// Verifica se a Longitude est� dentro do intervalo num�rico permitido (-180 a 180).
    /// </summary>
    [Theory(DisplayName = "Longitude inv�lida (fora do intervalo) deve falhar a valida��o")]
    [InlineData(-180.1)] // Abaixo do limite m�nimo
    [InlineData(180.1)]  // Acima do limite m�ximo
    public void Given_InvalidLongitude_When_Validated_Then_ShouldHaveError(decimal longitude)
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Address.Geolocation.Long = longitude;

        // Act
        var result = _validator.TestValidate(user);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address.Geolocation.Long);
    }
}
