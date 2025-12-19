namespace ResumeProfile.Application.Common.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            // --- Project → ProjectDto ---
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.ImageBase64,
                    opt => opt.MapFrom(src =>
                        src.Image != null ? FrameWork.Common.Extensions.ConvertByteArrayToBase64string(src.Image) : null))
                .ReverseMap()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src =>
                        src.ImageBase64 != null ? Convert.FromBase64String(src.ImageBase64) : null));
            // --- Project → ProjectDetailDto ---
            CreateMap<Project, ProjectDetailDto>()
                .ForMember(dest => dest.ImageBase64,
                    opt => opt.MapFrom(src =>
                        src.Image != null ? FrameWork.Common.Extensions.ConvertByteArrayToBase64string(src.Image) : null))
                .ReverseMap()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src =>
                        src.ImageBase64 != null ? Convert.FromBase64String(src.ImageBase64) : null));
            // --- Project → ProjectAdminDto ---
            CreateMap<Project, ProjectAdminDto>()
                .ForMember(dest => dest.ImageBase64,
                    opt => opt.MapFrom(src =>
                        src.Image != null ? FrameWork.Common.Extensions.ConvertByteArrayToBase64string(src.Image) : null))
                .ReverseMap()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src =>
                        src.ImageBase64 != null ? Convert.FromBase64String(src.ImageBase64) : null));



            // CreateProjectDto → Project
            CreateMap<CreateProjectDto, Project>()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src =>
                        src.Images != null ? FrameWork.Common.Extensions.ConvertIFormFileToByteforImage(src.Images) : null
                    ))
                .ReverseMap();

            // UpdateProjectDto → Project
            CreateMap<UpdateProjectDto, Project>()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src =>
                        src.Images != null ? FrameWork.Common.Extensions.ConvertIFormFileToByteforImage(src.Images) : null
                    ))
                .ReverseMap();
        }
    }
}
