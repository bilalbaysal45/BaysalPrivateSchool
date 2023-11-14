using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.Extensions.Localization;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class StudentDAL
    {
        public static async Task<List<StudentViewModel>> GetAll()
        {
            Root<List<StudentViewModel>> rootStudents = new Root<List<StudentViewModel>>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getStudents");
                if(response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootStudents = JsonSerializer.Deserialize<Root<List<StudentViewModel>>>(contentResponse);
                    return rootStudents.Data;
                }
            }
            return new List<StudentViewModel>();
        }
        public static async Task<UpdateStudentViewModel> GetById(int id)
        {
            using(var httpClient = new HttpClient())
            {
                Root<UpdateStudentViewModel> rootStudent = new Root<UpdateStudentViewModel>();
                var response = await httpClient.GetAsync($"http://localhost:5156/getStudent/{id}");
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootStudent = JsonSerializer.Deserialize<Root<UpdateStudentViewModel>>(contentResponse);
                    return rootStudent.Data;
                }
            }
            return null;
        }
        public static async Task<AddStudentViewModel> Create(AddStudentViewModel addStudent)
        {
            Root<AddStudentViewModel> rootAddStudent = new Root<AddStudentViewModel>();
            using(var httpClient = new HttpClient())
            {
                var content = JsonSerializer.Serialize(addStudent);
                StringContent stringContent = new StringContent(content,Encoding.UTF8,"application/json");
                var response = await httpClient.PostAsync("http://localhost:5156/addStudent", stringContent);
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootAddStudent.Data = JsonSerializer.Deserialize<AddStudentViewModel>(contentResponse);
                    return rootAddStudent.Data;
                }
            }
            return null;
        }
        public static async Task<UpdateStudentViewModel> Update(UpdateStudentViewModel updateStudent)
        {

            using(var httpClient = new HttpClient())
            {
                var rootUpdatedStudent = new Root<UpdateStudentViewModel>();
                var content = JsonSerializer.Serialize(updateStudent);
                StringContent stringContent = new StringContent(content,Encoding.UTF8,"application/json");
                var response = await httpClient.PutAsync("http://localhost:5156/updateStudent", stringContent);
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootUpdatedStudent = JsonSerializer.Deserialize<Root<UpdateStudentViewModel>>(contentResponse);
                    return rootUpdatedStudent.Data;
                }
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5156/deleteStudent/{id}");
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<bool>(contentResponse);
                }
            }
            return false;
        }
    }
}