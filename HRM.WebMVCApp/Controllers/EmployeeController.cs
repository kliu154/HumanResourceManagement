using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeController(
            IEmployeeServiceAsync _employeeServiceAsync,
            IEmployeeRoleServiceAsync _employeeRoleServiceAsync,
            IEmployeeTypeServiceAsync _employeeTypeServiceAsync,
            IEmployeeStatusServiceAsync _employeeStatusServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var employeeCollection = await employeeServiceAsync.GetAllEmployeesAsync();
            return View(employeeCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllEmployeeRolesAsync(),
                "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllEmployeeTypesAsync(),
                "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllEmployeeStatusAsync(),
                "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllEmployeeRolesAsync(),
                "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllEmployeeTypesAsync(),
                "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllEmployeeStatusAsync(),
                "Id", "Title");
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {
            try
            {
                await employeeServiceAsync.UpdateEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeResponseModel model)
        {
            await employeeServiceAsync.DeleteEmployeeAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
