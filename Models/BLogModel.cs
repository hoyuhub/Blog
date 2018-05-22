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
            if (!title.IsNullOrEmpty())
                this.title = title;
            else
                flag = false;

            if (!author.IsNullOrEmpty())
                this.author = author;
            else
                flag = false;

            if (time == null)
                flag = false;
            else
                this.time = time;

            if (!content.IsNullOrEmpty())
                this.content = content;
            else
                flag = false;

            if (!slug.IsNullOrEmpty())
                this.slug = slug;
            else
                flag = false;

            if (flag == false)
            {
                throw new ApplicationException("创建BLogModel实体有必填字段为空");
            }
        }
        public string title { get; set; }

        public string author { get; set; }

        public DateTime time { get; set; }

        public string content { get; set; }

        public string slug { get; set; }
    }
}