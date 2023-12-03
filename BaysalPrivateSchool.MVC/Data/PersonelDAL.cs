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
        public static async Task<Root<List<TeachersWithDepartmentViewModel>>> GetTeachersWithDepartment()
        {
            Root<List<TeachersWithDepartmentViewModel>> rootTeachersWithDepartment = new Root<List<TeachersWithDepartmentViewModel>>();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await httpClient.GetAsync("http://localhost:5156/getTeachersWithDepartment");
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootTeachersWithDepartment = JsonSerializer.Deserialize<Root<List<TeachersWithDepartmentViewModel>>>(contentResponse);
                    }
                    else
                    {
                        rootTeachersWithDepartment.Data = null;
                        rootTeachersWithDepartment.Error = "Unsuccessfull Connection";
                    }
                }
                catch (System.Exception)
                {
                    rootTeachersWithDepartment.Data = null;
                    rootTeachersWithDepartment.Error = "Data uncreachable, Check API connection";
                }
            }
            return rootTeachersWithDepartment;
        }

        public static async Task<Root<bool>> Login(LoginViewModel loginCredentials)
        {
            Root<bool> rootLogin = new Root<bool>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var serializeLogin = JsonSerializer.Serialize(loginCredentials);
                    StringContent stringContent = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5156/loginTeacher", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootLogin = JsonSerializer.Deserialize<Root<bool>>(contentResponse);
                        return rootLogin;
                    }
                    else
                    {
                        rootLogin.Data = false;
                        rootLogin.Error = "Login Failed";
                    }
                }
                catch (System.Exception)
                {
                    rootLogin.Data = false;
                    rootLogin.Error = "Data uncreachable, Check API connection";
                }

            }
            return rootLogin;
        }
        public static async Task<Root<TeacherViewModel>> GetTeacher(LoginViewModel login)
        {
            Root<TeacherViewModel> rootTeacher = new Root<TeacherViewModel>();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    var serializeLogin = JsonSerializer.Serialize(login);
                    StringContent stringContent = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync("http://localhost:5156/getTeacherLoginCredentials", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootTeacher = JsonSerializer.Deserialize<Root<TeacherViewModel>>(contentResponse);
                        return rootTeacher;
                    }
                    else
                    {
                        rootTeacher.Data = null;
                        rootTeacher.Error = "Unsuccessfull Connection";
                    }
                }
                catch (System.Exception)
                {
                    rootTeacher.Data = null;
                    rootTeacher.Error = "Data uncreachable, Check API connection";
                }
                
            }
            return rootTeacher;
        }
        public static async Task<AddTeacherViewModel> Create(AddTeacherViewModel newTeacher)
        {
            Root<AddTeacherViewModel> rootAddedTeacher = new Root<AddTeacherViewModel>();
            using (var httpClient = new HttpClient())
            {
                var serializeNewTeacher = JsonSerializer.Serialize(newTeacher);
                StringContent stringContent = new StringContent(serializeNewTeacher, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5156/addTeacher", stringContent);
                if (response.IsSuccessStatusCode)
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
            using (var httpClient = new HttpClient())
            {
                var serializeUpdateTeacher = JsonSerializer.Serialize(updateTeacher);
                StringContent stringContent = new StringContent(serializeUpdateTeacher, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:5156/updateTeacher", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootUpdatedTeacher = JsonSerializer.Deserialize<Root<UpdateTeacherViewModel>>(contentResponse);
                    return rootUpdatedTeacher.Data;
                }
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5156/deleteTeacher/{id}");
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<UpdateTeacherViewModel> GetById(int id)
        {
            var rootTeacher = new Root<UpdateTeacherViewModel>();
            using (var httpClient = new HttpClient())
            {
                // var serializeId = JsonSerializer.Serialize(id);
                // StringContent stringContent = new StringContent(serializeId,Encoding.UTF8,"application/json");
                var response = await httpClient.GetAsync($"http://localhost:5156/getTeacher/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootTeacher = JsonSerializer.Deserialize<Root<UpdateTeacherViewModel>>(contentResponse);
                    return rootTeacher.Data;
                }
            }
            return null;
        }
        public static async Task<TeacherWithClassesViewModel> GetTeacherWithClass(int id)
        {
            var rootTeacher = new Root<TeacherWithClassesViewModel>();
            using (var httpClient = new HttpClient())
            {
                // var serializeId = JsonSerializer.Serialize(id);
                // StringContent stringContent = new StringContent(serializeId,Encoding.UTF8,"application/json");
                var response = await httpClient.GetAsync($"http://localhost:5156/getTeacherWithClassesAndStudents/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootTeacher = JsonSerializer.Deserialize<Root<TeacherWithClassesViewModel>>(contentResponse);
                    return rootTeacher.Data;
                }
            }
            return null;
        }
        public static async Task<Root<StudentClubsNewsViewModel>> GetStudentClubWithNewsByTeacherId(int teacherId)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync($"http://localhost:5156/getStudentClubWithNewsByTeacherId/{teacherId}");
                    if(response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        var rootStudentClubWithNews = JsonSerializer.Deserialize<Root<StudentClubsNewsViewModel>>(contentResponse);
                        return rootStudentClubWithNews;
                    }
                    else
                    {
                        return new Root<StudentClubsNewsViewModel>{Data = null,Error="Unsuccessfull Request"};
                    }
                }
                catch (System.Exception)
                {
                    return new Root<StudentClubsNewsViewModel>{Data = null,Error="Couldn't Reach API"};
                }
            }
        }
    }
}