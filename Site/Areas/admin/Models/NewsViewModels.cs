using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Area.admin.Models
{
    public  class NewsViewModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }
        [Required]
        public int NewsType { get; set; }

        [StringLength(500)]
        public string KeyWord { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsActive { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }

        public int? SubcategoryId { get; set; }

      
        public IFormFile NewsFile { get; set; }
       
    }
}