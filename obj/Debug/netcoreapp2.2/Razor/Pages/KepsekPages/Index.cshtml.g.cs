#pragma checksum "D:\Algostudio\DataSekolahWithIdentity\Pages\KepsekPages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d86939cacc571b6fc5035fc9850f951fad445cb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_KepsekPages_Index), @"mvc.1.0.razor-page", @"/Pages/KepsekPages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/KepsekPages/Index.cshtml", typeof(AspNetCore.Pages_KepsekPages_Index), null)]
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
#line 1 "D:\Algostudio\DataSekolahWithIdentity\Pages\_ViewImports.cshtml"
using DataSekolahWithIdentity;

#line default
#line hidden
#line 2 "D:\Algostudio\DataSekolahWithIdentity\Pages\_ViewImports.cshtml"
using DataSekolahWithIdentity.Models;

#line default
#line hidden
#line 4 "D:\Algostudio\DataSekolahWithIdentity\Pages\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d86939cacc571b6fc5035fc9850f951fad445cb0", @"/Pages/KepsekPages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79483abcb1f7bd8ee2927420ba574806b1bc8c15", @"/Pages/_ViewImports.cshtml")]
    public class Pages_KepsekPages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Algostudio\DataSekolahWithIdentity\Pages\KepsekPages\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_DevExtremeLayout";

#line default
#line hidden
            BeginContext(146, 20, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            EndContext();
            BeginContext(168, 404, false);
#line 11 "D:\Algostudio\DataSekolahWithIdentity\Pages\KepsekPages\Index.cshtml"
Write(Html.DevExtreme().Chart()
    .ID("chart")
    .DataSource("/Kepsek/GetData")
    .Series(s => s
        .Add()
        .Type(SeriesType.Bar)
    )
    .Legend(l => l.Visible(false))
    .ArgumentAxis(a => a
        .TickInterval(10)
        .Label(l => l
            .Format(f => f
                .Type(Format.Decimal)
            )
        )
    )
    .Title("Data Siswa Tiap Kelas")
);

#line default
#line hidden
            EndContext();
            BeginContext(573, 811, true);
            WriteLiteral(@"

<script>

    $(document).ready(function () {

        var xhr = new XMLHttpRequest();
        var url = ""/Kepsek/GetData"";
        xhr.onreadystatechange = function () {
            //console.log(this.responseText);
            var halo = JSON.parse(this.responseText);
            console.log(halo);
        };
        xhr.open(""GET"", url, true);
        xhr.send();

    }); 

    var populationData = [{
        arg: 1950,
        val: 100
    }, {
        arg: 1960,
        val: 200
    }, {
        arg: 1970,
        val: 250
    }, {
        arg: 1980,
        val: 150
    }, {
        arg: 1990,
        val: 300
    }, {
        arg: 2000,
        val: 500
    }, {
        arg: 2010,
        val: 400
        }];
    console.log(populationData);
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSekolahWithIdentity.Pages.KepsekPages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DataSekolahWithIdentity.Pages.KepsekPages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DataSekolahWithIdentity.Pages.KepsekPages.IndexModel>)PageContext?.ViewData;
        public DataSekolahWithIdentity.Pages.KepsekPages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591