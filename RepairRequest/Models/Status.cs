using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class Status
    {
        public Status()
        {
            Requests = new HashSet<Request>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
