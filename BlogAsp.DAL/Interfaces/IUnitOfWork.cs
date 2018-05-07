﻿using System;
using BlogAsp.Models.Models;

namespace BlogAsp.DAL.Interfaces
{
    /// <summary>
    /// Unit of Repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Question> QuestGenericRepository { get; }

        IGenericRepository<Article> ArticleGenericRepository { get; }

        IGenericRepository<Comment> CommentGenericRepository { get; }

        void Commit();
    }
}