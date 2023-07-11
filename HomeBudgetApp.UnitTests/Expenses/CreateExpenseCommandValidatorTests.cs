using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpenses;
using HomeBudgetApp.Domain.States;
using Xunit;

namespace HomeBudgetApp.UnitTests.Expenses
{
    public class CreateExpenseCommandValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateExpenseCommandValidator_IfCommentIsNullOrEmpty_ShouldThrowValidationException(string comment)
        {
            // Arrange
            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void CreateExpenseCommandValidator_IfCommentLengthIsMoreThan100_ShouldThrowValidationException()
        {
            // Arrange
            string comment = new Faker().Random.String2(101);

            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Comment);
        }

        [Fact]
        public void CreateExpenseCommandValidator_IfTitleLengthIsEqualTo100_ShouldSuccess()
        {
            // Arrange
            string comment = new Faker().Random.String2(100);
            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = comment,
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void CreateExpenseCommandValidator_IfAmountIsNullOrEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 0, 
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Amount)
                .WithErrorMessage("Amount is required.");
        }

        [Fact]
        public void CreateExpenseCommandValidator_IfTimeIsDefaultDateTime_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = default
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Time)
                .WithErrorMessage("Time is required.");
        }

        [Fact]
        public void CreateExpenseCommandValidator_IfTimeIsNotDefaultDateTime_ShouldPassValidation()
        {
            // Arrange
            var validator = new CreateExpenseCommandValidation();

            var createExpenseCommand = new CreateExpenseCommand()
            {
                Comment = "Sample comment",
                Amount = 100,
                ExpenseCategory = ExpenseCategory.Transport,
                Time = DateTime.Now 
            };

            // Act
            var result = validator.TestValidate(createExpenseCommand);

            // Assert
            result.ShouldNotHaveValidationErrorFor(item => item.Time);
        }
    }
}
