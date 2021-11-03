using MachineCommandCenter.Client.Services;
using MachineCommandCenter.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCommandCenter.Client.Pages
{
    public partial class MachineOverview
    {
        [Inject]
        public IMachineDataService MachineDataService { get; set; }

        private string IdString;
        public Machine Machine { get; set; } = new Machine();
        [Parameter]
        public string MachineId { get; set; }
        public IEnumerable<Machine> Machines { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Guid.TryParse(MachineId, out var machineId);
            Machines = (await MachineDataService.GetAllMachines()).ToList();
           // await UpdateStatusAsync();
        }

        
               
        protected override async Task OnParametersSetAsync()
        {
            IdString = MachineId?.ToString() ?? "";
            //Id = null;
            if(IdString != "")
            {
                var machineGuidID = Guid.Parse(MachineId);
                Machine = await MachineDataService.GetMachineDetails(machineGuidID);
                 if(Machine.MachineStatus == 0)
                    {
                    Machine.MachineStatus = (MachineStatus)1;
                 }
                 else
                 {
                     Machine.MachineStatus = 0;
                 }
                Machine.SentDataDateTime = DateTime.Now;
                await MachineDataService.UpdateMachine(Machine);
                MachineId = null;
                Machines = (await MachineDataService.GetAllMachines()).ToList();
                NavigationManager.NavigateTo("machineoverview");
                //MethodToTriggerUrl();
            }

        }



    }
}
