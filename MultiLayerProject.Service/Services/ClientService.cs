using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Repositories;
using MultiLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerProject.Service.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task AddAsync(Client entity)
        {
            await  clientRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await clientRepository.GetAllAsync();
        }

        public async ValueTask<Client> GetByIdAsync(int id)
        {
            return await clientRepository.GetByIdAsync(id);
        }

        public void Remove(int Id)
        {
            clientRepository.Remove(Id);
        }

        public void Update(Client entity)
        {
            clientRepository.Update(entity);
        }
    }
}
