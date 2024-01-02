﻿using Leorik.Core;

namespace Leorik.Search
{
    public struct SearchOptions
    {
        public long MaxNodes;
        public int NullMoveCutoff;
        public int Threads;
        public int Temperature;
        public int Seed;
        public readonly static SearchOptions Default = new();

        public SearchOptions()
        {
            Threads = 1;
            MaxNodes = long.MaxValue;
            NullMoveCutoff = 338;
            Seed = -1;
        }
    }

    public interface ISearch
    {
        bool Aborted { get; }
        int Depth { get; }
        int Score { get; }
        long NodesVisited { get; }
        Span<Move> PrincipalVariation { get; }
        void SearchDeeper(Func<bool> checkTimeBudget);
        void Search(int depth);
    }
}
