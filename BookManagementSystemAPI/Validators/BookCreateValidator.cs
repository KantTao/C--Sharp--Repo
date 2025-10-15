using BookManagementSystemAPI.Models;
using FluentValidation;

namespace BookManagementSystemAPI.Validators;

public class BookCreateValidator : AbstractValidator<BookCreateRequest> //继承一个抽象类 <T> 加入要校验的对象
{
    public BookCreateValidator()
    {
        RuleFor(b => b.Name)
            .NotNull()
            .WithMessage("Name cant be null") //如果验证失败 返回消息
            .NotEmpty()
            .WithMessage("Name can not be empty");

        RuleFor(b => b.Description).MaximumLength(20);
    }
}