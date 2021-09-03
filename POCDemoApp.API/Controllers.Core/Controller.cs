using Microsoft.AspNetCore.Mvc;
using POCDemoApp.Core.Service.Interfaces.Core;
using POCDemoApp.Domain.Entity.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POCDemoApp.API.Controllers.Core
{
	public abstract class Controller<TEntity> : ControllerBase where TEntity : IEntity
	{
		protected readonly IService<TEntity> Service;

		protected Controller(IService<TEntity> service)
		{
			Service = service;
		}

		#region Get actions
		[HttpGet("{id}")]
		protected async Task<IActionResult> Get(long id)
		{
			TEntity entity;
			try
			{
				entity = await Task.FromResult(Service.Get(id));
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			if (entity == null)
				return NotFound();

			return Ok(entity);
		}

		[Route("[action]")]
		[HttpGet]
		protected async Task<IActionResult> GetAll()
		{
			IEnumerable<TEntity> entities;
			try
			{
				entities = await Task.FromResult(Service.GetAll());
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			if (entities == null || !entities.Any())
				return NotFound();

			return Ok(entities);
		}

		[Route("[action]")]
		[HttpGet]
		protected Task<IActionResult> Find(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Add actions
		[HttpPost]
		protected IActionResult Add([FromBody] TEntity entity)
		{
			try
			{
				Service.Add(entity);
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return Ok();
		}

		[Route("[action]")]
		[HttpPost]
		protected IActionResult AddRange([FromBody] IEnumerable<TEntity> entities)
		{
			try
			{
				Service.AddRange(entities);
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return Ok();
		}
		#endregion

		#region Update actions
		[HttpPut]
		protected IActionResult Update([FromBody] TEntity entity)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Delete actions
		[HttpDelete]
		protected IActionResult Delete([FromBody] TEntity entity)
		{
			try
			{
				Service.Delete(entity);
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return Ok();
		}

		[Route("[action]")]
		[HttpDelete]
		protected IActionResult DeleteRange([FromBody] IEnumerable<TEntity> entities)
		{
			try
			{
				Service.DeleteRange(entities);
			}
			catch (NotImplementedException)
			{
				return BadRequest("API Endpoint not implemented");
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return Ok();
		}
		#endregion
	}
}
