namespace ResumeProfile.Infrastructure.Common
{
    public static class SeedData
    {
        public static IEnumerable<Role> DefaultRoles =>
          new List<Role>
               {
                new Role
                {
                    Id = 1,
                    Name = SD.Admin,
                    NormalizedName =  SD.Admin.ToUpper()
                }

               };
    }
    public static class SD
    {
        public const string Admin = "admin";
    }
}
