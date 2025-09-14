using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Entities.Sales
{
    public class SaleHistory
    {
        public int SaleHistoryId { get; set; }
        public int VehicleId { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal SalePrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string Notes { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
