using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class StudentClubDAL
    {
        public static async Task<List<StudentClubViewModel>> GetStudentClubsWithStudentsAndTeachers()
        {
            Root<List<StudentClubViewModel>> rootStudentClubs = new Root<List<StudentClubViewModel>>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getStudentClubsWithStudentsAndTeachers");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootStudentClubs = JsonSerializer.Deserialize<Root<List<StudentClubViewModel>>>(contentResponse);

                }
                else
                {
                    rootStudentClubs = null;
                }
            }
            return rootStudentClubs.Data;
        }
        public static async Task<List<StudentClubsNewsViewModel>> GetStudentClubsWithNews()
        {
            Root<List<StudentClubsNewsViewModel>> rootStudentClubsNews = new Root<List<StudentClubsNewsViewModel>>();
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getStudentClubsWithNews");
                if(response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootStudentClubsNews = JsonSerializer.Deserialize<Root<List<StudentClubsNewsViewModel>>>(contentResponse);
                }
                else
                {
                    rootStudentClubsNews = new Root<List<StudentClubsNewsViewModel>>();
                }
            }

            return rootStudentClubsNews.Data;
        }
    }
}