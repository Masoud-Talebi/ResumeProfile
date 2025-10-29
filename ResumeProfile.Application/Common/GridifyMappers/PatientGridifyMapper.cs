namespace ResumeProfile.Application.Common.GridifyMappers
{
    public class PatientGridifyMapper : GridifyMapper<PatientDto>
    {
        public PatientGridifyMapper() 
        {
            AddMap("NationalCode", p => p.NationalCode);
            AddMap("PhoneNumber", p => p.PhoneNumber);
            AddMap("FirstName", p => p.FirstName);
            AddMap("LastName", p => p.LastName);
            AddMap("HasInsurance", p => p.HasInsurance);
        }
    }

    public class PatientsByUserIdGridifyMapper : GridifyMapper<PatientsByUserIdDto>
    {
        public PatientsByUserIdGridifyMapper()
        {
            AddMap("NationalCode", p => p.NationalCode);
            AddMap("PhoneNumber", p => p.PhoneNumber);
            AddMap("FirstName", p => p.FirstName);
            AddMap("LastName", p => p.LastName);
            AddMap("HasInsurance", p => p.HasInsurance);
        }
    }
}
