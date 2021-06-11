namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("ArticleCategory")]
    public partial class ArticleCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticleCategory()
        {
            ArticleSubcategories = new HashSet<ArticleSubcategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleSubcategory> ArticleSubcategories { get; set; }
    }
}
