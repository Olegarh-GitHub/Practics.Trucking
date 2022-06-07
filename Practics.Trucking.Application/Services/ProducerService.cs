using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practics.Trucking.Application.Inputs;
using Practics.Trucking.Application.Inputs.Producer;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;

namespace Practics.Trucking.Application.Services
{
    public class ProducerService
    {
        private readonly UserService _userService;
        private readonly IAsyncRepository<Producer> _producerRepository;
        private readonly IAsyncRepository<ProducerInfo> _producerInfoRepository;
        private readonly IMapper _mapper;

        public ProducerService
        (
            UserService userService,
            IAsyncRepository<Producer> producerRepository,
            IAsyncRepository<ProducerInfo> producerInfoRepository,
            IMapper mapper
        )
        {
            _userService = userService;
            _producerRepository = producerRepository;
            _producerInfoRepository = producerInfoRepository;
            _mapper = mapper;
        }

        public async Task<Producer> RegisterProducer(ProducerRegisterInput input)
        {
            User user = await _userService.RegisterUser(input);

            if (user is null)
                return null;

            Producer producer = _mapper.Map<Producer>(input);
            ProducerInfo producerInfo = _mapper.Map<ProducerInfo>(input);

            producer.UserId = user.Id;
            producer.ProducerInfo = producerInfo;

            return await _producerRepository.CreateAsync(producer);
        }

        public IQueryable<Producer> Read()
        {
            return _producerRepository.Read()
                .Include(x => x.User)
                    .ThenInclude(x => x.UserInfo)
                .Include(x => x.Products)
                .Include(x => x.ProducerInfo);
        }

        public bool TryLogin(ProducerTryLoginInput input)
        {
            return _userService.TryLogin(input);
        }
    }
}