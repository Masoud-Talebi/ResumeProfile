namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class UserClaim : IdentityUserClaim<long>, ICreatedEntity, ISoftDeleted
    {

        public long Id { get; set; }
        public virtual User User { get; set; }
    }
}