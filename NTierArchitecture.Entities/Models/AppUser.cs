using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace NTierArchitecture.Entities.Models;
public sealed class AppUser : IdentityUser<Guid>
{
   public string Name { get; set; }
   public string Lastname {  get; set; }
   public string ImageUrl { get; set; }
    public List<Image> Images { get; set; }

}
