
namespace LeetCode.Interface
{
    public interface ILeetInfo
    {
        string Problem { get; }
        TopicType[] Topics { get; }
    }
    public enum TopicType
    {
        Array,
        Two_Pointers,
        Binary_Search,
        Bit_Manipulation,
    }
}
