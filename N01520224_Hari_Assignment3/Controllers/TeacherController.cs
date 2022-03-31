using N01520224_Hari_Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N01520224_Hari_Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        // NameKey is the value which we will receive here after submiting the Search form
        [Route("Teacher/List/{NameKey}")]
        public ActionResult List(string NameKey)
        {

            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(NameKey);
            return View(Teachers);
        }

        //GET: Teacher/Show/{id}
        [Route("Teacher/Show/{id}")]
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            List<string> TeacherClasses = controller.FindClasses(id);
            return View(TeacherClasses);
        }
    }
}