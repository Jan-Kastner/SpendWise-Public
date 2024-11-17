namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) that can be queried.
    /// </summary>
    public interface IQueryableDto
    {
        public Guid Id { get; init; }
    }
}