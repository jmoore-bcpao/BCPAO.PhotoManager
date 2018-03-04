using Microsoft.AspNetCore.Authorization;

namespace BCPAO.PhotoManager
{
    public class HasPermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; set; }
    }
}
