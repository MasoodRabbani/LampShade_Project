#pragma checksum "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2499cb51df4566a9f391ee2199dbd64c570c2e9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServicesHost.Pages.Pages_Search), @"mvc.1.0.razor-page", @"/Pages/Search.cshtml")]
namespace ServicesHost.Pages
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
#line 1 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\_ViewImports.cshtml"
using ServicesHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2499cb51df4566a9f391ee2199dbd64c570c2e9f", @"/Pages/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b0d6fb725f7721dd7f2ce8071bf40915ede4770", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Search : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
  
    ViewData["Title"] = "نتیجه جستجو";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  breadcrumb wrpapper  =======-->
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <!--=======  breadcrumb content  =======-->
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">نتیجه ی جستجو : ");
#nullable restore
#line 14 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                         Write(Model.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
            WriteLiteral(@"                    </div>
                    <!--=======  End of breadcrumb content  =======-->
                </div>
                <!--=======  End of breadcrumb wrpapper  =======-->
            </div>
        </div>
    </div>
</div>
<!--====================  End of breadcrumb area  ====================-->
<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  shop page wrapper  =======-->
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">
");
            WriteLiteral(@"
                            <div class=""col-lg-12"">
                                <!--=======  shop page content  =======-->
                                <div class=""shop-page-content"">

                                    <div class=""row shop-product-wrap grid three-column"">
");
#nullable restore
#line 75 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                         foreach (var item in Model.Products)
                                       {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                           <div class=""col-12 col-lg-4 col-md-4 col-sm-6"">
                                            <!--=======  product grid view  =======-->
                                            <div class=""single-grid-product grid-view-product"">
                                                <div class=""single-grid-product__image"">
                                                    <div class=""single-grid-product__label"">
");
#nullable restore
#line 82 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                         if (item.HasDiscount)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"sale\">-");
#nullable restore
#line 84 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                       Write(item.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 85 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </div>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2499cb51df4566a9f391ee2199dbd64c570c2e9f8030", async() => {
                WriteLiteral("\r\n                                                        <img");
                BeginWriteAttribute("src", " src=\"", 5010, "\"", 5029, 1);
#nullable restore
#line 89 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
WriteAttributeValue("", 5016, item.Picture, 5016, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", "\r\n                                                            alt=\"", 5048, "\"", 5131, 1);
#nullable restore
#line 90 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
WriteAttributeValue("", 5115, item.PictureAlt, 5115, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 5132, "\"", 5158, 1);
#nullable restore
#line 90 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
WriteAttributeValue("", 5140, item.PictureTitle, 5140, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                             WriteLiteral(item.Sluge);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                                                </div>
                                                <div class=""single-grid-product__content"">
                                                    <div class=""single-grid-product__category-rating"">
                                                        <span class=""category"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2499cb51df4566a9f391ee2199dbd64c570c2e9f12039", async() => {
#nullable restore
#line 97 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                                                        Write(item.Category);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                             WriteLiteral(item.CategorySlug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                        </span>
                                                        <span class=""rating"">
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star-outline""></i>
                                                        </span>
                                                    </div>

                                                    <h3 class=""single-grid-product__title"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2499cb51df4566a9f391ee2199dbd64c570c2e9f15515", async() => {
#nullable restore
#line 109 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </h3>\r\n                                                    <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 112 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                         if (item.HasDiscount)
                                                       {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                           <span class=\"discounted-price\">");
#nullable restore
#line 114 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                     Write(item.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> \r\n                                                           <span class=\"main-price discounted\">");
#nullable restore
#line 115 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                          Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 116 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                       }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                           <span class=\"main-price\">");
#nullable restore
#line 117 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 118 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </p>\r\n");
#nullable restore
#line 120 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                     if (item.HasDiscount)
                                                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 122 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                                                              Write(item.DiscountExpireDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
#nullable restore
#line 123 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                                       
                                                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </div>\r\n                                            </div>\r\n                                            <!--=======  End of product grid view  =======-->\r\n\r\n                                        </div>\n");
#nullable restore
#line 130 "C:\Users\MrClike\Desktop\New folder\MasoodRabbani\LampShade_Project\LampShade\ServicesHost\Pages\Search.cshtml"
                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </div>

                                </div>

                                <!--=======  pagination area =======-->
                                <div class=""pagination-area"">
                                    <div class=""pagination-area__left"">
                                        Showing 1 to 9 of 11 (2 Pages)
                                    </div>
                                    <div class=""pagination-area__right"">
                                        <ul class=""pagination-section"">
                                            <li>
                                                <a class=""active"" href=""#"">1</a>
                                            </li>
                                            <li>
                                                <a href=""#"">2</a>
                                            </li>
                                        </ul>
                                    </div>
                      ");
            WriteLiteral(@"          </div>
                                <!--=======  End of pagination area  =======-->
                                <!--=======  End of shop page content  =======-->
                            </div>
                        </div>
                    </div>
                </div>
                <!--=======  End of shop page wrapper  =======-->
            </div>
        </div>
    </div>
</div>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServicesHost.Pages.SearchModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServicesHost.Pages.SearchModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServicesHost.Pages.SearchModel>)PageContext?.ViewData;
        public ServicesHost.Pages.SearchModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591