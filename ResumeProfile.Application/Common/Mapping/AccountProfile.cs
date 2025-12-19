namespace ResumeProfile.Application.Common.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Map بین User و CurrentUserInfoDto
            CreateMap<User, CurrentUserInfoDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                .ReverseMap();
        }
    }
}
