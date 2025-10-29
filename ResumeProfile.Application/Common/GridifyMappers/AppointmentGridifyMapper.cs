namespace ResumeProfile.Application.Common.GridifyMappers
{
    public class AppointmentGridifyMapper : GridifyMapper<AppointmentDto>
    {
        public AppointmentGridifyMapper()
        {
            AddMap("Date", a => a.Date);
            AddMap("IsBooked", a => a.IsBooked);
        }
    }
}
