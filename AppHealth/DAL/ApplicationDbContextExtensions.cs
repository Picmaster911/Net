﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL
{
    public static class ApplicationDbContextExtensions
    {
        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            return EntityFrameworkQueryableExtensions.Include(source, navigationPropertyPath);
        }

        public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath) where TEntity : class
        {
            return EntityFrameworkQueryableExtensions.ThenInclude(source, navigationPropertyPath);
        }
    }
}
