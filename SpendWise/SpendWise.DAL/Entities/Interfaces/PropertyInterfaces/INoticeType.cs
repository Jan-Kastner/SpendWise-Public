using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a notice type.
    /// </summary>
    public interface INoticeType
    {
        /// <summary>
        /// Gets or sets the notice type of the entity.
        /// </summary>
        NoticeType NoticeType { get; set; }
    }
}