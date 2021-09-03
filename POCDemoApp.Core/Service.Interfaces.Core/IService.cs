using POCDemoApp.Domain.Entity.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POCDemoApp.Core.Service.Interfaces.Core
{
	public interface IService<TEntity> where TEntity : IEntity
	{
		#region Get methods
		TEntity Get(long id);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		#endregion

		#region Add methods
		void Add(TEntity apiModelEntity);
		void AddRange(IEnumerable<TEntity> apiModelEntities);
		#endregion

		#region Delete methods
		void Delete(TEntity apiModelEntity);
		void DeleteRange(IEnumerable<TEntity> apiModelEntities);
		#endregion

	}
}
