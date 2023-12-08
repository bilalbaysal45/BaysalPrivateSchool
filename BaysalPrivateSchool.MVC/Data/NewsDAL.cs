using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models.NewsModel;
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
        public static async Task<UpdateNewsViewModel> GetById(int id)
        {
            Root<UpdateNewsViewModel> rootNewsViewModel = new Root<UpdateNewsViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5156/getNews/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootNewsViewModel = JsonSerializer.Deserialize<Root<UpdateNewsViewModel>>(contentResponse);
                }
                else
                {
                    rootNewsViewModel = new Root<UpdateNewsViewModel>();
                }
            }

            return rootNewsViewModel?.Data;
        }
        public static async Task<Root<AddNewsViewModel>> Create(AddNewsViewModel addNews)
        {
            try
            {
                using(var httpClient = new HttpClient())
                {
                    Root<AddNewsViewModel> rootAddNews = new Root<AddNewsViewModel>();
                    var serializeNews = JsonSerializer.Serialize(addNews);
                    StringContent stringContent = new StringContent(serializeNews,Encoding.UTF8,"application/json");
                    var response = await httpClient.PostAsync("http://localhost:5156/addNews", stringContent);
                    if(response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        rootAddNews.Data = JsonSerializer.Deserialize<AddNewsViewModel>(contentResponse);
                        rootAddNews.Error = null;
                        return rootAddNews;
                    }
                    else
                    {
                        return new Root<AddNewsViewModel>{Data = null,Error="Bad Request"};
                    }

                }
            }
            catch (System.Exception)
            {
                return new Root<AddNewsViewModel> { Data = null, Error = "Data Unreachable" };
            }
        }
        public static async Task<Root<UpdateNewsViewModel>> Update(UpdateNewsViewModel updateNews)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    Root<UpdateNewsViewModel> rootAddNews = new Root<UpdateNewsViewModel>();
                    var serializeNews = JsonSerializer.Serialize(updateNews);
                    StringContent stringContent = new StringContent(serializeNews, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync("http://localhost:5156/updateNews", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        rootAddNews.Data = JsonSerializer.Deserialize<UpdateNewsViewModel>(contentResponse);
                        rootAddNews.Error = null;
                        return rootAddNews;
                    }
                    else
                    {
                        return new Root<UpdateNewsViewModel> { Data = null, Error = "Bad Request" };
                    }

                }
            }
            catch (System.Exception)
            {

                return new Root<UpdateNewsViewModel> { Data = null, Error = "Data Unreachable" };

            }
        }
    }
}