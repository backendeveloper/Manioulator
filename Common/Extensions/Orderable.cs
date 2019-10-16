using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Extensions
{
    public class Orderable<T> : IOrderable<T> where T : class
    {
        private IQueryable<T> _queryable;
        public Orderable(IQueryable<T> asQueryable)
        {
            if (asQueryable == null)
            {
                throw new ArgumentNullException(nameof(asQueryable));
            }

            _queryable = asQueryable;
        }

        public IQueryable<T> AsQueryable()
        {
            return _queryable;
        }

        public IOrderable<T> Asc<TKey1>(Expression<Func<T, TKey1>> keySelector1)
        {
            _queryable = _queryable.OrderBy(keySelector1);

            return this;
        }

        public IOrderable<T> Asc<TKey1, TKey2>(Expression<Func<T, TKey1>> keySelector1, Expression<Func<T, TKey2>> keySelector2)
        {
            _queryable = _queryable.OrderBy(keySelector1).ThenBy(keySelector2);

            return this;
        }

        public IOrderable<T> Asc<TKey1, TKey2, TKey3>(Expression<Func<T, TKey1>> keySelector1, Expression<Func<T, TKey2>> keySelector2, Expression<Func<T, TKey3>> keySelector3)
        {
            _queryable = _queryable.OrderBy(keySelector1).ThenBy(keySelector2).ThenBy(keySelector3);

            return this;
        }

        public IOrderable<T> Desc<TKey1>(Expression<Func<T, TKey1>> keySelector1)
        {
            _queryable = _queryable.OrderByDescending(keySelector1);

            return this;
        }

        public IOrderable<T> Desc<TKey1, TKey2>(Expression<Func<T, TKey1>> keySelector1, Expression<Func<T, TKey2>> keySelector2)
        {
            _queryable = _queryable.OrderByDescending(keySelector1).ThenByDescending(keySelector2);

            return this;
        }

        public IOrderable<T> Desc<TKey1, TKey2, TKey3>(Expression<Func<T, TKey1>> keySelector1, Expression<Func<T, TKey2>> keySelector2, Expression<Func<T, TKey3>> keySelector3)
        {
            _queryable = _queryable.OrderByDescending(keySelector1).ThenByDescending(keySelector2).ThenByDescending(keySelector3);

            return this;
        }
    }
}