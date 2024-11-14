using Application.Features.Products.Command.Exceptions;
using Application.Features.Products.Command.Rules;
using Application.Interface.AutoMapper;
using Application.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ProductRules productRules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,ProductRules productRules)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.productRules = productRules;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
        await productRules.ProductTitleMustBeNotSame(products, request.Title);
        Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount) ;
        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if(await unitOfWork.SaveAsync() > 0)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new(categoryId, product.Id));
                await unitOfWork.SaveAsync();
            }
        }
        return Unit.Value;
    }
}
