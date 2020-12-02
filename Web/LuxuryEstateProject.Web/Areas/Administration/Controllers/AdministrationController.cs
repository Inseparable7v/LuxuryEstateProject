namespace LuxuryEstateProject.Web.Areas.Administration.Controllers
{
    using LuxuryEstateProject.Common;
    using LuxuryEstateProject.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
