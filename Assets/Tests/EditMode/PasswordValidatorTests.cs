using NUnit.Framework;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests para PasswordValidator
    /// Valida: Reglas de validación de contraseñas
    /// </summary>
    public class PasswordValidatorTests
    {
        private IPasswordValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = PasswordValidatorFactory.CreateStandardValidator();
        }

        [Test]
        public void Validate_WithStrongPassword_ReturnsValid()
        {
            // Act
            var result = validator.Validate("SecurePass123!");

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void Validate_WithShortPassword_ReturnsInvalid()
        {
            // Act
            var result = validator.Validate("Ab1!");

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.ErrorMessage.Contains("8 caracteres"));
        }

        [Test]
        public void Validate_WithoutUppercase_ReturnsInvalid()
        {
            // Act
            var result = validator.Validate("password123!");

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.ErrorMessage.Contains("mayúscula"));
        }

        [Test]
        public void Validate_WithoutLowercase_ReturnsInvalid()
        {
            // Act
            var result = validator.Validate("PASSWORD123!");

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.ErrorMessage.Contains("minúscula"));
        }

        [Test]
        public void Validate_WithoutNumber_ReturnsInvalid()
        {
            // Act
            var result = validator.Validate("PasswordOnly!");

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.ErrorMessage.Contains("número"));
        }

        [Test]
        public void Validate_WithEmptyPassword_ReturnsInvalid()
        {
            // Act
            var result = validator.Validate("");

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TearDown]
        public void TearDown()
        {
            validator = null;
        }
    }
}
