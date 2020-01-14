using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Meetings.Application.Services
{
    public class RoomsAppService : IRoomsAppService
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomsAppService(IRoomsRepository roomsAppService)
        {
            _roomsRepository = roomsAppService;
        }

        public List<Rooms> GetAll()
        {
            try
            {
                return _roomsRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
