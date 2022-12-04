using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GHGHGym.Areas.Admin.Data.AdminConstants;

namespace GHGHGym.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route(RouteName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
