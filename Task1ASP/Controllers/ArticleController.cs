﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BlogAsp.BLL.Interfaces;
using Task1ASP.Models.Article;

namespace Task1ASP.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;

        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService1, ITagService tagService, IMapper mapper)
        {
            _articleService = articleService1;
            _tagService = tagService;
            _mapper = mapper;
        }

        public ActionResult Articles()
        {
            var articles = _articleService.GetAll();

            var articlesVm = _mapper.Map<IEnumerable<ArticleVm>>(articles);

            return View(articlesVm);
        }

        [HttpGet]
        public ActionResult Vote()
        {
            return PartialView("Vote");
        }

        [HttpPost]
        public ActionResult Vote(string gender)
        {
            return PartialView("VoteComplete");
        }

        public ActionResult Details(int id)
        {
            var article = _articleService.Get(id);

            return View(article);
        }

        public ActionResult TagActive(int id)
        {
            var articles = _tagService.GetArticlesByTagId(id);

            var articlesVm = _mapper.Map<IEnumerable<ArticleVm>>(articles);

            return View("Articles", articlesVm);

        }

        [HttpPost]
        public JsonResult CheckDate(DateTime date)
        {
            var result = date.Day == DateTime.UtcNow.Date.Day;

            return Json(result);
        }
    }
}