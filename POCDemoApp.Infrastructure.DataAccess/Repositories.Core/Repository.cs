using Microsoft.EntityFrameworkCore;
using POCDemoApp.Domain.Entity.Interfaces.Core;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POCDemoApp.Infrastructure.DataAccess.Repositories.Core
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
	{
		protected readonly DbContext Context;

		protected Repository(DbContext context)
		{
			Context = context;
		}

		#region Get methods
		public TEntity Get(long id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate);
		}
		#endregion

		#region Add methods
		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().AddRange(entities);
		}
		#endregion

		#region Delete methods
		public void Delete(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public void DeleteRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}
		#endregion
	}
}
