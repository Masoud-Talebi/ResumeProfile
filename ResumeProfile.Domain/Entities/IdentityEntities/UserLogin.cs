namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class UserLogin:IdentityUserLogin<long>,ICreatedEntity,ISoftDeleted
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
    }
}