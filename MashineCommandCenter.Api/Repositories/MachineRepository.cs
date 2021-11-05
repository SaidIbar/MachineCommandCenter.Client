using MachineCommandCenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MachineCommandCenter.Api.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly AppDbContext _appDbContext;

        public MachineRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Machine> GetAllMachines()
        {
            var allMachines = _appDbContext.Machines.OrderByDescending(s => s.SentDataDateTime);
            return allMachines;
        }

        public Machine GetMachineById(Guid machineId)
        {
            return _appDbContext.Machines.FirstOrDefault(c => c.MachineId == machineId);
        }

        public Machine AddMachine(Machine machine)
        {
            var addedEntity = _appDbContext.Machines.Add(machine);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Machine UpdateMachine(Machine machine)
        {
            var foundMachine = _appDbContext.Machines.FirstOrDefault(e => e.MachineId == machine.MachineId);

            if (foundMachine != null)
            {
                foundMachine.MachineId = machine.MachineId;
                foundMachine.MachineStatus = machine.MachineStatus;
                foundMachine.SentDataDateTime = machine.SentDataDateTime;
                

                _appDbContext.SaveChanges();

                return foundMachine;
            }

            return null;
        }

        public void DeleteMachine(Guid machineId)
        {
            var foundMachine = _appDbContext.Machines.FirstOrDefault(e => e.MachineId == machineId);
            if (foundMachine == null) return;

            _appDbContext.Machines.Remove(foundMachine);
            _appDbContext.SaveChanges();

        }

        

    }
}
