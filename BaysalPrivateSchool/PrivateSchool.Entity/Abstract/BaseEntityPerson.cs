using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Entity.Abstract
{
    public abstract class BaseEntityPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get{return FirstName + " " + LastName;} }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual int Age { get {return DateTime.Now.Year - BirthDate.Year; } }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}