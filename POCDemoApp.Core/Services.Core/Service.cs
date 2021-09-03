using AutoMapper;
using POCDemoApp.Core.Service.Interfaces.Core;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Entity.Interfaces.Core;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POCDemoApp.Core.Services.Core
{
	public abstract class Service<TEntity> : IService<TEntity> where TEntity : IEntity
	{
		protected readonly IUnitOfWork UnitOfWork;
		protected readonly IMapper AutoMapper;
		protected readonly IMediatorHandler Bus;

		protected Service(IUnitOfWork unitOfWork, IMediatorHandler bus, IMapper autoMapper)
		{
			UnitOfWork = unitOfWork;
			Bus = bus;
			AutoMapper = autoMapper;
		}

		#region Get methods
		public TEntity Get(long id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Add methods
		public void Add(TEntity apiModelEntity)
		{
			throw new NotImplementedException();
		}

		public void AddRange(IEnumerable<TEntity> apiModelEntities)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Delete methods
		public void Delete(TEntity apiModelEntity)
		{
			throw new NotImplementedException();
		}

		public void DeleteRange(IEnumerable<TEntity> apiModelEntities)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
