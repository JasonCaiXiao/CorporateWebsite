using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CorporateWebsite.Extension
{
    public static class HtmlUrlHelperExtensions
    {
        public static MvcHtmlString GenreLinks(this UrlHelper helper, IEnumerable<string> genres)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string genre in genres)
            {
                sb.Append(string.Format("<span><a href=\"{0}\">{1}</a></span>",
                    helper.RouteUrl("GenreHome", new { Genre = genre }), genre));
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ActorLinks(this UrlHelper helper, IEnumerable<string> actors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string actor in actors)
            {
                sb.Append(string.Format("<span><a href=\"{0}\">{1}</a></span>",
                    helper.RouteUrl("ActorHome", new { Actor = actor }), actor));
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}