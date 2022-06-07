using System.Collections.Generic;
using AutoMapper;
using Practics.Trucking.Application.Inputs.Order;
using Practics.Trucking.Application.Inputs.Producer;
using Practics.Trucking.Application.Inputs.Product;
using Practics.Trucking.Application.Inputs.Specification;
using Practics.Trucking.Application.Inputs.User;
using Practics.Trucking.Domain.Models;

namespace Practics.Trucking.Application.AutoMapping
{
    public class InputMappingProfile : Profile
    {
        public InputMappingProfile()
        {
            CreateMap<ProducerRegisterInput, Producer>();
            CreateMap<ProducerRegisterInput, ProducerInfo>();

            CreateMap<UserRegisterInput, User>();
            CreateMap<UserRegisterInput, UserInfo>();
            
            CreateMap<ProductRegisterInput, Product>()
                .ForMember
                (dest => dest.Specifications, 
                    opt => opt.MapFrom(src => src.Specifications)
                );

            CreateMap<List<SpecificationRegisterInput>, List<Specification>>();
            CreateMap<SpecificationRegisterInput, Specification>();

            CreateMap<OfferOrderInput, Order>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}