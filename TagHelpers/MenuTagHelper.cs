using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devfestweekend.TagHelpers
{
    [HtmlTargetElement(Attributes = "Path")]
    public class MenuTagHelper : TagHelper
    {
        public PathString Path { get; set; }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await Task.Run(() =>
            {
                // provide the path to menu-items
                context.Items.Add("path", Path.Value);

                output.TagName = "ul";
                output.Attributes.Add("class", "nav navbar-nav");
            });
        }
    }
}
