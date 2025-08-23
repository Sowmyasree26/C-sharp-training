using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Assignment.Models;

namespace MVC_Assignment.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }
}
