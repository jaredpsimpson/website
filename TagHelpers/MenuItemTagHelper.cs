using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devfestweekend.TagHelpers
{
    [HtmlTargetElement(Attributes = nameof(Href), ParentTag = "menu")]
    public class MenuItemTagHelper : TagHelper
    {
        public string Href { get; set; }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await Task.Run(() =>
            {
                output.TagName = "li";
                var hrefPath = new PathString(Href);
                var currentPath = new PathString((string)context.Items["path"]);
                if (hrefPath.Equals(currentPath))
                {
                    output.Attributes.Add("class", "active");
                }
                output.PreContent.SetHtmlContent($"<a href=\"{Href}\">");
                output.PostContent.SetHtmlContent("</a>");
            });
        }
    }
}
