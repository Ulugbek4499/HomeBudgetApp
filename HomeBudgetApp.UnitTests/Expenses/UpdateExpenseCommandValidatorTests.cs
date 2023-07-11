using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using HomeBudgetApp.Application.UseCases.Expenses.Commands.UpdateExpenses;
using HomeBudgetApp.Domain.States;
using Xunit;

namespace HomeBudgetApp.UnitTests.Expenses
{
    public class UpdateExpenseCommandValidatorTests
    {
        [Fact]
        public void UpdateExpenseCommandValidator_IfIdIsNotEmpty_ShouldSuccess()
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Id = Guid.NewGuid(),
                Comment = "Sample Comment",
                Time = DateTime.Now,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfIdIsEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Id = Guid.Empty,
                Comment = "Sample Comment",
                Time = DateTime.Now,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Id);
        }


        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateExpenseCommandValidator_IfCommentIsNullOrEmpty_ShouldThrowValidationException(string comment)
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfCommentLengthIsMoreThan100_ShouldThrowValidationException()
        {
            // Arrange
            string comment = new Faker().Random.String2(101);

            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfCommentLengthIsEqualTo100_ShouldSuccess()
        {
            // Arrange
            string comment = new Faker().Random.String2(100);
            var validator = new UpdateExpenseCommandValidation();

            var updateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(updateExpenseCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfAmountIsNullOrEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 0,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Amount)
                .WithErrorMessage("Amount is required.");
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfTimeIsDefaultDateTime_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = default
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Time)
                .WithErrorMessage("Time is required.");
        }

        [Fact]
        public void UpdateExpenseCommandValidator_IfTimeIsNotDefaultDateTime_ShouldPassValidation()
        {
            // Arrange
            var validator = new UpdateExpenseCommandValidation();

            var UpdateExpenseCommand = new UpdateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(UpdateExpenseCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Time);
        }
    }
}
