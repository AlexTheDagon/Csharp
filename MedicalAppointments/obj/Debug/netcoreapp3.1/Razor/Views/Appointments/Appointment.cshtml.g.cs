#pragma checksum "D:\GitHub\Csharp\MedicalAppointments\Views\Appointments\Appointment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f8a0f4bcf7288cfc069867bf02ac71db8c6ce30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointments_Appointment), @"mvc.1.0.view", @"/Views/Appointments/Appointment.cshtml")]
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
#line 1 "D:\GitHub\Csharp\MedicalAppointments\Views\_ViewImports.cshtml"
using MedicalAppointments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\Csharp\MedicalAppointments\Views\_ViewImports.cshtml"
using MedicalAppointments.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f8a0f4bcf7288cfc069867bf02ac71db8c6ce30", @"/Views/Appointments/Appointment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41ae2b42593e48fff67bd3df52297c0d6d4a7cc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointments_Appointment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\GitHub\Csharp\MedicalAppointments\Views\Appointments\Appointment.cshtml"
  
    ViewData["Title"] = "Appointment page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""border-top border-bottom text-muted  text-center"">
    <h1 class=""display-4"">Make an appointment</h1>
</div>
<div>
    <p>

    </p>
</div>
<div class=""border-top border-bottom justify-content-between"">
    <ul class=""navbar-nav flex-grow-1"">

        <li class=""nav-item dropdown"">
            <p style=""color:black"" class=""dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
              Type of appointment
            </p>

        <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
            <p class=""dropdown-item"" role=""button""> General Medicine</p>
            <p class=""dropdown-item"" role=""button""> Pediatrics</p>
            <p class=""dropdown-item"" role=""button""> Dermatology</p>
        </div>
        </li>

    </ul>
</div>
<div>
    <p></p>
    <p></p>
    <p></p>
</div>
<div class=""border-top border-bottom justify-content-between"">
    <ul class=""navbar-nav flex-grow-1"">");
            WriteLiteral(@"

        <li class=""nav-item dropdown"">
            <p style=""color:black"" class=""dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                Date
            </p>

            <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
                
            </div>
        </li>

    </ul>
</div>
<div>
    <p></p>
    <p></p>
    <p></p>
</div>
<div class=""border-top border-bottom justify-content-between"">
    <ul class=""navbar-nav flex-grow-1"">

        <li class=""nav-item dropdown"">
            <p style=""color:black"" class=""dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                Doctor
            </p>

            <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
                
            </div>
        </li>

    </ul>
</div>
<div class=""text-right"">
    <p></p>
    <p></p>
    <");
            WriteLiteral("p></p>\r\n    <button style=\"border:2px solid #009999; background-color:white; color:black\" class=\"btn btn-default\" type=\"submit\">Create</button>\r\n</div>\r\n\r\n");
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
