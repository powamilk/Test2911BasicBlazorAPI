using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ViewModel
{
    public class WorkVM
    {
        public int WorkId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public int? Priority { get; set; }
    }
}
