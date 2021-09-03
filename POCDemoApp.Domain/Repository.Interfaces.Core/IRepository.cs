using POCDemoApp.Domain.Entity.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POCDemoApp.Domain.Repository.Interfaces.Core
{
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		#region Get methods
		TEntity Get(long id);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		#endregion

		#region Add methods
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		#endregion

		#region Delete methods
		void Delete(TEntity entity);
		void DeleteRange(IEnumerable<TEntity> entities);
		#endregion
	}
}
