using Microsoft.EntityFrameworkCore;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayerProject.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {

        protected readonly ApplicationDbContext Context;

        public ClientRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(Client entity)
        {
             await Context.AddAsync(entity);
                Context.SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await Context.Client.ToListAsync();
        }

        public async ValueTask<Client> GetByIdAsync(int id)
        {
            return await Context.Client.FindAsync(id);
        }

        public void Remove(int id)
        {
            var data=Context.Client.Find(id);
            Context.Remove(data);
            Context.SaveChanges();
        }

        public void Update(Client entity)
        {
            //if(entity.Name!=null)
            //{
                //Context.Entry(entity).Property("Name").IsModified = true;
            //}
            Context.Entry(entity).State = EntityState.Modified;
           
            Context.SaveChanges();
        }
    }
}
