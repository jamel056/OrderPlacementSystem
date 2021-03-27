using FluentValidation;
using O.Core.OrderModule.Requests;

namespace OrderSystem.Validation
{
    public class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .MinimumLength(1)
                .MaximumLength(255)
                .WithMessage("you have to set a valid Email");

            RuleFor(x => x.CustomerName).NotEmpty()
                .MinimumLength(1)
                .MaximumLength(255)
                .WithMessage("you have to set a customer name");

            RuleFor(x => x.AddressFrom).NotEmpty()
                .MinimumLength(1)
                .MaximumLength(500)
                .WithMessage("you have to set an AddressFrom");

            RuleFor(x => x.AddressTo).NotEmpty()
                .MinimumLength(1)
                .MaximumLength(500)
                .WithMessage("you have to set an AddressTo");

            RuleFor(x => x.PhoneNumber).NotEmpty()
                .MinimumLength(1)
                .MaximumLength(500)
                .WithMessage("you have to set an PhoneNumber");

            RuleFor(x => x.AdditionNotes)
                .MinimumLength(1)
                .MaximumLength(4000)
                .WithMessage("you have to write 4000 character maximum for Addition Notes");

            RuleForEach(x => x.OrderServices).ChildRules(orders =>
            {
                orders.RuleFor(x => x).IsInEnum()
                .WithMessage("the value you set is out of the enum");
            });
        }
    }
}
