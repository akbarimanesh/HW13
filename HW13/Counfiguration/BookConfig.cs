using HW13.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Counfiguration
{
    public class BookConfig : IEntityTypeConfiguration<Book>

    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Author).HasMaxLength(50);
        }
    }
}
