using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentApplication.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
