namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NewsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title", ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]
        [StringLength(150, ErrorMessageResourceName = "DescriptionLength", ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]

        [MinLength(70,ErrorMessageResourceName  ="DescriptionLength",ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]

        public string Body { get; set; }
        [Required]
        public int NewsType { get; set; }

        [StringLength(500)]
        public string KeyWord { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsTrend { get; set; }

        public DateTime? TrendingDate { get; set; }
        public bool IsBanner { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }
        [Required]
        public int SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
        [Required]
        public int NewsSubcategoryId { get; set; }
        public virtual NewsSubCategory NewsSubCategory { get; set; }
        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual AspNetUsers ApplicationUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string NewsFileAddress { get; set; }
    }
}
