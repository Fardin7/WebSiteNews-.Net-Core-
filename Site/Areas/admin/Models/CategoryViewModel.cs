namespace Model
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  
    public partial class CategoryViewModel
    {
        

        public string Title { get; set; }

        
        public bool IsActive { get; set; }

        public  IFormFile Files { get; set; }
    }          
}
