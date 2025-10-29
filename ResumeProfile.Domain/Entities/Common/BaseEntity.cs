namespace ResumeProfile.Domain.Entities.Common
{
    public abstract class BaseEntity : IEntity<long>, ICreatedEntity,IModifiedEntity,ISoftDeleted
    {
        [Required]
        [Display(Name = "شناسه")]
        public long Id { get; set; }
        public bool IsActive { get; set; } 
    }


    public interface ICreatedEntity { }
    public interface IModifiedEntity { }
    public interface ISoftDeleted { }
}