
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
    public class UserService<TEntity> : IUser<TEntity> where TEntity : User
    {
        private readonly Context _dbContext;
        private DbSet<TEntity> _dbSet;
        public UserService(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetUserList()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetUser(int id)
        {
            var a = await _dbSet.FindAsync(id);
            return a;
        }
        public async Task<IQueryable<TEntity>> SearchUser(Expression<Func<TEntity, bool>> search = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (search != null)
            {
                query = query.Where(search);
            }
            return query;
        }

        public async Task<int> AddUser(TEntity entity)
        {
            int output = 0;
            _dbSet.Add(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }

        public async Task<int> UpdateUser(TEntity entity)
        {
            int output = 0;
            _dbSet.Update(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }
        public async Task<int> DeleteUser(TEntity entity)
        {
            int output = 0;
            _dbSet.Remove(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }

    }
}
