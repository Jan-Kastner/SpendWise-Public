namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a sender.
    /// </summary>
    /// <typeparam name="TSenderDto">The type of the sender DTO.</typeparam>
    public interface ISenderDto<TSenderDto> where TSenderDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the sender associated with the entity.
        /// </summary>
        TSenderDto Sender { get; set; }
    }
}