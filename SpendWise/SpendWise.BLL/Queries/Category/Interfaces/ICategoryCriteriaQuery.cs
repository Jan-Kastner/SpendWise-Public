namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for category criteria-based queries.
    /// </summary>
    public interface ICategoryCriteriaQuery : ICriteriaQuery
    {
        string? Name { get; }
        string? Description { get; }
        string? Color { get; }
        string? NamePartialMatch { get; }
        string? NotName { get; }
        string? NotNamePartialMatch { get; }
        string? NotDescription { get; }
        string? NotDescriptionPartialMatch { get; }
        string? NotColor { get; }
        bool? WithoutDescription { get; }
        bool? NotWithoutDescription { get; }
        bool? WithoutIcon { get; }
        bool? NotWithoutIcon { get; }
    }
}