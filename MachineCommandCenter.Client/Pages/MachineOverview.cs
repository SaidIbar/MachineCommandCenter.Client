﻿using MachineCommandCenter.Client.Services;
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
        public string Name = string.Empty;
        //public MachineStatus machineStatus { get; } = new MachineStatus();
        public List<MachineStatus> MachineStatuses { get; } = new List<MachineStatus>();
        //protected string MachineStatus = string.Empty;

        [Parameter]
        public string MachineId { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
        protected bool Saved;
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
            if (IdString != "")
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
                
                await MachineDataService.UpdateMachine(Machine);
                Machines = (await MachineDataService.GetAllMachines()).ToList();
                NavigationManager.NavigateTo("machineoverview");
                //MethodToTriggerUrl();
            }
            else
            {
                Machine = new Machine
                {
                    Name = "",
                    SentDataDateTime = DateTime.Now,
                    //MachineStatus = 0
                };
            }


        }

        protected async Task HandleValidSubmit()
        {
          
            Machine.SentDataDateTime = DateTime.Now;
            IdString = MachineId?.ToString() ?? "";
            //Id = null;
            if(IdString == "")
            {
                Machine.MachineId = Guid.NewGuid();
                if (Machine.MachineStatus.Equals(0))
                {
                    Machine.MachineStatus = 0;
                }
                else
                {
                    Machine.MachineStatus = (MachineStatus)1;
                }
                var addedMachine = await MachineDataService.AddMachine(Machine);
                
                Machines = (await MachineDataService.GetAllMachines()).ToList();
                NavigationManager.NavigateTo("machineoverview");
            }
            else
            {
               
                NavigationManager.NavigateTo("machineoverview");
            }
           
        }


    }
}
