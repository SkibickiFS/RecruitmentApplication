using System.Collections.Generic;

namespace RecruitmentApplication.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    }
}
