using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Service
{
    public class InterviewStatusServiceAsync : IInterviewStatusServiceAsync
    {
        private readonly IInterviewStatusRepositoryAsync interviewStatusRepositoryAsync;

        public InterviewStatusServiceAsync(IInterviewStatusRepositoryAsync _interviewStatusRepositoryAsync)
        {
            interviewStatusRepositoryAsync = _interviewStatusRepositoryAsync;
        }
        public Task<int> AddInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewStatusRepositoryAsync.InsertAsync(interviewStatus);
        }

        public Task<int> DeleteInterviewStatusAsync(int id)
        {
            return interviewStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewStatusResponseModel>> GetAllInterviewStatusAsync()
        {
            var result = await interviewStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewStatusResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive
                });
            }
            return null;

        }

        public async Task<InterviewStatusResponseModel> GetInterviewStatusByIdAsync(int id)
        {
            var result = await interviewStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewStatusRepositoryAsync.UpdateAsync(interviewStatus);
        }
    }
}
