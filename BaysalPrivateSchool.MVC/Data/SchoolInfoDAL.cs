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
        public static async Task<Root<List<SchoolInfoViewModel>>> GetAllSchoolInfos()
        {
            Root<List<SchoolInfoViewModel>> rootSchoolInfos = new Root<List<SchoolInfoViewModel>>();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.GetAsync("http://localhost:5156/getSchoolInfos");
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootSchoolInfos = JsonSerializer.Deserialize<Root<List<SchoolInfoViewModel>>>(contentResponse);
                        return rootSchoolInfos;
                    }
                    else
                    {
                        rootSchoolInfos.Data = new List<SchoolInfoViewModel>();
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