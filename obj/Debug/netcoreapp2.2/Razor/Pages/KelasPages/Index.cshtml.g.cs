#pragma checksum "D:\Algostudio\DataSekolahWithIdentity\Pages\KelasPages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "621bfb40e57defe86dd262bf56ebd511c6584473"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_KelasPages_Index), @"mvc.1.0.razor-page", @"/Pages/KelasPages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/KelasPages/Index.cshtml", typeof(AspNetCore.Pages_KelasPages_Index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"621bfb40e57defe86dd262bf56ebd511c6584473", @"/Pages/KelasPages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79483abcb1f7bd8ee2927420ba574806b1bc8c15", @"/Pages/_ViewImports.cshtml")]
    public class Pages_KelasPages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(67, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Algostudio\DataSekolahWithIdentity\Pages\KelasPages\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_DevExtremeLayout";

#line default
#line hidden
            BeginContext(145, 20, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            EndContext();
            BeginContext(167, 718, false);
#line 11 "D:\Algostudio\DataSekolahWithIdentity\Pages\KelasPages\Index.cshtml"
Write(Html.DevExtreme().DataGrid<DataSekolahWithIdentity.Models.Kelas>()
        .DataSource(ds => ds.Mvc()
            .Controller("Kelas")
            .LoadAction("Get")
            .InsertAction("Post")
            .UpdateAction("Put")
            .DeleteAction("Delete")
            .Key("KelasId")
        )
        .RemoteOperations(true)
        .FilterRow(f => f.Visible(true))
    .Columns(columns => {

        //columns.AddFor(m => m.KelasId);

        columns.AddFor(m => m.Tingkat);

        columns.AddFor(m => m.Jurusan);

        columns.AddFor(m => m.WaliKelas);
    })
    .Editing(e => e
        .AllowAdding(true)
        .AllowUpdating(true)
        .AllowDeleting(true)
    )
);

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSekolahWithIdentity.Pages.KelasPages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DataSekolahWithIdentity.Pages.KelasPages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DataSekolahWithIdentity.Pages.KelasPages.IndexModel>)PageContext?.ViewData;
        public DataSekolahWithIdentity.Pages.KelasPages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
