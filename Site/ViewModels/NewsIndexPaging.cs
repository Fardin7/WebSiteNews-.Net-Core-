using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.ViewModels
{
    public class NewsIndexPaging
    {
        public double Pages { get; set; }
        public int NewsType { get; set; }
        public int NewsCategory { get; set; }
        public int Category { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string ImageAddress { get; set; }

        public string Url { get; set; }

        public string   SubCategoryTitle { get; set; }

        public string NewsCategoryTitle { get; set; }
        public DateTime? PublishDate { get; set; }



    }

}