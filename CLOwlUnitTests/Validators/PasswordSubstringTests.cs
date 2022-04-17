using ClowlWebApp.Models;
using ClowlWebApp.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLOwlUnitTests.Validators
{
    [TestFixture]
    public class PasswordSubstringTests
    {
        public RegistrationModel registerObject = new();
        public PasswordSubstring passwordSubstring = new();

        [SetUp]
        public void SetUp()
        {

            this.registerObject.Password = "piotr123";
            this.registerObject.FirstName = "test";
            this.registerObject.LastName = "testowo";

        }

        [Test]
        public void TestGetErrorMessage()
        {
            // Act
            string result = this.passwordSubstring.GetErrorMessage();

            // Assert
            Assert.AreEqual(result, $"Password cannot contain your name or surname.");
        }

        [Test]
        public void TestValidPassword()
        {
            // Arrange
            ValidationContext validationContext = new(registerObject) { MemberName = "Password" };
            List<ValidationResult> results = new();

            // Act
            bool result = Validator.TryValidateProperty(this.registerObject.Password, validationContext, results);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestInvalidPassword()
        {
            // Arrange
            registerObject.LastName = "Piotr";
            ValidationContext validationContext = new(registerObject) { MemberName = "Password" };
            List<ValidationResult> results = new();

            // Act
            bool result = Validator.TryValidateProperty(registerObject.Password, validationContext, results);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
