using FluentValidation;
using ClientsAPI.Data.Entities;

namespace ClientsAPI.Validators
{
    public class ClientValidator : AbstractValidator<Cliente>
    {
        public ClientValidator()
        {
            RuleFor(o => o.Nome).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(o => o.DtNascimento).NotNull().NotEmpty();
            RuleFor(o => o.Status).NotNull().NotEmpty();
            RuleFor(o => o.DatInclusao).NotNull();
            RuleFor(o => o.ClienteEnderecos).NotNull();
        }
    }
}
