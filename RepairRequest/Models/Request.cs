using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class Request
    {
        public Request()
        {
            SparePartRequests = new HashSet<SparePartRequest>();
        }

        public int RequestId { get; set; }
        public DateOnly DateAdded { get; set; }
        public DateOnly? DateClosed { get; set; }
        public string Equipment { get; set; } = null!;
        public int ProblemTypeId { get; set; }
        public string? Description { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ProblemType ProblemType { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<SparePartRequest> SparePartRequests { get; set; }
    }
}
