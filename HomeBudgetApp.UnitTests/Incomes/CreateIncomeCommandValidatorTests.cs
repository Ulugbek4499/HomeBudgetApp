using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using HomeBudgetApp.Application.UseCases.Incomes.Commands.CreateIncomes;
using HomeBudgetApp.Domain.States;
using Xunit;

namespace HomeBudgetApp.UnitTests.Incomes
{
    public class CreateIncomeCommandValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateIncomeCommandValidator_IfCommentIsNullOrEmpty_ShouldThrowValidationException(string comment)
        {
            // Arrange
            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void CreateIncomeCommandValidator_IfCommentLengthIsMoreThan100_ShouldThrowValidationException()
        {
            // Arrange
            string comment = new Faker().Random.String2(101);

            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void CreateIncomeCommandValidator_IfTitleLengthIsEqualTo100_ShouldSuccess()
        {
            // Arrange
            string comment = new Faker().Random.String2(100);
            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void CreateIncomeCommandValidator_IfAmountIsNullOrEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 0,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Amount)
                .WithErrorMessage("Amount is required.");
        }

        [Fact]
        public void CreateIncomeCommandValidator_IfTimeIsDefaultDateTime_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = default
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Time)
                .WithErrorMessage("Time is required.");
        }

        [Fact]
        public void CreateIncomeCommandValidator_IfTimeIsNotDefaultDateTime_ShouldPassValidation()
        {
            // Arrange
            var validator = new CreateIncomeCommandValidation();

            var createIncomeCommand = new CreateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createIncomeCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Time);
        }
    }
}
