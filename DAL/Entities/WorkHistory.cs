using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WorkHistory
    {
        public int HistoryId { get; set; }
        public int? WorkId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ChangedAt { get; set; }
        public string PreviousStatus { get; set; } = null!;
        public string CurrentStatus { get; set; } = null!;
        public string? Comments { get; set; }

        public virtual Work? Work { get; set; }
    }
}
