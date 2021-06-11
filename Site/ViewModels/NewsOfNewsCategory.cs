using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Site.ViewModels
{
    public class NewsOfNewsCategory
    {
        public string Title { get; set; }
        public List<News>  News { get; set; }
        public List<string> Url { get; set; }
    }
}