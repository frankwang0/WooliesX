using System.Runtime.Serialization;

namespace WooliesX.DomainModel
{
    public enum SortOption
    {
        [EnumMember(Value = "Low")]
        Low,

        [EnumMember(Value = "High")]
        High,

        [EnumMember(Value = "Ascending")]
        Ascending,

        [EnumMember(Value = "Descending")]
        Descending,

        [EnumMember(Value = "Recommended")]
        Recommended
    }
}
