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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }
        public Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                SSN = model.SSN,
                Phone = model.Phone,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeTypeId = model.EmployeeTypeId,
                EmployeeStatusId = model.EmployeeStatusId
            };
            return employeeRepositoryAsync.InsertAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(int id)
        {
            return employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailId = x.EmailId,
                    SSN = x.SSN,
                    Phone = x.Phone,
                    EmployeeRoleId = x.EmployeeRoleId,
                    EmployeeTypeId = x.EmployeeTypeId,
                    EmployeeStatusId = x.EmployeeStatusId
                });
            }
            return null;

        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailId = result.EmailId,
                    SSN = result.SSN,
                    Phone = result.Phone,
                    EmployeeRoleId = result.EmployeeRoleId,
                    EmployeeTypeId = result.EmployeeTypeId,
                    EmployeeStatusId = result.EmployeeStatusId
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                SSN = model.SSN,
                Phone = model.Phone,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeTypeId = model.EmployeeTypeId,
                EmployeeStatusId = model.EmployeeStatusId
            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
