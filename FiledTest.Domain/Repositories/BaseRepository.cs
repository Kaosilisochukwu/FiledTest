using FiledTest.Domain.Data;
using FiledTest.Domain.Interfaces;
using FiledTest.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PaymentDbContext _context;
        private readonly DbSet<T> _entitySet;

        protected BaseRepository(PaymentDbContext context)
        {
            _context = context;
            _entitySet = context.Set<T>();
        }
        public async Task<T> GetData(int id)
        {
            var entity = await _entitySet.FindAsync(id);
            return entity;
        }

        public async Task<int> SaveData(T t)
        {

            if (t != null)
            {
                await _entitySet.AddAsync(t);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateData(T t)
        {
            if (t != null)
            {
                _context.Update(t);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
