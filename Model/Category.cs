namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        
        public bool IsActive { get; set; }

        [StringLength(500)]
        public string ImageAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
