using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class JobRequirementController : Controller
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;

        public JobRequirementController(
            IJobRequirementServiceAsync _jobRequirementServiceAsync, 
            IJobCategoryServiceAsync _jobCategoryServiceAsync
            )
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
            jobCategoryServiceAsync = _jobCategoryServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var jobRequirementCollection = await jobRequirementServiceAsync.GetAllJobRequirementsAsync();
            return View(jobRequirementCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.JobCategoryList = new SelectList(await jobCategoryServiceAsync.GetAllJobCategoriesAsync(),
                "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.JobCategoryList = new SelectList(await jobCategoryServiceAsync.GetAllJobCategoriesAsync(),
                "Id", "Name");
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobRequirementRequestModel model)
        {
            try
            {
                await jobRequirementServiceAsync.UpdateJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobRequirementResponseModel model)
        {
            await jobRequirementServiceAsync.DeleteJobRequirementAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
