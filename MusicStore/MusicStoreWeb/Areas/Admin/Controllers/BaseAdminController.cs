using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MusicStoreWeb.Infrastructure.Common.WebConstants;


namespace MusicStoreWeb.Areas.Admin.Controllers
{
    [Area(AdminArea)]
    [Authorize(Roles = AdministratingRole)]
    public class BaseAdminController : Controller
    {
    }
}
