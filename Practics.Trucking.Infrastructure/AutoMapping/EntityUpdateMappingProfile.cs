using AutoMapper;
using Practics.Trucking.Domain.Models;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Infrastructure.AutoMapping
{
    public class EntityUpdateMappingProfile : Profile
    {
        public EntityUpdateMappingProfile()
        {
            CreateMap<Entity, Entity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Order, Order>()
                .IncludeBase<Entity, Entity>();
            
            CreateMap<Product, Product>()
                .IncludeBase<Entity, Entity>();
            
            CreateMap<Specification, Specification>()
                .IncludeBase<Entity, Entity>();
            
            CreateMap<User, User>()
                .IncludeBase<Entity, Entity>();
            
            CreateMap<UserInfo, UserInfo>()
                .IncludeBase<Entity, Entity>();
        }
    }
}