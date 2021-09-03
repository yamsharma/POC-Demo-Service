using Microsoft.AspNetCore.Mvc;
using POCDemoApp.Domain.Entity.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POCDemoApp.API.Controller.Interfaces.Core
{
	public interface IController<TEntity> where TEntity : IEntity
	{
		#region Get actions
		Task<IActionResult> Get(long id);
		Task<IActionResult> GetAll();
		Task<IActionResult> Find(Expression<Func<TEntity, bool>> predicate);
		#endregion

		#region Add actions
		IActionResult Add(TEntity entity);
		IActionResult AddRange(IEnumerable<TEntity> entities);
		#endregion

		#region Update actions
		IActionResult Update(TEntity entity);
		#endregion

		#region Delete actions
		IActionResult Delete(TEntity entity);
		IActionResult DeleteRange(IEnumerable<TEntity> entities);
		#endregion
	}
}
