using Proyect.Core.Repositories;
using Proyect.Core.Services;
using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Service
{
    public class ClientServise : IClientService
    {

        private readonly IClientRepositories _clientRepository;

        public ClientServise(IClientRepositories clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Clients>> GetAllAsync()
        {
            var x = await _clientRepository.GetAllAsync();
            return x;


        }
        public async Task<Clients> GetByIdAsync(int id)
        {
            var x = await _clientRepository.GetByIdAsync(id);
            return x;


        }
        public async Task<Clients> GetBynameAsync(string name)
        {
            return await _clientRepository.GetBynameAsync(name);
        }
        public async Task<Clients> GetBymailAsync(string mail)
        {
            return await _clientRepository.GetBymailAsync(mail);
        }
        public async Task PostAsync(Clients value)
        {
            await _clientRepository.PostAsync(value);
            await _clientRepository.SaveAsync();


        }
        public async Task PutAsync(int id, Clients value)
        {
            await _clientRepository.PutAsync(id, value);
            await _clientRepository.SaveAsync();

        }
        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);

            await _clientRepository.SaveAsync();
        }
    }
}
