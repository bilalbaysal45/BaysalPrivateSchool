using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Data.CheckProperties
{
    public static class CheckDepartment
    {
        public static async Task<bool> IsValid(string name)
        {
            if (await DepartmentName(name))
            {
                return true;
            }
            return false;
        }
        private static async Task<bool> DepartmentName(string name)
        {
            var departments = await DepartmentDAL.GetAll();
            var department = departments.Find(x => x.Name == name);
            if (department != null)
            {
                return true;
            }
            return false;
        }
    }
}