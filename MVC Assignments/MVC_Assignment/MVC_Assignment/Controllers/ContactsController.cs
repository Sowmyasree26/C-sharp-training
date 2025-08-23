using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_Assignment.Models;
using MVC_Assignment.Repositories; 

namespace MVC_Assignment.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactsController()
        {
            _repository = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
