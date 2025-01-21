namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) that can be queried.
    /// </summary>
    public interface IQueryableDto
    {
        public Guid Id { get; init; }
    }
}