using Microsoft.AspNetCore.Identity;

namespace eBusiness.Core.Entities;

public class UserSide:IdentityUser
{
    public string FullName { get; set; }
    public bool IsActive { get; set; }
}
