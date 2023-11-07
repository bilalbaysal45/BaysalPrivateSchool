using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class NewsDAL
    {
        public static async Task<NewsViewModel> GetNews(int id)
        {
            Root<NewsViewModel> rootNewsViewModel = new Root<NewsViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5156/getNews/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootNewsViewModel = JsonSerializer.Deserialize<Root<NewsViewModel>>(contentResponse);
                }
                else
                {
                    rootNewsViewModel = new Root<NewsViewModel>();
                }
            }

            return rootNewsViewModel?.Data;
        }
    }
}