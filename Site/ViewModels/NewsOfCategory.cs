using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Site.ViewModels
{
    public class NewsOfCategory
    {
        public string Title { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}