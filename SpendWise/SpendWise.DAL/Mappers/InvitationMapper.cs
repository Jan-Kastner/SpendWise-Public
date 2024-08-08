using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="InvitationEntity"/> and <see cref="InvitationDto"/>.
    /// </summary>
    public class InvitationMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationMapper"/> class.
        /// </summary>
        public InvitationMapper()
        {
            // Create mapping configuration from InvitationEntity to InvitationDto
            CreateMap<InvitationEntity, InvitationDto>();

            // Create mapping configuration from InvitationDto to InvitationEntity
            CreateMap<InvitationDto, InvitationEntity>();
        }
    }
}
