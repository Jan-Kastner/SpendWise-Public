using AutoMapper;
using SpendWise.BLL.Queries;

namespace SpendWise.BLL.Mappers
{
    public class UserToGroupUserCriteriaMappingProfile : Profile
    {
        public UserToGroupUserCriteriaMappingProfile()
        {
            CreateMap<GetUsersByCriteriaQuery, GetGroupUsersByCriteriaQuery>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NotUserName, opt => opt.MapFrom(src => src.NotName))
                .ForMember(dest => dest.UserNamePartialMatch, opt => opt.MapFrom(src => src.NamePartialMatch))
                .ForMember(dest => dest.NotUserNamePartialMatch, opt => opt.MapFrom(src => src.NotNamePartialMatch))
                .ForMember(dest => dest.UserSurname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.NotUserSurname, opt => opt.MapFrom(src => src.NotSurname))
                .ForMember(dest => dest.UserSurnamePartialMatch, opt => opt.MapFrom(src => src.SurnamePartialMatch))
                .ForMember(dest => dest.NotUserSurnamePartialMatch, opt => opt.MapFrom(src => src.NotSurnamePartialMatch))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NotUserEmail, opt => opt.MapFrom(src => src.NotEmail))
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.NotUserPassword, opt => opt.MapFrom(src => src.NotPasswordHash))
                .ForMember(dest => dest.UserDateOfRegistration, opt => opt.MapFrom(src => src.DateOfRegistration))
                .ForMember(dest => dest.NotUserDateOfRegistration, opt => opt.MapFrom(src => src.NotDateOfRegistration))
                .ForMember(dest => dest.WithUserPhoto, opt => opt.MapFrom(src => src.WithPhoto))
                .ForMember(dest => dest.WithUserEmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed))
                .ForMember(dest => dest.WithUserTwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled))
                .ForMember(dest => dest.UserResetPasswordToken, opt => opt.MapFrom(src => src.ResetPasswordToken))
                .ForMember(dest => dest.UserPreferredTheme, opt => opt.MapFrom(src => src.PreferredTheme))
                .ForMember(dest => dest.NotUserPreferredTheme, opt => opt.MapFrom(src => src.NotPreferredTheme))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.NotUserFullName, opt => opt.MapFrom(src => src.NotFullName))
                .ForMember(dest => dest.UserEmailDomain, opt => opt.MapFrom(src => src.EmailDomain))
                .ForMember(dest => dest.NotUserEmailDomain, opt => opt.MapFrom(src => src.NotEmailDomain))
                .ForMember(dest => dest.UserSentInvitationId, opt => opt.MapFrom(src => src.SentInvitationId))
                .ForMember(dest => dest.NotUserSentInvitationId, opt => opt.MapFrom(src => src.NotSentInvitationId))
                .ForMember(dest => dest.UserReceivedInvitationId, opt => opt.MapFrom(src => src.ReceivedInvitationId))
                .ForMember(dest => dest.NotUserReceivedInvitationId, opt => opt.MapFrom(src => src.NotReceivedInvitationId))
                .ForMember(dest => dest.IncludeUser, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IncludeTransactions, opt => opt.MapFrom(src => src.IncludeTransactions))
                .ForMember(dest => dest.And, opt => opt.MapFrom(src => src.And))
                .ForMember(dest => dest.Or, opt => opt.MapFrom(src => src.Or))
                .ForMember(dest => dest.Not, opt => opt.MapFrom(src => src.Not));
        }
    }
}