using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployee> empList;
            HttpResponseMessage respose = GlobalVariables.webApiClient.GetAsync("Employee").Result;
            empList = respose.Content.ReadAsAsync<IEnumerable<mvcEmployee>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if(id==0)
                return View(new mvcEmployee());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Employee/"+id).Result;
                return View(response.Content.ReadAsAsync<mvcEmployee>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployee emp)
        {
            if (emp.EmployeeId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Employee/"+emp.EmployeeId, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Employee/"+id).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}