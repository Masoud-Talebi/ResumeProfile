namespace ResumeProfile.Application.Common.GridifyMappers
{
    public class InsuranceGridifyMapper : GridifyMapper<InsuranceDto>
    {
        public InsuranceGridifyMapper()
        {
            AddMap("Name", x => x.Name);
        }
    }
}
