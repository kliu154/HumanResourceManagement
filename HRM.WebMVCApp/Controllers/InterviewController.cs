using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public InterviewController(
            IInterviewServiceAsync _interviewServiceAsync,
            ISubmissionServiceAsync _submissionServiceAsync,
            IInterviewTypeServiceAsync _interviewTypeServiceAsync,
            IInterviewStatusServiceAsync _interviewStatusServiceAsync,
            IEmployeeServiceAsync _employeeServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
            submissionServiceAsync = _submissionServiceAsync;
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
            employeeServiceAsync= _employeeServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var interviewCollection = await interviewServiceAsync.GetAllInterviewsAsync();
            return View(interviewCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllSubmissionsAsync(),
                "Id", "CandidateId");
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllInterviewTypesAsync(),
                "Id", "Title");
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllInterviewStatusAsync(),
                "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(),
                "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewServiceAsync.AddInterviewAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllSubmissionsAsync(),
                "Id", "CandidateId");
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllInterviewTypesAsync(),
                "Id", "Title");
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllInterviewStatusAsync(),
                "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(),
                "Id", "FirstName");
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InterviewRequestModel model)
        {
            try
            {
                await interviewServiceAsync.UpdateInterviewAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewResponseModel model)
        {
            await interviewServiceAsync.DeleteInterviewAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
