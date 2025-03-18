using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class Client
    {
        public Client()
        {
            Requests = new HashSet<Request>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
