using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Site.CustomAuthorization
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        public IUnitOfWork _UnitOfWork;
        public RolesAuthorizationHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var roles = requirement.AllowedRoles.ToList();
            var username = context.User.Identity.Name;
            var knk = _UnitOfWork.DBContext.Set<AspNetUsers>().ToList() ;
            var userpermmision = _UnitOfWork.DBContext.Set<AspNetUsers>().Where(q => q.UserName == username).FirstOrDefault().Permissions.ToList();
            //List<Role> userrole = _UnitOfWork.DBContext.Set<Role>().
            //    Database.SqlQuery<Role>("select *  from AspNetRoles R join  AspNetUserRoles UR ON R.Id = UR.RoleId JOIN  AspNetUsers U ON  U.Id = UR.UserId where U.Id={0}", userid).ToList();
            //var rolepermmision = (from permission in unitOfWork.DBContext.Set<Permission>().ToList()
            //                      join ur in userrole on permission.RoleId equals ur.Id
            //                      select permission).ToList();
            //var allpermission = (from permission in userpermmision
            //                     select permission).Union(rolepermmision).ToList();

            

            //context.User.Identities.Where(q=>q.Name=="").FirstOrDefault().FindFirst().
            //var action = context.Request.RequestContext.RouteData.Values["action"].ToString();
            //var controller = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();

            //var entity = (int)Enum.Parse(typeof(Entity), controller.ToLower());
            //var function = (int)Enum.Parse(typeof(Action), action.ToLower());
            //if (allpermission.Count > 0)
            //{
            //    foreach (var item in allpermission)
            //    {
            //        if (item.Acrion == function && item.Entity == entity)
            //        {

            //            authorize = true;
            //            break;
            //        }
            //        else
            //        {
            //            authorize = false;
            //        }
            //    }
            //}
            //else
            //{
            //    authorize = false;
            //}




            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
               // var roles = requirement.AllowedRoles;
                //context.Students
                //  .FromSql("Select * from Students where Name = 'Bill'")
                //  .ToList();
                //validRole = new Users().GetUsers().Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
