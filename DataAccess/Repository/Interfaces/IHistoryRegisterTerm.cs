using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IHistoryRegisterTerm<TEntity>
    {
        Task<IEnumerable<TEntity>> GetHistoryRegisterTermList();
        Task<TEntity> GetHistoryRegisterTerm(int id);
        Task<IQueryable<TEntity>> SearchHistoryRegisterTerm(Expression<Func<TEntity, bool>> search = null);
        Task<int> AddHistoryRegisterTerm(TEntity entity);
        Task<int> UpdateHistoryRegisterTerm(TEntity entity);
        Task<int> DeleteHistoryRegisterTerm(TEntity entity);
    }
}
