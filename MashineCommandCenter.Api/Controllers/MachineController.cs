using MachineCommandCenter.Api.Repositories;
using MachineCommandCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : Controller
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        [HttpGet]
        public IActionResult GetAllMachines()
        {
            return Ok(_machineRepository.GetAllMachines());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(Guid machineId)
        {
            return Ok(_machineRepository.GetMachineById(machineId));
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Machine machine)
        {
            if (machine == null)
                return BadRequest();

            if (machine.Name == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMachine = _machineRepository.AddMachine(machine);

            return Created("employee", createdMachine);
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Machine machine)
        {
            if (machine == null)
                return BadRequest();

            if (machine.Name == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeToUpdate = _machineRepository.GetMachineById(machine.MachineId);

            if (employeeToUpdate == null)
                return NotFound();

            _machineRepository.UpdateMachine(machine);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid machineId)
        {
            if (machineId != Guid.Empty)
                   return BadRequest();

                var machineToDelete = _machineRepository.GetMachineById(machineId);
            if (machineToDelete == null)
                return NotFound();

            _machineRepository.DeleteMachine(machineId);

            return NoContent();//success
        }
    }
}
