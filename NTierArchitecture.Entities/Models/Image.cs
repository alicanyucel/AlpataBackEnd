using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Http;
using NTierArchitecture.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Models
{
    public sealed class Image : Entity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public AppUser User { get; set; }
    }
}
