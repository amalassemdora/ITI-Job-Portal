#pragma checksum "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b588dde504019dad5971863f15c31e581d0b14cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_LoadComment), @"mvc.1.0.view", @"/Views/User/LoadComment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Haleem\source\repos\Itians\Itians\Views\_ViewImports.cshtml"
using Itians;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Haleem\source\repos\Itians\Itians\Views\_ViewImports.cshtml"
using Itians.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Haleem\source\repos\Itians\Itians\Views\_ViewImports.cshtml"
using Itians.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Haleem\source\repos\Itians\Itians\Views\_ViewImports.cshtml"
using Itians.Controllers.HelperClasses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Haleem\source\repos\Itians\Itians\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b588dde504019dad5971863f15c31e581d0b14cd", @"/Views/User/LoadComment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5c000facd82696f7dfe9a0cd5222bb21053d772", @"/Views/_ViewImports.cshtml")]
    public class Views_User_LoadComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile-post-comment-pic me-2 align-self-start"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Source/images/profile.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("profile-photo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
 foreach (var comment in ViewBag.comments)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"comment\" class=\"comments\">\r\n        <div class=\"comment mb-3\">\r\n            <div class=\"d-flex p-1 justify-content-between\">\r\n                <div class=\"d-flex p-2\">\r\n                    <div class=\"d-flex\">\r\n");
#nullable restore
#line 15 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                         if (comment.User.Image == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b588dde504019dad5971863f15c31e581d0b14cd5502", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b588dde504019dad5971863f15c31e581d0b14cd6996", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 889, "~/Attachments/Images/", 889, 21, true);
#nullable restore
#line 21 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
AddHtmlAttributeValue("", 910, comment.User.Image, 910, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"d-flex flex-column\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1068, "\"", 1104, 2);
            WriteAttributeValue("", 1075, "/User/Profile/", 1075, 14, true);
#nullable restore
#line 24 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
WriteAttributeValue("", 1089, comment.UserId, 1089, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h6 class=\"mb-0\">");
#nullable restore
#line 24 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                                                Write(comment.User.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6></a>\r\n                            <span class=\"card-text text-nowrap\">\r\n                                <small class=\"text-success\">\r\n                                    <i class=\"far fa-clock\"></i>\r\n");
#nullable restore
#line 28 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                     if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalHours) > 23)
                                    {
                                        if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalDays) == 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 32 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalDays);

#line default
#line hidden
#nullable disable
            WriteLiteral(" day ago</small>\r\n");
#nullable restore
#line 33 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 36 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalDays);

#line default
#line hidden
#nullable disable
            WriteLiteral(" days ago</small>\r\n");
#nullable restore
#line 37 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }

                                    }
                                    else if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalMinutes) > 59)
                                    {
                                        if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalHours) == 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 44 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hour ago</small>\r\n");
#nullable restore
#line 45 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 48 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hours ago</small>\r\n");
#nullable restore
#line 49 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                    }
                                    else
                                    {
                                        if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalMinutes) == 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> Just Now </small>\r\n");
#nullable restore
#line 56 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                        else if (((int)DateTime.Now.Subtract(comment.CreatedAt).TotalMinutes) == 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 59 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalMinutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minute ago</small>\r\n");
#nullable restore
#line 60 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <small> ");
#nullable restore
#line 63 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                Write((int)DateTime.Now.Subtract(comment.CreatedAt).TotalMinutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minutes ago</small>\r\n");
#nullable restore
#line 64 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </small>\r\n                            </span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"commented bg-light p-2 mx-2\">\r\n                        <p class=\"text-break\"> ");
#nullable restore
#line 71 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                          Write(comment.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    </div>\r\n                </div>\r\n                <div>\r\n");
#nullable restore
#line 75 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                     if (comment.UserId == int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("id", " id=\"", 4445, "\"", 4483, 2);
            WriteAttributeValue("", 4450, "delete-comment-", 4450, 15, true);
#nullable restore
#line 77 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
WriteAttributeValue("", 4465, comment.CommentId, 4465, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-trash-alt\"></i></a>\r\n");
#nullable restore
#line 78 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <script>\r\n                    $(\"#delete-comment-");
#nullable restore
#line 81 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                  Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").click(function () {\r\n                        let id = ");
#nullable restore
#line 82 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                            Write(comment.PostId);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                        let commentSectionId = \"#comment-section-\"+id;\r\n                        $.get(\"/User/DeleteComment\", { id: \'");
#nullable restore
#line 84 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
                                                       Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' }, function () {
                            /*alert(""Comment successfully deleted ^_^"");*/
                            $(commentSectionId).load(""/User/LoadComment/"" + id);
                        });
                    });
                </script>
            </div>
        </div>
    </div>
");
#nullable restore
#line 93 "C:\Users\Haleem\source\repos\Itians\Itians\Views\User\LoadComment.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
