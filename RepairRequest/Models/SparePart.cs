using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairRequest.Models
{
    public partial class SparePart
    {
        public SparePart()
        {
            SparePartRequests = new HashSet<SparePartRequest>();
        }
        public int SparePartId { get; set; }
        public string SparePartName { get; set; } = null!;
        public int SparePartTypeId { get; set; }
        public decimal SparePartCost { get; set; }
        public decimal Quantity { get; set; }

        public virtual SparePartType SparePartType { get; set; } = null!;
        public virtual ICollection<SparePartRequest> SparePartRequests { get; set; }
    }
}
