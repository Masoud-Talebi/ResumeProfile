using Microsoft.AspNetCore.Identity;

namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class Role : IdentityRole<long>,ICreatedEntity,IModifiedEntity,ISoftDeleted
    {
        public string? Description { get; set; }

        //Navigations Property
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<RoleClaim>? RoleClaims { get; set; }
    }
}
