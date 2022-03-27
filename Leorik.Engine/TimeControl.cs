﻿using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Leorik.Engine
{
    class TimeControl
    {
        const int BASE_MARGIN = 5;
        const int BRANCHING_FACTOR_ESTIMATE = 3;
        const int MAX_TIME_REMAINING = int.MaxValue / 3; //large but not too large to cause overflow issues

        private int _movesToGo;
        private int _increment;
        private int _remaining;
        private int _margin;
        private int _maxDepth;

        private long _t0 = -1;
        private long _tN = -1;

        public int TimePerMove() => (_remaining + (_movesToGo - 1) * _increment) / _movesToGo;

        private long Now => Stopwatch.GetTimestamp();
        public int Elapsed => MilliSeconds(Now - _t0);
        public int ElapsedInterval => MilliSeconds(Now - _tN);

        private int MilliSeconds(long ticks)
        {
            double dt = ticks / (double)Stopwatch.Frequency;
            return (int)(1000 * dt);
        }

        private void Reset()
        {
            _movesToGo = 1;
            _increment = 0;
            _remaining = MAX_TIME_REMAINING;
            _t0 = Now;
            _tN = _t0;
            _margin = BASE_MARGIN;
        }

        public void StartInterval()
        {
            _tN = Now;
        }

        public void Stop()
        {
            //this will cause CanSearchDeeper() and CheckTimeBudget() to evaluate to 'false'
            _remaining = 0;
        }

        internal void Go(int maxDepth, int timePerMove)
        {
            Reset();
            _maxDepth = maxDepth;
            _remaining = Math.Min(timePerMove, MAX_TIME_REMAINING);
        }

        internal void Go(int maxDepth, int time, int increment, int movesToGo)
        {
            Reset();
            _maxDepth = maxDepth;
            _remaining = Math.Min(time, MAX_TIME_REMAINING);
            _increment = increment;
            _movesToGo = movesToGo;
        }

        public bool CanSearchDeeper(int depth)
        {
            if (depth >= _maxDepth)
                return false;

            int budget = TimePerMove();

            //we use a dynamic margin based on the depth, but at least 10% of the time per move
            _margin = Math.Max(BASE_MARGIN * depth, budget / 10);

            //estimate the branching factor, if only one move to go we yolo with a low estimate
            int elapsed = Elapsed;
            int multi = (_movesToGo == 1) ? 1 : BRANCHING_FACTOR_ESTIMATE;
            float overdraft = (_increment == 0) ? 1.5f : 2.0f;
            int estimate = multi * ElapsedInterval;
            int total = elapsed + estimate + _margin;

            //we have already exceeded the budget for the move
            if (elapsed > budget)
                return false;
            //shouldn't spend more than X% of the per move budget on a single move
            if (total > overdraft * budget)
                return false;
            //can't afford the estimate
            if (total > _remaining - _margin)
                return false;

            //all conditions fulfilled - let's base the margin on the budget
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckTimeBudget()
        {
            return Elapsed > (_remaining - _margin);
        }
    }
}
