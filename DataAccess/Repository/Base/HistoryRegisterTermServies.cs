using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Base
{
    public class HistoryRegisterTermServies<TEntity> : IHistoryRegisterTerm<TEntity> where TEntity : HistoryRegisterTerm
    {
        private readonly Context _dbContext;
        private DbSet<TEntity> _dbSet;
        public HistoryRegisterTermServies(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetHistoryRegisterTermList()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetHistoryRegisterTerm(int id)
        {
            var a = await _dbSet.FindAsync(id);
            return a;
        }
        public async Task<IQueryable<TEntity>> SearchHistoryRegisterTerm(Expression<Func<TEntity, bool>> search = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (search != null)
            {
                query = query.Where(search);
            }
            return query;
        }

        public async Task<int> AddHistoryRegisterTerm(TEntity entity)
        {
            int output = 0;
            _dbSet.Add(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }

        public async Task<int> UpdateHistoryRegisterTerm(TEntity entity)
        {
            int output = 0;
            _dbSet.Update(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }
        public async Task<int> DeleteHistoryRegisterTerm(TEntity entity)
        {
            int output = 0;
            _dbSet.Remove(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }

    }
}
