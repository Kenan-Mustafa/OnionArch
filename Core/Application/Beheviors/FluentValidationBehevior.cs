using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TReponse> : IPipelineBehavior<TRequest, TReponse> where TRequest : IRequest<TReponse>
    {
        private readonly IEnumerable<IValidator> validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failtures = validator
                .Select(v => v.Validate(context))
                .SelectMany(result=>result.Errors)
                .GroupBy(e=>e.ErrorMessage)
                .Select(x=>x.First())
                .Where(f=>f !=null)
                .ToList();

            if (failtures.Any())
                throw new ValidationException(failtures);

            return next();
        }
    }
}
