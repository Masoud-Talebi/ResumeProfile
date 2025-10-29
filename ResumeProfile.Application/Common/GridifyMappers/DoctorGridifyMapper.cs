namespace ResumeProfile.Application.Common.GridifyMappers
{
    public class DoctorGridifyMapper : GridifyMapper<Doctor>
    {
        public DoctorGridifyMapper()
        {
            AddMap("FirstName", d => d.User.FirstName);
            AddMap("LastName", d => d.User.LastName);
            AddMap("Specialization", d => d.Specialization);
            AddMap("Degree", d => d.Degree);
            AddMap("WorkExperienceYears", d => d.WorkExperienceYears);
            AddMap("MedicalSystemNumber", d => d.MedicalSystemNumber);
        }
    }
}
