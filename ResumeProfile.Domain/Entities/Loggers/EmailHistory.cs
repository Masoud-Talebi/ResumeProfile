namespace ResumeProfile.Domain.Entities.Loggers
{
    public class EmailHistory : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// پیغام
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// ای پی ارسال کننده
        /// </summary>
        /// <value></value>
        public string? SenderIP { get; set; }
        /// <summary>
        /// ارسال در تاریخ
        /// </summary>
        /// <value></value>
        public DateTime? SendAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        public string? Description { get; set; }

    }
}