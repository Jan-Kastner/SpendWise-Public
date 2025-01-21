using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Repositories
{
    public static class DtoEntityMapping
    {
        private static readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>
        {
            { typeof(CategoryDto), typeof(CategoryEntity) },
            { typeof(GroupDto), typeof(GroupEntity) },
            { typeof(GroupUserDto), typeof(GroupUserEntity) },
            { typeof(InvitationDto), typeof(InvitationEntity) },
            { typeof(LimitDto), typeof(LimitEntity) },
            { typeof(TransactionGroupUserDto), typeof(TransactionGroupUserEntity) },
            { typeof(TransactionDto), typeof(TransactionEntity) },
            { typeof(UserDto), typeof(UserEntity) },
        };

        public static Type GetEntityType<TDto>()
        {
            if (_mappings.TryGetValue(typeof(TDto), out var entityType))
            {
                return entityType;
            }
            throw new InvalidOperationException($"No mapping found for DTO type {typeof(TDto).Name}");
        }
    }
}