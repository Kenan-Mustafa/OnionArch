using Application.Bases;
using Application.Features.Products.Command.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustBeNotSame(IList<Product> products , string title)
        {
            if (products.Any(x=>x.Title == title))
            {
                throw new ProductTitleMustBeNotSameException();
            }
            return Task.CompletedTask;
        }
    }
}
