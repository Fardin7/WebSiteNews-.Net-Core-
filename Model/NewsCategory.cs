using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
   public class NewsCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }      
        public DateTime? CreateDate { get; set; }
        public virtual ICollection<NewsSubCategory> NewsSubCategories { get; set; }

    }
}
