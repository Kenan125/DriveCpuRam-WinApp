using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Drive : IEntity
    {
        public string DriveName { get; set; }
        public double TotalSpace { get; set; }
        public double AvailableSpace { get; set; }
        public double UsedSpace { get; set; }
        public double UsedSpacePercentage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
