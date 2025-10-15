using FluentValidation;
using PaintSystemAPIVersionOne.DTO;
namespace PaintSystemAPIVersionOne.Validator;

public class OrderCreateRequestValidator : AbstractValidator<OrderCreateRequest>
{
    public OrderCreateRequestValidator()
    {
        // TotalPrice must be greater than 0 and not exceed 10000
        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("TotalPrice must be greater than 0")
            .LessThanOrEqualTo(10000).WithMessage("TotalPrice cannot exceed 10000");
        
        // OrderStatus must not be null
        RuleFor(x => x.OrderStatus)
            .NotNull().WithMessage("OrderStatus must not be null");

        // OrderReference must not be empty and max length is 50
        RuleFor(x => x.OrderReference)
            .NotEmpty().WithMessage("OrderReference must not be empty")
            .MaximumLength(50).WithMessage("OrderReference maximum length is 50");

        // UserId must be greater than 0
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
    }
}