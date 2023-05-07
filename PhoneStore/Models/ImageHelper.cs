using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PhoneStore.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src,
            string altText, string height, string width)
        {
            var b = new TagBuilder("img");
            b.MergeAttribute("src", src);
            b.MergeAttribute("alt", altText);
            b.MergeAttribute("height", height);
            b.MergeAttribute("width", width);
            return MvcHtmlString.Create(b.ToString(TagRenderMode.SelfClosing));
        }
    }
}