using System.ComponentModel.DataAnnotations;

namespace HawesAndCurtis.Application.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}