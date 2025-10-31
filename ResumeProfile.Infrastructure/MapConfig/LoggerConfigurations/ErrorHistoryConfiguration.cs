namespace DoctorAppointment.infrastructure.MapConfig.LoggerConfigurations;

public class ErrorHistoryConfiguration : IEntityTypeConfiguration<ErrorHistory>
{
    public void Configure(EntityTypeBuilder<ErrorHistory> builder)
    {
        builder.ToTable("ErrorHistories");
        builder.HasIndex(x => x.ErrorCode).IsUnique();
        builder.Property(x => x.CreatedDateTime).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
    }
}