using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Dashboard
{
    public class DashboardStatsDTO
    {
        public int OnSale { get; set; }
        public int Sold { get; set; }
        public int OnHold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
