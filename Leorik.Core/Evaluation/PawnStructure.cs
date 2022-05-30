﻿using System.Runtime.CompilerServices;

namespace Leorik.Core
{
    public struct PawnStructure
    {
        struct PawnHashEntry
        {
            public PawnStructure Eval;
            public ulong BlackPawns;
            public ulong WhitePawns;
        }

        const int HASH_TABLE_SIZE = 4999; //prime!
        static PawnHashEntry[] PawnHashTable = new PawnHashEntry[HASH_TABLE_SIZE];

        const short ISOLATED_PAWN = -8;
        const short CONNECTED_PAWN = 6;
        const short PROTECTED_PAWN = 14;
        const short PASSED_RANK = 16;
        const short PASSED_CENTER = -12;

        public short Base;
        public short Endgame;

        public PawnStructure(BoardState pos) : this()
        {
            AddIsolatedPawns(pos);
            AddPassedPawns(pos);
            AddProtectedPawns(pos);
            AddConnectedPawns(pos);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Update(BoardState board, ref Move move)
        {
            if ((move.MovingPiece() & Piece.TypeMask) == Piece.Pawn ||
                (move.CapturedPiece() & Piece.TypeMask) == Piece.Pawn)
                Update(board);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Update(BoardState board)
        {
            //try to update via pawn hash table
            ulong index = board.Pawns % HASH_TABLE_SIZE;
            ref PawnHashEntry entry = ref PawnHashTable[index];

            ulong blackPawns = board.Black & board.Pawns;
            ulong whitePawns = board.White & board.Pawns;
            if (blackPawns != entry.BlackPawns || whitePawns != entry.WhitePawns)
            {
                //compute pawnstructure from scratch and save it in the hash table
                entry.Eval = new PawnStructure(board);
                entry.BlackPawns = blackPawns;
                entry.WhitePawns = whitePawns;
            }

            this = entry.Eval;
        }

        private void AddPassedPawns(BoardState pos)
        {
            for (ulong bits = Features.GetPassedPawns(pos, Color.Black); bits != 0; bits = Bitboard.ClearLSB(bits))
                Endgame -= ScorePassedPawn(Bitboard.LSB(bits));

            for (ulong bits = Features.GetPassedPawns(pos, Color.White); bits != 0; bits = Bitboard.ClearLSB(bits))
                Endgame += ScorePassedPawn(Bitboard.LSB(bits) ^ 56);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private short ScorePassedPawn(int square)
        {
            int rank = 8 - (square >> 3);
            int file = square & 7;
            int center = Math.Min(file, 7 - file);
            return (short)(PASSED_RANK * rank + PASSED_CENTER * center);
        }

        private void AddIsolatedPawns(BoardState pos)
        {
            int white = Bitboard.PopCount(Features.GetIsolatedPawns(pos, Color.White));
            int black = Bitboard.PopCount(Features.GetIsolatedPawns(pos, Color.Black));
            Base += (short)(ISOLATED_PAWN * (white - black));
        }

        private void AddConnectedPawns(BoardState pos)
        {
            int white = Bitboard.PopCount(Features.GetConnectedPawns(pos, Color.White));
            int black = Bitboard.PopCount(Features.GetConnectedPawns(pos, Color.Black));
            Base += (short)(CONNECTED_PAWN * (white - black));
        }

        private void AddProtectedPawns(BoardState pos)
        {
            int white = Bitboard.PopCount(Features.GetProtectedPawns(pos, Color.White));
            int black = Bitboard.PopCount(Features.GetProtectedPawns(pos, Color.Black));
            Base += (short)(PROTECTED_PAWN * (white - black));
        }
    }
}
