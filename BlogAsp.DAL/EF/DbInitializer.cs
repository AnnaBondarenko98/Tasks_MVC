﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using BlogAsp.Models.Models;

namespace BlogAsp.DAL.EF
{
    /// <summary>
    /// Database initializer
    /// </summary>
    internal class DbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Database Context</param>
        protected override void Seed(BlogContext db)
        {
            db.Comments.Add(
                new Comment
                {
                    Text = "Some text......",
                    Author = "Anna",
                    Date = DateTime.UtcNow
                });

            var tag1 = new Tag
            {
                Text = "статья"
            };

            db.Articles.Add(
                new Article
                {
                    Date = DateTime.UtcNow,
                    Name = "Article1",
                    Text = "Передовая статья выражает точку" +
                           " зрения редакции по самому актуальному" +
                           " вопросу в данный момент. Передовая статья" +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов." +
                           " вопросу в данный момент. Передовая статья" +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов." +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов.",
                    Tags = new List<Tag>
                    {
                        tag1,
                        new Tag
                        {
                            Text = "требования"
                        },
                        new Tag
                        {
                            Text = "актуальность"
                        }
                    }
                });

            db.Articles.Add(
                new Article
                {
                    Date = DateTime.UtcNow,
                    Name = "Article2",
                    Text = "Статья 197. Операции, освобожденные от налогообложения" +
                           " поставке услуг по получению высшего, среднего, профессионально-" +
                           "технического и дошкольного образования учебными заведениями, в том" +
                           " числе обучению аспирантов и докторантов, учебными заведениями, имеющими" +
                           " лицензию на поставку таких услуг, а также услуг по воспитанию и обучению" +
                           " детей в домах культуры, детских музыкальных, художественных, спортивных " +
                           "школах и клубах, школах искусств и услуг по проживанию учащихся либо студентов" +
                           " в общежитиях. К таким услугам относятся услуги ",
                    Tags = new List<Tag>
                    {
                       tag1,
                        new Tag
                        {
                            Text = "операции"
                        },
                        new Tag
                        {
                            Text = "услуги"
                        }
                    }
                });

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
