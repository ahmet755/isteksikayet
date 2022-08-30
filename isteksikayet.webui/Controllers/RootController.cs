using isteksikayet.Business.Abstract;
using isteksikayet.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace isteksikayet.webui.Controllers
{
    public class RootController : Controller
    {
        private IComplaintService _Complaint;
        private IDepartmentService _Department;
        public RootController(IComplaintService Complaint, IDepartmentService Department)
        {

            _Complaint = Complaint;
            _Department = Department;

        }
        public IActionResult Index()
        {
            return View();
        
        }

    }
}
