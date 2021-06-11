using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]
        [Display(Name = "Description", ResourceType = typeof(Resource.Resource))]
        public string Description { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]
        [Display(Name = "Name", ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Email { get; set; }
        
    }
}
