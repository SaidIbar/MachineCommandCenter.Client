using MachineCommandCenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MachineCommandCenter.Client.Services
{
    public interface IMachineDataService
    {

        Task<IEnumerable<Machine>> GetAllMachines();
        Task<Machine> GetMachineDetails(Guid machineId);
        Task<Machine> AddMachine(Machine machine);
        Task UpdateMachine(Machine machine);
        Task DeleteMachine(Guid machineId);
    }
}
