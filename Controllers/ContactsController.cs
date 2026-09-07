using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly ILogger<ContactsController> _logger; //2.parametreyi de dahil ettik.

        public ContactsController(IContactRepository repo, ILogger<ContactsController> logger) //Bu nesneye ihtiyaç olduğu anda new leme işlemi yapıyor.
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items = _repo.GetAll();
            return View(items.ToList());
        }
        public IActionResult Details(int id)
        {
            var contact=_repo.GetById(id);
            if(contact is null)
                return NotFoundView();
            ViewData["Title"] = "Kişi Güncelle";
            return View(contact);
        }

        private IActionResult NotFoundView()
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(int id)
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
