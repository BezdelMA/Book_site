#pragma checksum "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4307247e4d6dcfbea80da085788ed4904643aef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PersonalAccount_DetailsOrder), @"mvc.1.0.view", @"/Views/PersonalAccount/DetailsOrder.cshtml")]
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
#line 1 "D:\Обучение\C#\Book_site\book-site\Views\_ViewImports.cshtml"
using book_site.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Обучение\C#\Book_site\book-site\Views\_ViewImports.cshtml"
using book_site.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4307247e4d6dcfbea80da085788ed4904643aef", @"/Views/PersonalAccount/DetailsOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ee052529db1176371dd07fb861da2f292b9d732", @"/Views/_ViewImports.cshtml")]
    public class Views_PersonalAccount_DetailsOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<book_site.ViewModel.DetailOrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4>");
#nullable restore
#line 6 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
<div>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    № п/п
                </th>
                <th>
                    Наименование
                </th>
                <th></th>
                <th>
                    Автор
                </th>
                <th>
                    Издательство
                </th>
                <th>
                    Цена
                </th>
                <th>
                    Количество
                </th>
                <th>
                    Стоимость
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 36 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
              
                int i = 1;
                foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 42 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameBook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"image\">\r\n                            <img height=\"100\"");
            BeginWriteAttribute("src", " src=\"", 1248, "\"", 1269, 2);
            WriteAttributeValue("", 1254, "../", 1254, 3, true);
#nullable restore
#line 48 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
WriteAttributeValue("", 1257, item.ImgURL, 1257, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1270, "\"", 1276, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PublishingHouse));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Counter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 63 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AllPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 66 "D:\Обучение\C#\Book_site\book-site\Views\PersonalAccount\DetailsOrder.cshtml"
                    i += 1;
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4307247e4d6dcfbea80da085788ed4904643aef8750", async() => {
                WriteLiteral("Назад к списку заказов");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<book_site.ViewModel.DetailOrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591