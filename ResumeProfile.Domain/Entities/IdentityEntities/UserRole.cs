using DoctorAppointment.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class UserRole : IdentityUserRole<long>, ICreatedEntity, IModifiedEntity
    {
        //public long Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}