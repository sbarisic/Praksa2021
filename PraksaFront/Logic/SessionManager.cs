using PraksaMid;
using PraksaMid.Model;
using System.Collections.Generic;
using System.Web;

namespace PraksaFront.Logic
{
    public static class SessionManager
    {
        public static void See()
        {
            if ((string)HttpContext.Current.Session["uname"] == null)
            {
                HttpContext.Current.Response.Redirect("404.aspx");
            }
            else
            {
                if (!HttpContext.Current.Session["admin"].Equals("true"))
                    HttpContext.Current.Response.Redirect("404.aspx");
            }
        }

        public static void Edit(int userId)
        {
            if ((string)HttpContext.Current.Session["uname"] == null)
            {
                HttpContext.Current.Response.Redirect("404.aspx");
            }
            else
            {
                List<RoleModel> userRoles = Role.GetRoles(Person.GetUserId((string)HttpContext.Current.Session["uname"]));

                foreach (RoleModel role in userRoles)
                {
                    if (role.Name == "Admin")
                        return;
                }
            }

            if (userId != Person.GetUserId((string)HttpContext.Current.Session["uname"]))
                HttpContext.Current.Response.Redirect("404.aspx");
        }
        public static void All()
        {
            if ((string)HttpContext.Current.Session["uname"] == null)
            {
                HttpContext.Current.Response.Redirect("404.aspx");
            }
        }
    }
}