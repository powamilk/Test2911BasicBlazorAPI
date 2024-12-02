using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel.WorkHistory
{
    public class WorkHistoryUpdateVM
    {
        public int HistoryId { get; set; }
        public int? WorkId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ChangedAt { get; set; }
        public string PreviousStatus { get; set; }
        public string CurrentStatus { get; set; }
        public string? Comments { get; set; }
    }
}
