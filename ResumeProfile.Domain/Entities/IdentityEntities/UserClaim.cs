using DoctorAppointment.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class UserClaim : IdentityUserClaim<long>, ICreatedEntity, ISoftDeleted
    {

        public long Id { get; set; }
        public virtual User User { get; set; }
    }
}