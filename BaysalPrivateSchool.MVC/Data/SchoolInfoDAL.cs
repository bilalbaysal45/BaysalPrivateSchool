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
        public static async Task<Root<SchoolInfoViewModel>> GetAllSchoolInfos()
        {
            Root<SchoolInfoViewModel> rootSchoolInfos = new Root<SchoolInfoViewModel>();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.GetAsync("http://localhost:5156/getSchoolInfos");
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootSchoolInfos = JsonSerializer.Deserialize<Root<SchoolInfoViewModel>>(contentResponse);
                    }
                    else
                    {
                        rootSchoolInfos.Data = new SchoolInfoViewModel();
                        rootSchoolInfos.Error = "Unsuccessfull Connection";
                    }
                }
                catch (System.Exception)
                {
                    rootSchoolInfos.Data = null;
                    rootSchoolInfos.Error = "Data uncreachable, Check API connection";
                    return rootSchoolInfos;
                }
            }
            return rootSchoolInfos;
        }
    }
}