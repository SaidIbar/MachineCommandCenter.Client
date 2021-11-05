using MachineCommandCenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MachineCommandCenter.Client.Services
{

    public class MachineDataService : IMachineDataService
    {
        private readonly HttpClient _httpClient;

        public MachineDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Machine> AddMachine(Machine machine)
        {
            var machineJson =
                new StringContent(JsonSerializer.Serialize(machine), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/machine", machineJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Machine>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteMachine(Guid machineId)
        {
            //var machine = await JsonSerializer.DeserializeAsync<Machine>
                 await _httpClient.DeleteAsync($"api/Machine/{machineId}");
            //return machine;
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {

            return await JsonSerializer.DeserializeAsync<IEnumerable<Machine>>
                  (await _httpClient.GetStreamAsync($"api/Machine"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Machine> GetMachineDetails(Guid machineId)
        {
            var machine = await JsonSerializer.DeserializeAsync<Machine>
                 (await _httpClient.GetStreamAsync($"api/Machine/{machineId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return machine;
        }

        public async Task UpdateMachine(Machine machine)
        {
            var machineJson =
               new StringContent(JsonSerializer.Serialize(machine), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/machine", machineJson);
        }
    }
}
