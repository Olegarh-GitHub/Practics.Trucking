using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Practics.Trucking.Application.Services;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Services
{
    public class SessionService
    {
        private readonly IAsyncRepository<Session> _sessionRepository;
        private readonly UserService _userService;
        private readonly ProducerService _producerService;
        private int _userId;

        public SessionService
        (
            IAsyncRepository<Session> sessionRepository,
            UserService userService,
            ProducerService producerService
        )
        {
            _sessionRepository = sessionRepository;
            _userService = userService;
            _producerService = producerService;
        }

        private async Task<Session> LoadFromLocalCache()
        {
            using StreamReader reader = new StreamReader("session.json");

            string session = await reader.ReadToEndAsync();

            Session convertedSession = JsonConvert.DeserializeObject<Session>(session);

            _userId = convertedSession.UserId;

            return convertedSession;
        }

        private async Task SaveLocalSessionToCache(int id, int userId)
        {
            using StreamWriter writer = new StreamWriter("session.json", append: false);

            string json = $"{{ \"Id\": {id}, \"UserId\" : {userId}}}";

            _userId = userId;

            await writer.WriteAsync(json);
        }

        public async Task DropCurrentSession()
        {
            Session session = await LoadFromLocalCache();
           
            await _sessionRepository.DeleteAsync(session);

            await SaveLocalSessionToCache(0, 0);
        }

        public bool IsCurrentUserAProducer()
        {
            return _producerService.Read().FirstOrDefault(x => x.UserId == _userId) != null;
        }

        public async Task<bool> IsLocalSessionUserAuthorized()
        {
            Session session = await LoadFromLocalCache();

            if (session is null)
                return false;

            if (session.UserId == 0)
                return false;

            session = _sessionRepository
                .Read()
                .FirstOrDefault(x => x.Id == session.Id);

            session.LastLoggedTime = DateTime.Now;

            await _sessionRepository.UpdateAsync(session);

            return true;
        }

        public User GetCurrentUser()
        {
            return _userService.Read().FirstOrDefault(x => x.Id == _userId);
        }

        public async Task SaveLocalSession(int userId)
        {
            Session session = new Session()
            {
                UserId = userId
            };

            session = await _sessionRepository.CreateAsync(session);

            await SaveLocalSessionToCache(session.Id, userId);
        }
    }
}
