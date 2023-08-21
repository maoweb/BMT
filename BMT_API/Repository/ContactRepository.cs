using BMT_API.Data;
using BMT_API.Models;
using BMT_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BMT_API.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

  
        public async Task<Contact> UpdateAsync(Contact entity)
        {
            _db.Contacts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
