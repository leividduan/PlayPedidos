﻿using DezContas.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using PlayPedidos.Infra.Data;
using System.Linq.Expressions;

namespace DezContas.Data.Repositories
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly AppDbContext _context;

		public RepositoryBase(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Add(TEntity entity)
		{
			var entityAdded = await _context.Set<TEntity>().AddAsync(entity);
			return entityAdded != null;
		}

		public bool Edit(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			var entityEdited = _context.Set<TEntity>().Update(entity);
			return entityEdited != null;
		}

		public bool Delete(TEntity entity)
		{
			var entityDeleted = _context.Set<TEntity>().Remove(entity);
			return entityDeleted != null;
		}

		public async Task<int> Save()
		{
			return await _context.SaveChangesAsync();
		}

		public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter = null, string include = null)
		{
			var entity = await Get(filter, include);

			return entity.FirstOrDefault();
		}

		public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string include = null)
		{
			var entities = _context.Set<TEntity>().AsNoTracking();

			if (!String.IsNullOrEmpty(include))
				entities = entities.Include(include);
			if (filter != null)
				entities = entities.Where(filter);

			return await entities.ToListAsync();
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
