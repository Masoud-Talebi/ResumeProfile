namespace ResumeProfile.Domain.Entities.Common
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsActive { get; set; }  
    }
}