using MachineCommandCenter.Client.Services;
using MachineCommandCenter.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MachineCommandCenter.Client.Pages
{
    public partial class MachineEdit
    {
        [Parameter]
        public string MachineId { get; set; }
        public string MachineStatus { get; set; }
        public Machine Machine { get; set; } = new Machine();
        [Inject]
        public IMachineDataService MachineDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Machine = await MachineDataService.GetMachineDetails(Guid.Parse(MachineId));
            //if(Machine.MachineStatus == 0)
            //{
            //    Machine.MachineStatus = 0;
            //}
            //else
            //{
            //    Machine.MachineStatus = 0;
            //}
            
          //  await MachineDataService.UpdateMachine(Machine);
            //MethodToTriggerUrl();
        }

        //protected void NavigateToOverview()
        //{
        //    NavigationManager.NavigateTo("/machineoverview");
        //}
    }
}
