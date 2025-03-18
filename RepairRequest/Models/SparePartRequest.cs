using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class SparePartRequest
    {
        public int SparePartRequestId { get; set; }
        public int RequestId { get; set; }
        public int SparePartId { get; set; }
        public decimal Quantity { get; set; }

        public virtual Request Request { get; set; } = null!;
        public virtual SparePart SparePart { get; set; } = null!;
    }
}
