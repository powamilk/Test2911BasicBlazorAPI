using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class WorkCreateVM
    {
        public int WorkId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public int? Priority { get; set; }
        public string? ImageUrl { get; set; }
    }
}
