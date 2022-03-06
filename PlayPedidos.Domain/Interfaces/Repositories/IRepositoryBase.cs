﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DezContas.Domain.Interfaces.Repositories
{
	public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
	{
		public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter = null, string include = null);
		public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string include = null);
		public Task<bool> Add(TEntity entity);
		public bool Edit(TEntity entity);
		public bool Delete(TEntity entity);
		public Task<int> Save();
	}
}