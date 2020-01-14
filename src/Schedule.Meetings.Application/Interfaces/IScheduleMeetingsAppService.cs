using Schedule.Meetings.Application.Models;

namespace Schedule.Meetings.Application.Interfaces
{
    public interface IScheduleMeetingsAppService
    {
        ResponseModel Schedule(ScheduleMeetingsModel model);
    }
}
