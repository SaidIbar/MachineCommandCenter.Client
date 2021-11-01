using MachineCommandCenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCommandCenter.Api.Repositories
{
    public interface IMachineRepository
    {
        IEnumerable<Machine> GetAllMachines();
        Machine GetMachineById(Guid machineId);
        Machine AddMachine(Machine machine);
        Machine UpdateMachine(Machine machine);
        void DeleteMachine(Guid machineId);
    }
}
