using MultiLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerProject.Core.Services
{
    public interface IClientService
    {
        ValueTask<Client> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client entity);
        void Update(Client entity);
        void Remove(int id);
    }
}
