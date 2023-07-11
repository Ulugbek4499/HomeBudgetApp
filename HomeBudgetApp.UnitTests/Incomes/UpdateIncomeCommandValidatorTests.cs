using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using HomeBudgetApp.Application.UseCases.Incomes.Commands.UpdateIncomes;
using HomeBudgetApp.Domain.States;
using Xunit;

namespace HomeBudgetApp.UnitTests.Incomes
{
    public class UpdateIncomeCommandValidatorTests
    {
        [Fact]
        public void UpdateIncomeCommandValidator_IfIdIsNotEmpty_ShouldSuccess()
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Id = Guid.NewGuid(),
                Comment = "Sample Comment",
                Time = DateTime.Now,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfIdIsEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Id = Guid.Empty,
                Comment = "Sample Comment",
                Time = DateTime.Now,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Id);
        }


        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateIncomeCommandValidator_IfCommentIsNullOrEmpty_ShouldThrowValidationException(string comment)
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfCommentLengthIsMoreThan100_ShouldThrowValidationException()
        {
            // Arrange
            string comment = new Faker().Random.String2(101);

            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfCommentLengthIsEqualTo100_ShouldSuccess()
        {
            // Arrange
            string comment = new Faker().Random.String2(100);
            var validator = new UpdateIncomeCommandValidation();

            var updateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = comment,
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(updateIncomeCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfAmountIsNullOrEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 0,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Amount)
                .WithErrorMessage("Amount is required.");
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfTimeIsDefaultDateTime_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = default
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Time)
                .WithErrorMessage("Time is required.");
        }

        [Fact]
        public void UpdateIncomeCommandValidator_IfTimeIsNotDefaultDateTime_ShouldPassValidation()
        {
            // Arrange
            var validator = new UpdateIncomeCommandValidation();

            var UpdateIncomeCommand = new UpdateIncomeCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                IncomeCategory = IncomeCategory.GiftIncome,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateIncomeCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Time);
        }
    }
}
