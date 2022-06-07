using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Practics.Trucking.Application.Inputs;
using Practics.Trucking.Application.Inputs.User;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Practics.Trucking.Application.Services
{
    public class UserService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<UserInfo> _userInfoRepository;
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public UserService
        (
            IAsyncRepository<User> userRepository,
            IAsyncRepository<UserInfo> userInfoRepository,
            IMapper mapper,
            IAsyncRepository<Order> orderRepository
        )
        {
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<User> RegisterUser(UserRegisterInput input)
        {
            User user = _mapper.Map<User>(input);
            UserInfo userInfo = _mapper.Map<UserInfo>(input);

            User existedUser = GetUserByLogin(user.Login);

            if (existedUser is not null)
                return null;

            user.UserInfo = userInfo;
            user = await _userRepository.CreateAsync(user);

            return user;
        }

        public IQueryable<User> Read()
        {
            return _userRepository.Read()
                .Include(x => x.UserInfo);
        }

        public IQueryable<Order> OrdersByUserId(int userId)
        {
            return _orderRepository.Read().Where(x => x.UserId == userId)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Producer)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Specifications);
        }

        public bool TryLogin(UserTryLoginInput input)
        {
            string login = input.Login;
            string password = input.Password;

            User existedUser = GetUserByLogin(login);

            if (existedUser is null)
                return false;

            return existedUser.Password == password;
        }

        public User GetUserByLogin(string login)
        {
            return _userRepository.Read().FirstOrDefault(user => user.Login == login);
        }
    }
}