﻿using System;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.DAL.Repositories
{
    /// <summary>
    /// Implementing of Unit of repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBlogContext _db;

        private readonly Lazy<GenericGenericRepository<Question>> _questRepos;
        private readonly Lazy<GenericGenericRepository<Article>> _articleRepos;
        private readonly Lazy<GenericGenericRepository<Comment>> _commentRepos;

        public UnitOfWork(IBlogContext db)
        {
            _db = db;

            _questRepos = new Lazy<GenericGenericRepository<Question>>(
                () => new GenericGenericRepository<Question>(_db));
            _articleRepos = new Lazy<GenericGenericRepository<Article>>(
                () => new GenericGenericRepository<Article>(_db));
            _commentRepos = new Lazy<GenericGenericRepository<Comment>>(
                () => new GenericGenericRepository<Comment>(_db));
        }

        public IGenericRepository<Question> QuestGenericRepository => _questRepos.Value;
        public IGenericRepository<Article> ArticleGenericRepository => _articleRepos.Value;
        public IGenericRepository<Comment> CommentGenericRepository => _commentRepos.Value;

        public void Commit()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _db.Dispose();

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
