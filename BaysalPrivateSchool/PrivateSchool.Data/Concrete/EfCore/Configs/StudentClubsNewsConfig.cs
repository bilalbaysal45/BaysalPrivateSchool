using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Data.Concrete.EfCore.Configs
{
    public class StudentClubsNewsConfig : IEntityTypeConfiguration<StudentClubsNews>
    {
        public void Configure(EntityTypeBuilder<StudentClubsNews> builder)
        {
            builder.HasKey(x => new {x.StudentClubId,x.NewsId});
        }
    }
}