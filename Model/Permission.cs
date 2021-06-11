
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
   public partial class Permission
    {
        public int Id { get; set; }
        public int Acrion { get; set; }
        public int Entity { get; set; }
        public string ApplicationUserId { get; set; }
        //[ForeignKey("Role")]
        public string RoleId { get; set; }

        public virtual Role AspNetRoles { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}
