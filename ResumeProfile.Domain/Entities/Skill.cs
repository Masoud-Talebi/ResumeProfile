namespace ResumeProfile.Domain.Entities
{
    public class Skill : BaseEntity
    {
        /// <summary>
        /// نام مهارت
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// سطح مهارت
        /// </summary>
        public int Level { get; set; } // مثلا 1 تا 100
    }
}