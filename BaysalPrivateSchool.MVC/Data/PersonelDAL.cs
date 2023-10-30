using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class PersonelDAL
    {
        public static async Task<List<TeachersWithDepartmentViewModel>> GetTeachersWithDepartment()
        {
            Root<List<TeachersWithDepartmentViewModel>> rootTeachersWithDepartment = new Root<List<TeachersWithDepartmentViewModel>>();
            //var schoolInfo = new SchoolInfoViewModel();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getTeachersWithDepartment");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootTeachersWithDepartment = JsonSerializer.Deserialize<Root<List<TeachersWithDepartmentViewModel>>>(contentResponse);
                    
                }
                else
                {
                    rootTeachersWithDepartment = null;
                }
            }
            return rootTeachersWithDepartment.Data;
        }
    }
}