using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Application.Models;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Domain.ValueObjects;
using System;

namespace Schedule.Meetings.Application.Services
{
    public class ScheduleMeetingsAppService : IScheduleMeetingsAppService
    {
        private readonly IScheduleMeetingsRepository _scheduleMeetingsRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleMeetingsAppService(
            IScheduleMeetingsRepository scheduleMeetingsRepository,
            IRoomsRepository roomsRepository,
            IUsersRepository usersRepository,
            IUnitOfWork unitOfWork)
        {
            _scheduleMeetingsRepository = scheduleMeetingsRepository;
            _roomsRepository = roomsRepository;
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        public ResponseModel Schedule(ScheduleMeetingsModel model)
        {
            try
            {
                #region Validations

                var response = ResponseModel.Empty();

                if (!_roomsRepository.Exists(model.RoomId))
                    response.AddError("Sala não encontrada");

                if (!_usersRepository.Exists(model.UserId))
                    response.AddError("Usuário não encontrado");

                var scheduledMeetings = _scheduleMeetingsRepository.GetByDate(model.Date, model.RoomId);

                if (!Meeting.Available(scheduledMeetings, model.Start, model.End))
                    response.AddError($"Não foi possível agendar a reunião no dia {model.Date.ToString("dd/MM/yyyy")} nesse período ({model.Start} - {model.End})");

                if (response.IsNotValid())
                    return response;
                #endregion

                var meeting = ScheduleMeetings.New();

                meeting.UserId = model.UserId;
                meeting.RoomId = model.RoomId;
                meeting.Title = model.Title;
                meeting.MeetingDate = model.Date;
                meeting.MeetingStart = model.Start;
                meeting.MeetingEnd = model.End;

                _scheduleMeetingsRepository.Add(meeting);
                _unitOfWork.Commit();

                return ResponseModel.BuildSuccess();
            }
            catch (Exception ex)
            {
                return ResponseModel.BuildError($"Erro interno: {ex.Message}");
            }
        }
    }
}

