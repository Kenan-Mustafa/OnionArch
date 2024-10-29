using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Brand;
using Application.Interface.AutoMapper;
using Application.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(x=>x.Brand));

            var brand = mapper.Map<BrandToListDto, Brand>(new Brand());
            
            var map = mapper.Map<GetAllProductsQueryResponse,Product>(products);

            foreach (var item in map)
                item.Price -= item.Price * item.Discount / 100;
                        
            return map;
        }
    }
}
