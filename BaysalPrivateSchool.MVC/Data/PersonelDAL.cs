using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static async Task<bool> Login(LoginViewModel loginCredentials)
        {
            Root<bool> rootLogin = new Root<bool>();

            using (var httpClient = new HttpClient())
            {
                var serializeProduct = JsonSerializer.Serialize(loginCredentials);
                StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5156/login", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootLogin = JsonSerializer.Deserialize<Root<bool>>(contentResponse);
                    if(rootLogin.Data)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}