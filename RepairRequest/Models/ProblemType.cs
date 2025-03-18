using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class ProblemType
    {
        public ProblemType()
        {
            Requests = new HashSet<Request>();
        }

        public int ProblemTypeId { get; set; }
        public string ProblemTypeName { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
