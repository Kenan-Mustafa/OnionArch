using Application.Interface.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T:class , IEntityBase , new()
{
    private readonly AppDbContext dbContext;
    public ReadRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    private DbSet<T> Table { get => dbContext.Set<T>(); }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orederBy = null, bool enableTracing = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracing) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orederBy is not null) 
            return await orederBy(queryable).ToListAsync();

        return await queryable.ToListAsync();      
    }

    public async Task<IList<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orederBy = null, bool enableTracing = false, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracing) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orederBy is not null)
            return await orederBy(queryable).Skip((currentPage -1)*pageSize).Take(pageSize).ToListAsync();

        return await queryable.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracing = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracing) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        //queryable = queryable.Where(predicate);

        return await queryable.FirstOrDefaultAsync(predicate);
    }
    public Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
    {
        if(predicate is not null) Table.Where(predicate).AsNoTracking();
        return Table.CountAsync() ;
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking = false)
    {
        if(!enableTracking) Table.AsNoTracking();
        return  Table.Where(predicate);
    }


}
