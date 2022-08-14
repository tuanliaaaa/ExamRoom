using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IUser<TEntity>
    {
        Task<IEnumerable<TEntity>> GetUserList();
        Task<TEntity> GetUser(int id);
        Task<IQueryable<TEntity>> SearchUser(Expression<Func<TEntity, bool>> search = null);
        Task<int> AddUser(TEntity entity);
        Task<int> UpdateUser(TEntity entity);
        Task<int> DeleteUser(TEntity entity);

    }
}
