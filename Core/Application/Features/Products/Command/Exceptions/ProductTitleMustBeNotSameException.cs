using Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.Exceptions
{
    public class ProductTitleMustBeNotSameException : BaseExceptions
    {
        public ProductTitleMustBeNotSameException() : base("Product adlari tekrarlana bilmez !") { }
    }
}
