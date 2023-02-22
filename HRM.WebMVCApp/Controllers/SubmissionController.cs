using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly ICandidateServiceAsync candidateServiceAsync;
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public SubmissionController(
            ISubmissionServiceAsync _submissionServiceAsync,
            ICandidateServiceAsync _candidateServiceAsync,
            IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
            candidateServiceAsync = _candidateServiceAsync;
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllSubmissionsAsync();
            return View(submissionCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CandidateList = new SelectList(await candidateServiceAsync.GetAllCandidatesAsync(),
                "Id", "FirstName");
            ViewBag.JobRequirementList = new SelectList(await jobRequirementServiceAsync.GetAllJobRequirementsAsync(),
                "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissionAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CandidateList = new SelectList(await candidateServiceAsync.GetAllCandidatesAsync(),
                "Id", "FirstName");
            ViewBag.JobRequirementList = new SelectList(await jobRequirementServiceAsync.GetAllJobRequirementsAsync(),
                "Id", "Title");
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubmissionRequestModel model)
        {
            try
            {
                await submissionServiceAsync.UpdateSubmissionAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubmissionResponseModel model)
        {
            await submissionServiceAsync.DeleteSubmissionAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
