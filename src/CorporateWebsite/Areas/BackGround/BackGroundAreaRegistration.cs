using System.Web.Mvc;

namespace CorporateWebsite.Areas.BackGround
{
    public class BackGroundAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BackGround";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BackGround_default",
                "BackGround/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "CorporateWebsite.Areas.BackGround.Controllers" }
            );
        }
    }
}