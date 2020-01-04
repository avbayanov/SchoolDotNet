using System.Web.Mvc;

namespace Phonebook.Controllers
{
    public class PhonebookController : Controller
    {
        // GET: Phonebook
        public ActionResult Index()
        {
            return View();
        }
    }
}