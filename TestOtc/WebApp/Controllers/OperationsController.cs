using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        // GET: Operations
        public ActionResult Index()
        {
            return View();
        }
    }
}