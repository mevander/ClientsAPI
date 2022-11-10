using FluentValidation;
using ClientsAPI.Data.Entities;

namespace ClientsAPI.Validators
{
    public class ClientAddressValidator : AbstractValidator<ClienteEndereco>
    {
        public ClientAddressValidator()
        {
            RuleFor(o => o.IdCliente).NotNull().NotEmpty();
            RuleFor(o => o.Logradouro).NotNull().NotEmpty();
            RuleFor(o => o.Cep).NotNull().NotEmpty();
            RuleFor(o => o.Uf).NotNull().NotEmpty();
            RuleFor(o => o.Cidade).NotNull().NotEmpty();
            RuleFor(o => o.Bairro).NotNull().NotEmpty();
            RuleFor(o => o.Status).NotNull().NotEmpty();
            RuleFor(o => o.DatInclusao).NotNull();
        }
    }
}
