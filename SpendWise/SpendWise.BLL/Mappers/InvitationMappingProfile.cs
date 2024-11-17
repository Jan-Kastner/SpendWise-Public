using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Invitation.
    /// </summary>
    public class InvitationMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Invitation.
        /// </summary>
        public InvitationMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<InvitationDto, InvitationDetailDto>();
            CreateMap<InvitationDto, InvitationListDto>();
            CreateMap<InvitationDto, InvitationSummaryDto>();

            // BLL DTO to DAL DTO mappings
            CreateMap<InvitationCreateDto, InvitationDto>();
            CreateMap<InvitationUpdateDto, InvitationDto>();
        }
    }
}