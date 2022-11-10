using FluentValidation;
using ClientsAPI.Extensions;

namespace ClientsAPI.Filters
{
    public class EndpointFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public EndpointFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var parameter = context.Arguments.SingleOrDefault(p => p.GetType() == typeof(T));
            if (parameter is null) return Results.BadRequest("The parameter is invalid.");

            var result = await _validator.ValidateAsync((T)parameter);
            if (!result.IsValid)
            {
                var errors = result.Errors.GetErrors();
                return Results.Problem(errors);
            }

            return await next(context);
        }
    }
}
