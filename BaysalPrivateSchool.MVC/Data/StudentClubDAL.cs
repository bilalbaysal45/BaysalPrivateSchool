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
        public static async Task<Root<List<StudentClubViewModel>>> GetStudentClubsWithStudentsAndTeachers()
        {
            Root<List<StudentClubViewModel>> rootStudentClubs = new Root<List<StudentClubViewModel>>();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await httpClient.GetAsync("http://localhost:5156/getStudentClubsWithStudentsAndTeachers");
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootStudentClubs = JsonSerializer.Deserialize<Root<List<StudentClubViewModel>>>(contentResponse);
                    }
                    else
                    {
                        rootStudentClubs.Data = null;
                        rootStudentClubs.Error = "Unsuccessfull Connection";
                    }
                }
                catch (System.Exception)
                {
                    rootStudentClubs.Data = null;
                    rootStudentClubs.Error = "Data uncreachable, Check API connection";
                }

            }
            return rootStudentClubs;
        }
        public static async Task<Root<List<StudentClubsNewsViewModel>>> GetStudentClubsWithNews()
        {
            Root<List<StudentClubsNewsViewModel>> rootStudentClubsNews = new Root<List<StudentClubsNewsViewModel>>();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.GetAsync("http://localhost:5156/getStudentClubsWithNews");
                }
                catch (System.Exception)
                {
                    rootStudentClubsNews.Data = new List<StudentClubsNewsViewModel>();
                    rootStudentClubsNews.Error = "Data's unreachable. Check API connection";
                    return rootStudentClubsNews;
                }
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootStudentClubsNews = JsonSerializer.Deserialize<Root<List<StudentClubsNewsViewModel>>>(contentResponse);
                }
                else
                {
                    rootStudentClubsNews.Data = new List<StudentClubsNewsViewModel>();
                    rootStudentClubsNews.Error = "Data's unreachable";
                }
            }

            return rootStudentClubsNews;
        }
        public static async Task<Root<StudentClubsNewsViewModel>> GetStudentClubWithNews(int studentClubId)
        {
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"http://localhost:5156/getStudentClubWithNews/{studentClubId}");
                    if(response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        var studentClubWithNews = JsonSerializer.Deserialize<Root<StudentClubsNewsViewModel>>(contentResponse);
                        return studentClubWithNews;
                    }
                    else
                    {
                        return new Root<StudentClubsNewsViewModel>{Data=null,Error = "Unsuccessfull Request"};
                    }
                }
            }
            catch (System.Exception)
            {
                return new Root<StudentClubsNewsViewModel>{Data = null,Error= "Catched Exception"};
            }
        }
    }
}