using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SpendingsDAL.Repositories
{
	public interface IRepository<TEntity> where TEntity : class 
	{
		IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
		IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
		TEntity GetById(object id);
		void Add(params TEntity[] items);
		void Update(params TEntity[] items);
		void Delete(params TEntity[] items);
		void Delete(params int[] ids);
	}

	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private PurchasesEntities _context;
		private readonly DbSet<TEntity> _dbSet;

		public Repository()
        {
			_context = new PurchasesEntities();
			_dbSet = _context.Set<TEntity>();
        }

		public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
		{
			List<TEntity> list;
			using (var context = new PurchasesEntities())
			{
				IQueryable<TEntity> dbQuery = _dbSet;

				//Apply eager loading
				dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

				list = dbQuery
					.AsNoTracking()
					.ToList();
			}
			return list;
		}

		public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
			IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			using (var context = new PurchasesEntities())
			{
				IQueryable<TEntity> dbQuery = _dbSet;

				if (filter != null)
				{
					dbQuery = dbQuery.Where(filter);
				}

				foreach (var includeProperty in includeProperties.Split (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					dbQuery = dbQuery.Include(includeProperty);
				}

				return orderBy != null ? orderBy(dbQuery).ToList() : dbQuery.ToList();
			}
		}

		public virtual TEntity GetById(object id)
		{
			return _dbSet.Find(id);
		}


		public virtual void Add(params TEntity[] items)
		{
			using (var context = new PurchasesEntities())
			{
				foreach (var item in items)
				{
					_context.Entry(item).State = EntityState.Added;
				}
				_context.SaveChanges();
			}
		}

		public virtual void Update(params TEntity[] items)
		{
			using (var context = new PurchasesEntities())
			{
				foreach (var item in items)
				{
					_context.Entry(item).State = EntityState.Modified;
				}
				_context.SaveChanges();
			}
		}

		public virtual void Delete(params TEntity[] items)
		{
			using (var context = new PurchasesEntities())
			{
				foreach (var item in items)
				{
					_context.Entry(item).State = EntityState.Deleted;
				}
				_context.SaveChanges();
			}
		}

		public virtual void Delete(params int[] ids)
		{
			using (var context = new PurchasesEntities())
			{
				foreach (var id in ids)
				{
					TEntity entityToDelete = _dbSet.Find(id);
					_context.Entry(entityToDelete).State = EntityState.Deleted;
				}
				_context.SaveChanges();
			}
		}
	}
}
