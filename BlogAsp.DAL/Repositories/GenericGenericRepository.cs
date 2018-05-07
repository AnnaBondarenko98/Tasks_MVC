﻿using BlogAsp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogAsp.DAL.Repositories
{
    /// <summary>
    /// Implementing of common repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IBlogContext _database;

        public GenericGenericRepository(IBlogContext database)
        {
            _database = database;
        }

        public void Create(T item)
        {
            _database.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T item = _database.Set<T>().Find(id);

            if (item != null)
            {
                _database.Set<T>().Remove(item);
            }
        }

        public T Get(int id)
        {
            return _database.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _database.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _database.Set<T>().Where(predicate).ToList();
        }
    }
}
