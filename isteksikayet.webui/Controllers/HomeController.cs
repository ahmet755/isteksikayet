using isteksikayet.Business.Abstract;
using isteksikayet.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace isteksikayet.webui.Controllers
{
    public class HomeController : Controller
    {
        private IComplaintService _Complaint;
        private IDepartmentService _Department;
        public HomeController(IComplaintService Complaint, IDepartmentService Department)
        {
            _Complaint = Complaint;
            _Department = Department;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Comlaint List
        public IActionResult ComplaintList()
        {
            return View(_Complaint.GetComplaintDepartment());
        }
        //Complaint Add
        [HttpGet]
        public IActionResult ComplaintAdd()
        {
            ViewBag.Department = new SelectList(_Department.GetAll(), "Id", "Name");
            return View(new Complaint { });
        }
        [HttpPost]
        public async Task<IActionResult> ComplaintAdd(Complaint T,IFormFile File)
        {
            if(File == null)
            {
                _Complaint.Create(T);
                return RedirectToAction("index");
            }
            var random = $"{DateTime.Now.Ticks}{Path.GetExtension(File.FileName)}";
            T.FileUrl = random;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", random);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await File.CopyToAsync(stream);
            }
            _Complaint.Create(T);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult ComplaintUpdate(int id)
        {
            ViewBag.Department = new SelectList(_Department.GetAll(), "Id", "Name");
            return View(_Complaint.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> ComplaintUpdate(Complaint T, IFormFile File)
        {
            if (File == null)
            {
                _Complaint.Update(T);
                return RedirectToAction("ComplaintList");
            }
            var random = $"{DateTime.Now.Ticks}{Path.GetExtension(File.FileName)}";
            T.FileUrl = random;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", random);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await File.CopyToAsync(stream);
            }
            _Complaint.Update(T);
            return RedirectToAction("ComplaintList");
        }
        [HttpGet]
        public IActionResult ComplaintDelete(int id)
        {
            if(id == null)
            {
                return RedirectToAction("ComplaintList");
            }
            var Complaint = _Complaint.GetById(id);
            _Complaint.Delete(Complaint);
            return RedirectToAction("ComplaintList");
        }
        [HttpGet]
        public IActionResult ComplaintDetails(int id)
        {
            return View(_Complaint.GetComlaintDepartById(id));
        }
        public IActionResult AprovedComplaint()
        {
            var Complaint = _Complaint.GetComplaintDepartment();
            return View(Complaint);
        }

    }
}
