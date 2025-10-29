namespace ResumeProfile.Domain.Entities.Loggers;

public class ErrorHistory : IEntity<long>
{
    /// <summary>
    /// شناسه
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// کد نمایشی به کاربر
    /// </summary>
    public string ErrorCode { get; set; }
    /// <summary>
    /// متن خطای واقعی
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// جزئیات فنی
    /// </summary>
    public string? StackTrace { get; set; }
    /// <summary>
    /// Command یا Query Name
    /// </summary>
    public string? CommandName { get; set; }
    /// <summary>
    /// اطلاعات بیشتر
    /// </summary>
    public string? ExtraData { get; set; }

    public DateTime CreatedDateTime { get; set; }
    public long? CreatedByUserId { get; set; }
    public string? CreatedByIP { get; set; }

    public bool IsActive { get; set; }
}