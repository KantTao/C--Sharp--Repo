using FluentValidation;
using PaintSystemAPIVersionOne.DTO;

namespace PaintSystemAPIVersionOne.Validator;



public class PaintProductsStockValidator : AbstractValidator<PaintProductStockRequest>
{
    public PaintProductsStockValidator()
    {
        // 整体对象不能为空
        RuleFor(x => x).NotNull().WithMessage("Request body cannot be null");

        // stockQuantity 不能小于0，不能大于10000
        RuleFor(x => x.stockQuantity)
            .InclusiveBetween(0, 10000)
            .WithMessage("stockQuantity must be between 0 and 10000 （Validator）");

        // paintProductId 不能小于0
        RuleFor(x => x.paintProductId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("paintProductId cannot be less than 0  （Validator）");
    }
}