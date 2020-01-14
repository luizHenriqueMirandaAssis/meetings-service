using System.Collections.Generic;
using System.Linq;

namespace Schedule.Meetings.Application.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public static ResponseModel Empty() => new ResponseModel();
        public static ResponseModel BuildSuccess()
        {
            return new ResponseModel()
            {
                Success = true
            };
        }
        public static ResponseModel BuildError(string msg)
        {
            return new ResponseModel()
            {
                Success = false,
                Errors = new List<string> { msg }
            };
        }
        public ResponseModel AddError(string msg)
        {
            Errors.Add(msg);
            return this;
        }
        public bool IsNotValid() => this.Errors.Any();
    }
}
