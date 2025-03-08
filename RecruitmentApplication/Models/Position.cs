using System.Collections.Generic;

namespace RecruitmentApplication.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
