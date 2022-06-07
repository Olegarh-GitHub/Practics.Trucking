using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Application.Inputs;
using Practics.Trucking.Application.Inputs.Product;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;

namespace Practics.Trucking.Application.Services
{
    public class ProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService
        (
            IAsyncRepository<Product> productRepository, 
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> RegisterProduct(ProductRegisterInput input)
        {
            Product product = _mapper.Map<Product>(input);
            var specifications = input.Specifications.Select(x => _mapper.Map<Specification>(x)).ToList();

            product.Specifications = specifications;

            return await _productRepository.CreateAsync(product);
        }

        public IQueryable<Product> Read()
        {
            return _productRepository.Read()
                .Where(x => !x.OrderId.HasValue)
                .Include(x => x.Specifications)
                .Include(x => x.Producer);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
    }
}