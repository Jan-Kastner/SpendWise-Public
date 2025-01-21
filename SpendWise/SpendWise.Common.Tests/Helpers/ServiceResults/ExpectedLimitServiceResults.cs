using SpendWise.BLL.DTOs;
using SpendWise.Common.Tests.Seeds;


namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for limit DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedLimitServiceResults
    {
        public static void Initialize() { }
        /// <summary>
        /// Gets the expected result for the limit assigned to Charlie in the family group as a list DTO.
        /// </summary>
        public static readonly LimitListDto LimitCharlieFamilyList = new()
        {
            Id = LimitSeeds.LimitCharlieFamily.Id,
            GroupUserId = LimitSeeds.GroupUserCharlieInFamilyId,
            Amount = 1000m,
            NoticeType = LimitSeeds.LimitCharlieFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to Diana in the family group as a list DTO.
        /// </summary>
        public static readonly LimitListDto LimitDianaFamilyList = new()
        {
            Id = LimitSeeds.LimitDianaFamily.Id,
            GroupUserId = LimitSeeds.GroupUserDianaInFamilyId,
            Amount = 1500m,
            NoticeType = LimitSeeds.LimitDianaFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to John in the work group as a list DTO.
        /// </summary>
        public static readonly LimitListDto LimitJohnWorkList = new()
        {
            Id = LimitSeeds.LimitJohnWork.Id,
            GroupUserId = LimitSeeds.GroupUserJohnInWorkId,
            Amount = 2000m,
            NoticeType = LimitSeeds.LimitJohnWork.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to Charlie in the family group as a summary DTO.
        /// </summary>
        public static readonly LimitSummaryDto LimitCharlieFamilySummary = new()
        {
            Id = LimitSeeds.LimitCharlieFamily.Id,
            GroupUserId = LimitSeeds.GroupUserCharlieInFamilyId,
            Amount = 1000m,
            NoticeType = LimitSeeds.LimitCharlieFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to Diana in the family group as a summary DTO.
        /// </summary>
        public static readonly LimitSummaryDto LimitDianaFamilySummary = new()
        {
            Id = LimitSeeds.LimitDianaFamily.Id,
            GroupUserId = LimitSeeds.GroupUserDianaInFamilyId,
            Amount = 1500m,
            NoticeType = LimitSeeds.LimitDianaFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to John in the work group as a summary DTO.
        /// </summary>
        public static readonly LimitSummaryDto LimitJohnWorkSummary = new()
        {
            Id = LimitSeeds.LimitJohnWork.Id,
            GroupUserId = LimitSeeds.GroupUserJohnInWorkId,
            Amount = 2000m,
            NoticeType = LimitSeeds.LimitJohnWork.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to Charlie in the family group as a detail DTO.
        /// </summary>
        public static readonly LimitDetailDto LimitCharlieFamilyDetail = new()
        {
            Id = LimitSeeds.LimitCharlieFamily.Id,
            GroupUserId = LimitSeeds.GroupUserCharlieInFamilyId,
            Amount = 1000m,
            NoticeType = LimitSeeds.LimitCharlieFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to Diana in the family group as a detail DTO.
        /// </summary>
        public static readonly LimitDetailDto LimitDianaFamilyDetail = new()
        {
            Id = LimitSeeds.LimitDianaFamily.Id,
            GroupUserId = LimitSeeds.GroupUserDianaInFamilyId,
            Amount = 1500m,
            NoticeType = LimitSeeds.LimitDianaFamily.NoticeType
        };

        /// <summary>
        /// Gets the expected result for the limit assigned to John in the work group as a detail DTO.
        /// </summary>
        public static readonly LimitDetailDto LimitJohnWorkDetail = new()
        {
            Id = LimitSeeds.LimitJohnWork.Id,
            GroupUserId = LimitSeeds.GroupUserJohnInWorkId,
            Amount = 2000m,
            NoticeType = LimitSeeds.LimitJohnWork.NoticeType
        };
    }
}