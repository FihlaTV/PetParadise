namespace PetParadise.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using PetParadise.Common;
    using PetParadise.Data;
    using PetParadise.Web.Controllers;

    [Authorize(Roles=GlobalConstants.AdminRole)]
    public class AdminController : BaseController
    {
        public AdminController(IPetParadiseData data)
            : base(data)
        {
        }
    }
}