using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class SchoolInfoDAL
    {
        public static async Task<SchoolInfoViewModel> GetAllSchoolInfos()
        {
            Root<List<SchoolInfoViewModel>> rootSchoolInfos = new Root<List<SchoolInfoViewModel>>();
            var schoolInfo = new SchoolInfoViewModel();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5156/getSchoolInfos");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootSchoolInfos = JsonSerializer.Deserialize<Root<List<SchoolInfoViewModel>>>(contentResponse);
                    schoolInfo = rootSchoolInfos?.Data[0];
                }
                else
                {
                    rootSchoolInfos = null;
                }
            }
            return schoolInfo;
        }
    }
}