using EmployeeManagerApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagerFrontend.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class EmployeeManagerFrontendController : ControllerBase
    {
        private HttpClient _client;

        public EmployeeManagerFrontendController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44370/");
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<Employee>> GetAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("get");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Employee> employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();

                    return employees;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        [HttpPost]
        [Route("post")]
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            string json = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync("post", content);
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                    return employee;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        [HttpPut]
        [Route("put")]
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            string json = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PutAsync("put", content);
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                    return employee;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync("delete/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch
            {
                throw new ApplicationException();
            }
        }
    }
}
