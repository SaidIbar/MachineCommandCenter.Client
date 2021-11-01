using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCommandCenter.Shared.Models
{
    public class Machine
    {
        //public int Id { get; set; }
        public Guid MachineId { get; set; }
        public string Name { get; set; }
        public MachineStatus MachineStatus { get; set; }
        public DateTime SentDataDateTime { get; set; }
    }
}
