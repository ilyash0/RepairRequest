using System;
using System.Collections.Generic;

namespace RepairRequest.Models
{
    public partial class SparePartType
    {
        public SparePartType()
        {
            SpareParts = new HashSet<SparePart>();
        }

        public int SparePartTypeId { get; set; }
        public string SparePartTypeName { get; set; } = null!;

        public virtual ICollection<SparePart> SpareParts { get; set; }
    }
}
