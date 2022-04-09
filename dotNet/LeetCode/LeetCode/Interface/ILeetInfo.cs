
namespace LeetCode.Interface
{
    public interface ILeetInfo
    {
        string Problem { get; }
        TopicType[] Topics { get; }
        Difficulty Difficulty { get; }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public enum TopicType
    {
        Array,
        String,
        HashTable,
        DynamicProgramming,
        Math,
        Depth_FirstSearch,
        Sorting,
        Greedy,
        Database,
        Breadth_FirstSearch,
        Tree,
        BinarySearch,
        Matrix,
        BinaryTree,
        TwoPointers,
        BitManipulation,
        Stack,
        Design,
        Heap_PriorityQueue,
        Graph,
        Backtracking,
        Simulation,
        PrefixSum,
        Counting,
        SlidingWindow,
        LinkedList,
        UnionFind,
        Recursion,
        OrderedSet,
        MonotonicStack,
        BinarySearchTree,
        Trie,
        DivideandConquer,
        Bitmask,
        Queue,
        Enumeration,
        Geometry,
        Memoization,
        GameTheory,
        SegmentTree,
        TopologicalSort,
        HashFunction,
        Interactive,
        BinaryIndexedTree,
        DataStream,
        StringMatching,
        RollingHash,
        ShortestPath,
        Randomized,
        NumberTheory,
        Combinatorics,
        MonotonicQueue,
        Iterator,
        MergeSort,
        Concurrency,
        Brainteaser,
        ProbabilityandStatistics,
        Doubly_LinkedList,
        Quickselect,
        BucketSort,
        MinimumSpanningTree,
        CountingSort,
        SuffixArray,
        Shell,
        LineSweep,
        ReservoirSampling,
        EulerianCircuit,
        StronglyConnectedComponent,
        RadixSort,
        RejectionSampling,
        BiconnectedComponent,
    }
}
