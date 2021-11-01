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

        public Task DeleteMachine(Guid machineId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Machine>>
                  (await _httpClient.GetStreamAsync($"api/machine"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<Machine> GetMachineDetails(Guid machineId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMachine(Machine machine)
        {
            throw new NotImplementedException();
        }
    }
}
