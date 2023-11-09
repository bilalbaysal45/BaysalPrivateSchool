using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class DepartmentDAL
    {
        public async static Task<List<DepartmentViewModel>> GetAll()
        {
            var rootDepartments = new Root<List<DepartmentViewModel>>();

            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getDepartments");
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rootDepartments = JsonSerializer.Deserialize<Root<List<DepartmentViewModel>>>(content);
                }
                else
                {
                    rootDepartments = new Root<List<DepartmentViewModel>>();
                }
                return rootDepartments.Data;
            }
        }
    }
}