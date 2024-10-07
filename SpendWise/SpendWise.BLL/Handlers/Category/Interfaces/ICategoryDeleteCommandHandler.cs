using System.Threading.Tasks;
using SpendWise.BLL.Commands;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Defines a handler for processing delete commands for categories.
    /// </summary>
    public interface ICategoryDeleteCommandHandler
    {
        /// <summary>
        /// Handles the specified delete command.
        /// </summary>
        /// <param name="command">The delete command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Handle(DeleteCommand command);
    }
}