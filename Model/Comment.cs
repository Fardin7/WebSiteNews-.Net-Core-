using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType =typeof(Resource.Resource))]
        [Display(Name= "Description", ResourceType =typeof(Resource.Resource))]  
        [MaxLength(400,ErrorMessageResourceName  ="DescriptionLength",ErrorMessageResourceType = typeof(Resource.Resource))]

        public string Description { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]
        [Display(Name = "Name", ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Email { get; set; }
        [Required]
        public int NewsId { get; set; }
        public virtual News News { get; set; }
        
    }
}
