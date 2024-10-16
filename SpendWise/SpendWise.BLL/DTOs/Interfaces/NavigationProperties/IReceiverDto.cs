namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a receiver.
    /// </summary>
    /// <typeparam name="TReceiverDto">The type of the receiver DTO.</typeparam>
    public interface IReceiverDto<TReceiverDto> where TReceiverDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the receiver associated with the entity.
        /// </summary>
        TReceiverDto Receiver { get; set; }
    }
}