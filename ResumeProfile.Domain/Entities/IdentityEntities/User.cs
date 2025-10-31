namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class User : IdentityUser<long>,ICreatedEntity,IModifiedEntity, ISoftDeleted
    {
        #region Navigation
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion

    }
}
