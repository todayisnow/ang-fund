﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.ViewModels;

namespace Repository.Repository
{
    public interface IRepository<TModel, TViewModel> where TModel : class where TViewModel : IViewModel<TModel>
    {
        ICollection<TViewModel> Get();
        TViewModel Get(params object[] keys);
        ICollection<TViewModel> Get(Expression<Func<TModel, bool>> where, Expression<Func<TModel, object>> orderBy = null, bool? orderAsc = null, int? skip = null, int? take = null);
        int Count(Expression<Func<TModel, bool>> where = null);        
        TViewModel Add(TViewModel model);
        int Update(TViewModel model);
        int Delete(params object[] keys);
        int Delete(Expression<Func<TModel, bool>> where);
    }
}