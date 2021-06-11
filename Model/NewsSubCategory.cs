using System;
using System.Collections.Generic;

namespace Model
{
   public class NewsSubCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? NewsCategoryId { get; set; }
        public virtual NewsCategory NewsCategory { get; set; }
        public virtual NewsSubCategory NewsSubCategory1 { get; set; }
        public virtual ICollection<NewsSubCategory> NewsSubCategories2 { get; set; }
        public int? NewsSubCategoryId { get; set; }
        public virtual ICollection<News> News { get; set; }


    }
}
