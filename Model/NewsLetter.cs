using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public class NewsLetter
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource.Resource))]
        [Display(Name = "Email", ResourceType = typeof(Resource.Resource))]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
