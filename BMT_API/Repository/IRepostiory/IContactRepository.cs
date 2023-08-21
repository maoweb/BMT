using BMT_API.Models;
using System.Linq.Expressions;

namespace BMT_API.Repository.IRepostiory
{
    public interface IContactRepository : IRepository<Contact>
    {
      
        Task<Contact> UpdateAsync(Contact entity);
  
    }
}
