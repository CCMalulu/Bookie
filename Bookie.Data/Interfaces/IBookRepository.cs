﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookie.Common.Model;

namespace Bookie.Data.Interfaces
{
    public interface IBookRepository : IGenericDataRepository<Book>
    {
        bool Exists(string filePath);

        Task<IList<Book>> GetAllAsync(params Expression<Func<Book, object>>[] navigationProperties);

        List<Book> GetAllNested();
    }
}