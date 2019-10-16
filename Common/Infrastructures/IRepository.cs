using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Extensions;

namespace Common.Infrastructures
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Delete(string id);
        void Delete(Expression<Func<T, bool>> @where);

        T GetById(int id);
        T GetById(long id);
        T GetById(string id);
        T GetAnyById(int id);
        T GetAnyById(long id);
        T GetAnyById(string id);

        T Get(Expression<Func<T, bool>> @where);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllActive();
        IQueryable<T> GetAllDeleted();

        IEnumerable<T> GetPaged(Expression<Func<T, bool>> predicate, Action<IOrderable<T>> order, int pageIndex, int pageSize);

        IEnumerable<T> GetPagedActive(Expression<Func<T, bool>> predicate, Action<IOrderable<T>> order, int pageIndex, int pageSize);

        IEnumerable<T> GetPagedDeleted(Expression<Func<T, bool>> predicate, Action<IOrderable<T>> order, int pageIndex, int pageSize);

        IQueryable<T> IncludeSubSets(params Expression<Func<T, object>>[] includeProperties);

        List<T> ExecuteStoredProcedure<T>(string procedureName, Dictionary<string, object> parameters);
    }
}