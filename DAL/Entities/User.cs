using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Works = new HashSet<Work>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Status { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
