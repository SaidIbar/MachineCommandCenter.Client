using MachineCommandCenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCommandCenter.Api.Repositories
{
    public interface IMachineRepository
    {
        IEnumerable<Machine> GetAllEmployees();
        Machine GetEmployeeById(Guid machineId);
        Machine AddEmployee(Machine machine);
        Machine UpdateEmployee(Machine machine);
        void DeleteEmployee(Guid machineId);
    }
}
