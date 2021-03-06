﻿using System;
using System.Collections.Generic;
using System.Linq;

using CMS.DocumentEngine;
using CMS.DocumentEngine.Types;

namespace DancingGoat.Models.Articles
{
    public class ArticleViewModel
    {
        #region "Properties"

        public Attachment Teaser
        {
            get;
            set;
        }


        public string Title
        {
            get;
            set;
        }


        public DateTime PublicationDate
        {
            get;
            set;
        }


        public string Summary
        {
            get; set;
        }


        public string Text
        {
            get;
            set;
        }


        public IEnumerable<ArticleViewModel> RelatedArticles
        {
            get;
            set;
        }


        public int NodeID
        {
            get;
            set;
        }


        public string NodeAlias
        {
            get;
            set;
        }

        #endregion


        #region "Methods"

        /// <summary>
        /// Gets ArticleViewModel from Article object.
        /// </summary>
        /// <param name="article">Document type representing <see cref="Article"/>Article  object.</param>
        /// <returns>ArticleViewModel object.</returns>
        public static ArticleViewModel GetViewModel(Article article)
        {
            return new ArticleViewModel
            {
                NodeAlias = article.NodeAlias,
                NodeID = article.NodeID,
                PublicationDate = article.PublicationDate,
                RelatedArticles = article.Fields.RelatedArticles.OfType<Article>().Select(GetViewModel),
                Summary = article.Fields.Summary,
                Teaser = article.Fields.Teaser,
                Text = article.Fields.Text,
                Title = article.Fields.Title
            };
        }

        #endregion
    }
}