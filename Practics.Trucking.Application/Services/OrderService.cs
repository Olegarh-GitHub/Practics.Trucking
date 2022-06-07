using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Application.Inputs.Order;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Application.Services
{
    public class OrderService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public OrderService(IAsyncRepository<Order> orderRepository, IMapper mapper, ProductService productService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public bool ApproveOrder(ApproveOrderInput input)
        {
            var orders = Read()
                .Where(x => input.Orders.Contains(x.Id))
                .ToList();

            orders.ForEach(async x =>
            {
                x.Status = Domain.Enums.DeliveryStatus.Delivered;

                await _orderRepository.UpdateAsync(x);
            });

            return true;
        }

        public async Task<Order> OfferOrder(OfferOrderInput input)
        {
            var products = _productService
                .Read()
                .Where(x => input.Products.Contains(x.Id))
                .ToList();

            Order order = _mapper.Map<Order>(input);

            order = await _orderRepository.CreateAsync(order);

            products.ForEach(x =>
            {
                x.OrderId = order.Id;

                _productService.Update(x);
            });

            return order;
        }

        public IQueryable<Order> Read()
        {
            return _orderRepository.Read()
                .Include(x => x.Products)
                    .ThenInclude(x => x.Specifications)
                .Include(x => x.User);
        }
    }
}
