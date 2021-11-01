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

        public IEnumerable<Machine> Machines { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Machines = (await MachineDataService.GetAllMachines()).ToList();
        }
    }
}
