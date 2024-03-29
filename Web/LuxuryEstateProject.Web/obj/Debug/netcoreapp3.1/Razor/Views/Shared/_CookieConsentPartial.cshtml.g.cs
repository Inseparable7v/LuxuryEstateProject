#pragma checksum "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e636a1e01bcdcb6d98f623f4a716052daa9525fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CookieConsentPartial), @"mvc.1.0.view", @"/Views/Shared/_CookieConsentPartial.cshtml")]
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
#line 1 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\_ViewImports.cshtml"
using LuxuryEstateProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\_ViewImports.cshtml"
using LuxuryEstateProject.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e636a1e01bcdcb6d98f623f4a716052daa9525fe", @"/Views/Shared/_CookieConsentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7621920ed7501ee0024f5e6e2888f6a62e815788", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__CookieConsentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml"
  
    var consentFeature = this.Context.Features.Get<ITrackingConsentFeature>();
    var showBanner = !consentFeature?.CanTrack ?? false;
    var cookieString = consentFeature?.CreateConsentCookie();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml"
 if (showBanner)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div id=""cookieConsent"" class=""alert alert-info alert-dismissible fade show"" role=""alert"">
        We use cookies to understand how you use our site and to improve your experience. 
        <button type=""button"" class=""accept-policy close color-b"" data-dismiss=""alert"" aria-label=""Close"" data-cookie-string=""");
#nullable restore
#line (13,128)-(13,140) 6 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml"
Write(cookieString);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
            <span aria-hidden=""true"">Accept</span>
        </button>
    </div>
    <script>
        (function () {
            var button = document.querySelector(""#cookieConsent button[data-cookie-string]"");
            button.addEventListener(""click"", function () {
                document.cookie = button.dataset.cookieString;
            }, false);
        })();
    </script>
");
#nullable restore
#line 25 "E:\Git-repos\LuxuryEstateProject\Web\LuxuryEstateProject.Web\Views\Shared\_CookieConsentPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
