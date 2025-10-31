namespace DoctorAppointment.infrastructure.MapConfig.LoggerConfigurations;

public class EmailHistoryConfiguration : IEntityTypeConfiguration<EmailHistory>
{
    public void Configure(EntityTypeBuilder<EmailHistory> builder)
    {
        builder.ToTable("EmailHistories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SendAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
    }
}