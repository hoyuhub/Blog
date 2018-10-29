using System;
using System.Collections.Generic;
using System.Text;
using Blog.Common;

namespace Blog.Models
{
    public class BLogModel
    {
        public BLogModel(string title, string author, DateTime time, string content, string slug)
        {
            bool flag = true;
            if (!string.IsNullOrEmpty(title))
                this.Title = title;
            else
                flag = false;

            if (!string.IsNullOrEmpty(title))
                this.Author = author;
            else
                flag = false;

            if (time == null)
                flag = false;
            else
                this.Time = time;

            if (!string.IsNullOrEmpty(content))
                this.Content = content;
            else
                flag = false;

            if (!string.IsNullOrEmpty(slug))
                this.Slug = slug;
            else
                flag = false;

            if (flag == false)
            {
                throw new ApplicationException("创建BLogModel实体有必填字段为空");
            }
        }
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Time { get; set; }

        public string Content { get; set; }

        public string Slug { get; set; }
    }
}