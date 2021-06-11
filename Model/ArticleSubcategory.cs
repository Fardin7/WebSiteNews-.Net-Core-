namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("ArticleSubcategory")]
    public partial class ArticleSubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticleSubcategory()
        {
            Articles = new HashSet<Article>();
            ArticleSubcategory1 = new HashSet<ArticleSubcategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }

        public int? ArticleCategoryId { get; set; }

        public int? ArticleSubcategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual ArticleCategory ArticleCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleSubcategory> ArticleSubcategory1 { get; set; }

        public virtual ArticleSubcategory ArticleSubcategory2 { get; set; }
    }
}
