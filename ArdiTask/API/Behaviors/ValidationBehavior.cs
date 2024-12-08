using API.Exceptions;
using FluentValidation;
using MediatR;

namespace API.Behaviors
{
    public class ValidationBehavior<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse>
        where Trequest : IRequest<Tresponse>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<Trequest>> validators) => _validators = validators;

        public async Task<Tresponse> Handle(Trequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
                return await next();

            var context = new ValidationContext<Trequest>(request);

            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .GroupBy(
                x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
                throw new ValidationAppEcxeption(errorsDictionary);

            return await next();
        }
    }
}
