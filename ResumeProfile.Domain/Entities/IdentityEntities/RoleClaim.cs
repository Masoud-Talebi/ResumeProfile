using DoctorAppointment.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class RoleClaim:IdentityRoleClaim<long>,ICreatedEntity,ISoftDeleted
    {
        public virtual Role Role { get; set; }
    }
}