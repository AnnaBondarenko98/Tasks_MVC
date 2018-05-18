﻿using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Article> GetAll()
        {
            return _unitOfWork.ArticleGenericRepository.GetAll();
        }

        public Article Get(int id)
        {
            if (id <= 0)
            {
                throw new ObjectNotFoundException(nameof(Article));
            }

            return _unitOfWork.ArticleGenericRepository.Get(id);
        }

        public void Create(Article article)
        {
            _unitOfWork.ArticleGenericRepository.Create(article);
        }

        public void Update(Article article)
        {
            _unitOfWork.ArticleGenericRepository.Update(article);
        }

        public IEnumerable<Tag> GetTags(int id)
        {
            return _unitOfWork.ArticleGenericRepository.Get(id).Tags;
        }

        public Article GetTvTariffWithChannels(Article article, string[] names)
        {

            foreach (var name in names)
            {
                article.Tags.Add(
                    (_unitOfWork.TagGenericRepository.Find(tag => tag.Text == name).FirstOrDefault()));
            }

            return article;
        }

        public void Delete(int id)
        {
            _unitOfWork.ArticleGenericRepository.Delete(id);
        }
    }
}
