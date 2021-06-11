namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;
  

    [Table("Article")]
    public partial class Article
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }

        [StringLength(500)]
        public string KeyWord { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsActive { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }

        public int? ArticleSubcategoryId { get; set; }

        public virtual ArticleSubcategory ArticleSubcategory { get; set; }
    }
}
