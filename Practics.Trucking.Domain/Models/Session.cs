using Practics.Trucking.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Domain.Models
{
    public class Session : Entity
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime StartedTime { get; set; } = DateTime.Now;
        public DateTime? LastLoggedTime { get; set; }
        public DateTime? ClosedTime { get; set; }
    }
}
