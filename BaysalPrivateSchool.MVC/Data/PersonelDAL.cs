using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
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
                var serializeLogin = JsonSerializer.Serialize(loginCredentials);
                StringContent stringContent = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
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

        public static async Task<AddTeacherViewModel> Create(AddTeacherViewModel newTeacher)
        {
            Root<AddTeacherViewModel> rootAddedTeacher = new Root<AddTeacherViewModel>();
            using (var httpClient = new HttpClient())
            {
                var serializeNewTeacher = JsonSerializer.Serialize(newTeacher);
                StringContent stringContent = new StringContent(serializeNewTeacher,Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5156/addTeacher",stringContent);
                if(response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootAddedTeacher = JsonSerializer.Deserialize<Root<AddTeacherViewModel>>(contentResponse);
                    return rootAddedTeacher.Data;
                }
            }
            return null;
        }
        public static async Task<UpdateTeacherViewModel> Update(UpdateTeacherViewModel updateTeacher)
        {
            var rootUpdatedTeacher = new Root<UpdateTeacherViewModel>();
            using(var httpClient = new HttpClient())
            {
                var serializeUpdateTeacher = JsonSerializer.Serialize(updateTeacher);
                StringContent stringContent = new StringContent(serializeUpdateTeacher,Encoding.UTF8,"application/json");
                var response = await httpClient.PutAsync("http://localhost:5156/updateTeacher", stringContent);
                if(response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootUpdatedTeacher = JsonSerializer.Deserialize<Root<UpdateTeacherViewModel>>(contentResponse);
                    return rootUpdatedTeacher.Data;
                }
            }
            return null;
        }
        public static async Task<UpdateTeacherViewModel> GetById(int id)
        {
            var rootTeacher = new Root<UpdateTeacherViewModel>();
            using(var httpClient = new HttpClient())
            {
                // var serializeId = JsonSerializer.Serialize(id);
                // StringContent stringContent = new StringContent(serializeId,Encoding.UTF8,"application/json");
                var response = await httpClient.GetAsync($"http://localhost:5156/getTeacher/{id}");
                if(response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootTeacher = JsonSerializer.Deserialize<Root<UpdateTeacherViewModel>>(contentResponse);
                    return rootTeacher.Data;
                }
            }
            return null;
        }
    }
}