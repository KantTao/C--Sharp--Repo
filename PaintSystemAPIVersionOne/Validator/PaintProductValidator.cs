using FluentValidation;
using PaintSystemAPIVersionOne.DTO;

namespace PaintSystemAPIVersionOne.Validator
{
    public class PaintProductValidator : AbstractValidator<PaintProductRequest>
    {
        public PaintProductValidator()
        {
            
            // 整体对象不能为空
            RuleFor(x => x).NotNull().WithMessage("Request body cannot be null");

            // Name 可为空，但最大长度 50
            RuleFor(x => x.name)
                .MaximumLength(50).WithMessage("Name maximum length is 50 （Validator）");

            // PricePerLitre 必填，必须大于0
            RuleFor(x => x.PricePerLitre)
                .GreaterThan(0).WithMessage("PricePerLitre must be greater than 0");

            // stock 必须 >= 0
            RuleFor(x => x.stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to （Validator）");
            // paintBrandId、paintSeriesId、paintCategoryId 必填，不能为默认值 0
            RuleFor(x => x.paintBrandId)
                .NotEmpty().WithMessage("paintBrandId cannot be empty");

            RuleFor(x => x.paintSeriesId)
                .NotEmpty().WithMessage("paintSeriesId cannot be empty");

            RuleFor(x => x.paintCategoryId)
                .NotEmpty().WithMessage("paintCategoryId cannot be empty");
            
        }
    }
}