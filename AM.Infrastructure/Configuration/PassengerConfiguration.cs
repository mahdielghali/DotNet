using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class PassengerConfiguration: IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.Fullname, f=>
            {
                f.Property(x => x.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                f.Property(x => x.LastName).IsRequired().HasColumnName("PassLastName");

            });
            //builder.HasDiscriminator<string>("IsTraveller").HasValue<Traveller>("1").HasValue<Staff>("2").HasValue<Passenger>("0");
        }
    }
}
