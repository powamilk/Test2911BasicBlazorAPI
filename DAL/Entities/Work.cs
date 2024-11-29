using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Work
    {
        public Work()
        {
            WorkHistories = new HashSet<WorkHistory>();
        }

        public int WorkId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public int? Priority { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<WorkHistory> WorkHistories { get; set; }
    }
}
