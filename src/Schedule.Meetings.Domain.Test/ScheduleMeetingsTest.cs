using Moq;
using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Application.Models;
using Schedule.Meetings.Application.Services;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Helpers;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Schedule.Meetings.Domain.Test
{
    public class ScheduleMeetingsTest
    {
        private readonly IScheduleMeetingsAppService _scheduleMeetingsAppService;
        private readonly Mock<IScheduleMeetingsRepository> _scheduleMeetingsRepository;
        private readonly Mock<IRoomsRepository> _roomsRepository;
        private readonly Mock<IUsersRepository> _usersRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public ScheduleMeetingsTest()
        {
            _scheduleMeetingsRepository = new Mock<IScheduleMeetingsRepository>();
            _roomsRepository = new Mock<IRoomsRepository>();
            _usersRepository = new Mock<IUsersRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _scheduleMeetingsAppService = new ScheduleMeetingsAppService(_scheduleMeetingsRepository.Object, _roomsRepository.Object, _usersRepository.Object, _unitOfWork.Object);

            SetupData();
        }

        [Fact]
        public void Should_NaoAgendar_When_SalaNaoEncontrada()
        {
            var model = new ScheduleMeetingsModel() { RoomId = 0 };

            var response = _scheduleMeetingsAppService.Schedule(model);

            Assert.True(response.IsNotValid());
        }

        [Fact]
        public void Should_NaoAgendar_When_UsuarioNaoEncontrado()
        {
            var model = new ScheduleMeetingsModel() { RoomId = 1, UserId = 0 };

            var response = _scheduleMeetingsAppService.Schedule(model);

            Assert.True(response.IsNotValid());
        }

        [Theory]
        [MemberData(nameof(GetNotValidPeriod))]
        public void Should_NaoAgendar_When_PeriodoNaoDisponivel(TimeSpan start, TimeSpan end)
        {
            var model = new ScheduleMeetingsModel()
            {
                RoomId = 1,
                UserId = 1,
                Date = DateTime.Today,
                Start = start,
                End = end
            };

            var response = _scheduleMeetingsAppService.Schedule(model);

            Assert.True(response.IsNotValid());
        }

        [Theory]
        [MemberData(nameof(GetValidPeriod))]
        public void Should_Agendar_When_PeriodoDisponivel(TimeSpan start, TimeSpan end)
        {
            var model = new ScheduleMeetingsModel()
            {
                RoomId = 1,
                UserId = 1,
                Date = DateTime.Today,
                Start = start,
                End = end
            };

            var response = _scheduleMeetingsAppService.Schedule(model);

            Assert.True(response.Success);
        }

        #region  Auxiliary methods

        private void SetupData()
        {
            var users = new List<Users>() {
               new Users() { UserId = 1, Username = "Teste 1"},
               new Users() { UserId = 2, Username = "Teste 2"}
            };

            var roomns = new List<Rooms>() {
               new Rooms(){RoomId = 1},
               new Rooms(){RoomId = 2}
            };

            var hourCurrent = DateTime.Now.ToTimeSpan();
            var scheduleMeetings = new List<ScheduleMeetings>()
            {
                new ScheduleMeetings()
                {
                    RoomId = 1,
                    UserId = 1,
                    MeetingDate = DateTime.Today,
                    MeetingStart = new TimeSpan(hourCurrent.Hours,10,0),
                    MeetingEnd = new TimeSpan(hourCurrent.Hours,50,0),
                },

                new ScheduleMeetings()
                {
                    RoomId = 1,
                    UserId = 1,
                    MeetingDate = DateTime.Today,
                    MeetingStart = new TimeSpan(hourCurrent.AddMinutes(60).Hours,10,0),
                    MeetingEnd = new TimeSpan(hourCurrent.AddMinutes(120).Hours,50,0),
                }
           };

            _usersRepository.Setup(x => x.Exists(It.IsAny<int>()))
                            .Returns<int>(x => users.Any(y => y.UserId == x));

            _roomsRepository.Setup(x => x.Exists(It.IsAny<int>()))
                            .Returns<int>(x => roomns.Any(y => y.RoomId == x));

            _scheduleMeetingsRepository.Setup(x => x.GetByDate(It.IsAny<DateTime>(), It.IsAny<int>()))
                                       .Returns(scheduleMeetings);
        }
        public static IEnumerable<object[]> GetNotValidPeriod()
        {
            var hourCurrent = DateTime.Now.ToTimeSpan();

            yield return new object[] { DateTimeHelper.NewTime(hourCurrent.Hours, 10), DateTimeHelper.NewTime(hourCurrent.Hours, 20) };
            yield return new object[] { DateTimeHelper.NewTime(hourCurrent.AddMinutes(60).Hours, 20), DateTimeHelper.NewTime(hourCurrent.AddMinutes(60).Hours, 30) };
        }
        public static IEnumerable<object[]> GetValidPeriod()
        {
            var hourCurrent = DateTime.Now.ToTimeSpan();

            yield return new object[] { DateTimeHelper.NewTime(hourCurrent.AddMinutes(240).Hours, 10), DateTimeHelper.NewTime(hourCurrent.AddMinutes(240).Hours, 50) };
            yield return new object[] { DateTimeHelper.NewTime(hourCurrent.AddMinutes(300).Hours, 20), DateTimeHelper.NewTime(hourCurrent.AddMinutes(300).Hours, 30) };
        }

        #endregion
    }
}
