using KellermanSoftware.CompareNetObjects;
using Xunit;

namespace SpendWise.DAL.Tests.Helpers
{
    /// <summary>
    /// Provides methods for performing deep comparison assertions in unit tests.
    /// </summary>
    public static class DeepAssert
    {
        /// <summary>
        /// Asserts that a collection does not contain an item that is deeply equal to the expected item, ignoring specified properties.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the collection.</typeparam>
        /// <param name="expected">The expected item to ensure is not in the collection.</param>
        /// <param name="collection">The collection to search for the expected item.</param>
        /// <param name="propertiesToIgnore">The properties to ignore during the comparison.</param>
        /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
        public static void DoesNotContain<T>(T? expected, IEnumerable<T>? collection, params string[] propertiesToIgnore)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            CompareLogic compareLogic = new CompareLogic
            {
                Config =
                {
                    MembersToIgnore = propertiesToIgnore.ToList(),
                    IgnoreCollectionOrder = true,
                    IgnoreObjectTypes = true,
                    CompareStaticProperties = false,
                    CompareStaticFields = false
                }
            };

            if (collection.Any(item => compareLogic.Compare(expected!, item).AreEqual))
            {
                Assert.True(false, $"Item found in collection that should not be present: {expected}");
            }
        }
        
        /// <summary>
        /// Asserts that two objects are deeply equal, ignoring specified properties.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="expected">The expected object.</param>
        /// <param name="actual">The actual object to compare against the expected object.</param>
        /// <param name="propertiesToIgnore">The properties to ignore during the comparison.</param>
        public static void Equal<T>(T? expected, T? actual, params string[] propertiesToIgnore)
        {
            CompareLogic compareLogic = new CompareLogic
            {
                Config =
                {
                    MembersToIgnore = propertiesToIgnore.ToList(),
                    IgnoreCollectionOrder = true,
                    IgnoreObjectTypes = true,
                    CompareStaticProperties = false,
                    CompareStaticFields = false
                }
            };

            ComparisonResult comparisonResult = compareLogic.Compare(expected!, actual!);
            if (!comparisonResult.AreEqual)
            {
                Assert.True(false, comparisonResult.DifferencesString);
            }
        }

        /// <summary>
        /// Asserts that a collection contains an item that is deeply equal to the expected item, ignoring specified properties.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the collection.</typeparam>
        /// <param name="expected">The expected item to find in the collection.</param>
        /// <param name="collection">The collection to search for the expected item.</param>
        /// <param name="propertiesToIgnore">The properties to ignore during the comparison.</param>
        /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
        public static void Contains<T>(T? expected, IEnumerable<T>? collection, params string[] propertiesToIgnore)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            CompareLogic compareLogic = new CompareLogic
            {
                Config =
                {
                    MembersToIgnore = propertiesToIgnore.ToList(),
                    IgnoreCollectionOrder = true,
                    IgnoreObjectTypes = true,
                    CompareStaticProperties = false,
                    CompareStaticFields = false
                }
            };

            if (!collection.Any(item => compareLogic.Compare(expected!, item).AreEqual))
            {
                Assert.True(false, $"Item not found in collection: {expected}");
            }
        }
    }
}
