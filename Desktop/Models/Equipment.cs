using System.Collections.Generic;

namespace Desktop.Models
{
    class Equipment
    {
        public IEnumerable<EquipmentItem> EquipmentItems { get; set; }
        public EquipmentStatus EquipmentStatus { get; set; }
    }

    public enum EquipmentStatus
    {
        NotReceived = 0,
        Received = 1,
        RequestedReturn = 2,
        Returned = 3
    }
}
