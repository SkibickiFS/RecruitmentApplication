using System.Collections.Generic;

namespace RecruitmentApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } 
    }
}
