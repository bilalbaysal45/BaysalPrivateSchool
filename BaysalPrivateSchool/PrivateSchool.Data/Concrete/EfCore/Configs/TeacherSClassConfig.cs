using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Configs
{
    public class TeacherSClassConfig : IEntityTypeConfiguration<TeacherClass>
    {
        public void Configure(EntityTypeBuilder<TeacherClass> builder)
        {
            builder.HasKey(x => new{x.TeacherId,x.SClassId});
        }
    }
}