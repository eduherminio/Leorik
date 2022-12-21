﻿namespace Leorik.Core
{
    public static class Weights
    {
        /*
        In term's of selfplay strength this set of weights (theta3) is an improvement over theta2 (which is like theta but with tuples)

        Score of Leorik-2.2.8theta3 vs Leorik-2.2.8theta2: 2500 - 2014 - 3190  [0.532] 7704
        ...      Leorik-2.2.8theta3 playing White: 1280 - 849 - 1723  [0.556] 3852
        ...      Leorik-2.2.8theta3 playing Black: 1220 - 1165 - 1467  [0.507] 3852
        ...      White vs Black: 2445 - 2069 - 3190  [0.524] 7704
        Elo difference: 21.9 +/- 5.9, LOS: 100.0 %, DrawRatio: 41.4 %

        But in the gauntlet theta3...

           # PLAYER                :  RATING  POINTS  PLAYED   (%)
           1 Inanis-1.1.1          :  2767.0   308.0     590    52
           2 odonata-0.6.2         :  2744.0   267.0     590    45
           3 Leorik-2.2.8theta3    :  2737.0  1846.5    3541    52
           4 zahak-5.0             :  2730.0   287.5     590    49
           5 dumb-1.9              :  2703.0   296.0     591    50
           6 blunder-8.5.5         :  2700.0   283.0     590    48
           7 Supernova-2.4         :  2687.0   253.0     590    43

        ...is not stronger than theta2:

           # PLAYER                :  RATING  POINTS  PLAYED   (%)
           1 Inanis-1.1.1          :  2767.0   397.0     710    56
           2 odonata-0.6.2         :  2744.0   378.0     710    53
           3 Leorik-2.2.8theta2    :  2737.9  2229.5    4264    52
           4 zahak-5.0             :  2730.0   311.5     710    44
           5 dumb-1.9              :  2703.0   367.0     712    52
           6 blunder-8.5.5         :  2700.0   305.0     712    43
           7 Supernova-2.4         :  2687.0   276.0     710    39

        */

        public static readonly short[] PhaseValues = new short[6] { 0, 190, 184, 347, 1057, 0 };

        public static readonly (short, short)[] Features = new (short, short)[10 * 64]{
            //Pawns
            ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0),
            ( 316, 160), ( 161, 295), ( 220, 221), ( 262, 168), ( 206, 158), ( 205, 189), ( 105, 350), ( 155, 320),
            (  71, 179), ( 105, 163), (  92, 138), ( 149, 101), ( 155,  59), ( 239, -62), ( 208,  94), ( 146, 123),
            (  72, 146), ( 107, 133), (  76, 112), ( 111,  83), ( 125,  64), ( 129,  50), ( 118,  77), ( 111, 118),
            (  61, 145), (  85, 135), ( 105,  66), ( 116,  34), ( 129,  62), ( 122,  66), ( 109,  83), ( 101,  86),
            (  58, 122), (  81, 106), (  70,  90), (  86, 105), (  91,  79), ( 101,  79), ( 116,  50), (  93,  77),
            (  53, 137), (  76, 123), (  74, 101), (  78,  93), (  91, 117), ( 150,  38), ( 158,   4), ( 107,  56),
            ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0), ( 100,   0),
            //Knights
            ( 171, 261), ( 404, 145), ( 395, 147), ( 598, -60), ( 527,  38), ( 439, 128), ( 442, 107), ( 329,  52),
            ( 412,  87), ( 404, 183), ( 482, 110), ( 514,  89), ( 504,  97), ( 563, -23), ( 408, 117), ( 520, -25),
            ( 394, 159), ( 470, 116), ( 471, 164), ( 516, 122), ( 661, -89), ( 627, -44), ( 506,  75), ( 452,  99),
            ( 430, 131), ( 451, 144), ( 476, 176), ( 505, 135), ( 469, 163), ( 521, 117), ( 471, 130), ( 501,  32),
            ( 414, 143), ( 421, 164), ( 472, 152), ( 450, 194), ( 468, 174), ( 473, 139), ( 478,  94), ( 439, 102),
            ( 397, 158), ( 438, 155), ( 456, 150), ( 444, 178), ( 466, 149), ( 465, 125), ( 472, 106), ( 412, 107),
            ( 403,  80), ( 408, 130), ( 427, 125), ( 454, 101), ( 445, 132), ( 442,  98), ( 427,  81), ( 435,  57),
            ( 344,  62), ( 428,  71), ( 409, 100), ( 400, 149), ( 419, 123), ( 434,  74), ( 418,  46), ( 371,  59),
            //Bishops
            ( 390, 124), ( 402, 128), ( 416, 102), ( 379, 136), ( 411,  87), ( 354, 188), ( 456,  78), ( 421,  83),
            ( 359, 134), ( 414, 102), ( 404, 102), ( 446,  71), ( 442,  81), ( 383, 161), ( 400, 136), ( 394, 111),
            ( 415,  99), ( 426,  93), ( 437,  85), ( 461,  40), ( 484,  35), ( 545,  -8), ( 490,  37), ( 448,  57),
            ( 405,  97), ( 422,  87), ( 430, 101), ( 453, 104), ( 432, 128), ( 440,  87), ( 413, 102), ( 424,  85),
            ( 402, 105), ( 423,  93), ( 426, 112), ( 441, 121), ( 450,  86), ( 414, 107), ( 429,  82), ( 439,  56),
            ( 421,  97), ( 452,  75), ( 426, 110), ( 429, 117), ( 422, 109), ( 445,  68), ( 453,  58), ( 446,  50),
            ( 458,  22), ( 420, 102), ( 447,  56), ( 409, 112), ( 429,  70), ( 450,  37), ( 454,  35), ( 420,  52),
            ( 388, 141), ( 452,  11), ( 415, 100), ( 419,  66), ( 433,  66), ( 403,  99), ( 433,  47), ( 391, 106),
            //Rooks
            ( 608, 296), ( 632, 273), ( 638, 262), ( 646, 250), ( 712, 171), ( 728, 158), ( 716, 155), ( 750, 108),
            ( 585, 324), ( 567, 348), ( 631, 286), ( 665, 262), ( 680, 229), ( 757, 104), ( 694, 174), ( 771,  80),
            ( 556, 356), ( 589, 311), ( 576, 341), ( 634, 259), ( 683, 202), ( 763,  95), ( 743, 118), ( 696, 159),
            ( 536, 352), ( 552, 330), ( 588, 305), ( 590, 294), ( 583, 293), ( 650, 220), ( 659, 206), ( 561, 301),
            ( 528, 336), ( 539, 326), ( 570, 301), ( 575, 285), ( 564, 295), ( 579, 272), ( 616, 219), ( 577, 252),
            ( 529, 318), ( 558, 280), ( 536, 311), ( 563, 277), ( 586, 246), ( 588, 232), ( 628, 188), ( 563, 262),
            ( 542, 265), ( 546, 269), ( 562, 277), ( 567, 279), ( 584, 243), ( 578, 238), ( 623, 165), ( 517, 262),
            ( 564, 270), ( 568, 266), ( 583, 267), ( 594, 253), ( 604, 234), ( 597, 243), ( 528, 335), ( 570, 233),
            //Queens
            (1288, 304), (1332, 301), (1339, 302), (1342, 316), (1340, 340), (1379, 246), (1357, 267), (1376, 210),
            (1280, 339), (1262, 425), (1262, 468), (1316, 402), (1305, 434), (1373, 284), (1295, 393), (1375, 254),
            (1303, 265), (1304, 301), (1274, 447), (1317, 392), (1336, 407), (1433, 249), (1386, 258), (1390, 250),
            (1300, 276), (1295, 335), (1276, 387), (1278, 477), (1304, 437), (1316, 387), (1331, 366), (1319, 344),
            (1310, 250), (1291, 321), (1320, 285), (1330, 298), (1307, 351), (1331, 291), (1347, 242), (1339, 268),
            (1313, 185), (1334, 188), (1312, 292), (1321, 243), (1335, 207), (1341, 245), (1356, 241), (1352, 165),
            (1324, 154), (1314, 206), (1336, 173), (1339, 166), (1342, 171), (1378,  31), (1361,  24), (1302, 110),
            (1343,  93), (1310, 172), (1337, 118), (1344, 173), (1334, 129), (1306, 104), (1251, 155), (1263, 107),
            //Kings
            ( -76, -66), (   3, -28), (  28,  13), (  17,  36), (  52,  33), (  17,  14), (  17,  -5), (  -1, -21),
            (  -9, -41), (  49,  13), (  35,  71), (  32,  76), (  53,  71), (  54,  69), (  63,  48), (  -5,  -9),
            (   4,  11), (  -4,  76), (  22,  80), (  19,  80), (  43,  91), (  64,  55), (  57,  45), (  -8,  19),
            ( -23,   1), (  13,  49), (  13,  63), ( -27, 118), (  15,  69), ( -24, 111), ( -21,  89), ( -81,  60),
            ( -14, -48), (  11,  -6), ( -22,  63), ( -78, 133), ( -83, 137), ( -94, 146), ( -48,  70), ( -99,  54),
            ( -29, -44), (  41, -74), ( -61,  72), ( -95, 127), (-129, 162), (-139, 165), (  -5, -22), ( -41, -45),
            (  90,-226), (  27, -98), (  26, -51), ( -46,  30), ( -70,  69), (  -8, -17), (  80,-148), ( 106,-245),
            ( -23,-169), (  89,-258), (  64,-187), (-127,  25), (  76,-222), ( -18, -92), ( 117,-268), ( 109,-326),
            //Isolated Pawns
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            (   1, -10), (  27,   6), (  11,  -7), (  -9, -11), (  33,  14), (  10,  17), (  14,  10), ( -15,   4),
            (   4, -12), ( -14, -37), (  -9,  -8), (  17, -20), (  18,  10), (   7,   5), (  -8, -15), ( -23, -11),
            (  -2,   1), (   1, -34), (  22, -37), (  -4, -17), (  -6,  -4), (  23, -20), (   7, -11), ( -15, -17),
            ( -11,   5), ( -20,  -2), ( -25,  23), ( -37,  40), ( -37,  14), ( -21,   7), ( -19,   2), ( -45,  24),
            (  -6,  15), ( -14,  -5), (  -7,   4), ( -11, -10), ( -33,  22), (  21, -35), (  -5,   0), ( -34,  22),
            (  -9,  15), ( -20,  -3), (  20, -28), ( -37,  22), ( -20,   7), ( -30,  18), ( -13,  10), ( -35,  24),
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            //Passed Pawns
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            (  22,  16), (   6,  29), (  12,  22), (  16,  17), (  11,  16), (  11,  19), (   1,  35), (   6,  32),
            ( 127, 129), ( 131, 115), ( 116,  88), (  43,  55), (  74,  32), ( 102,  92), (  76,  88), (  66, 127),
            (  56,  90), (  47,  73), (  41,  76), (  25,  54), (   8,  41), (  44,  64), (  43,  90), (  25, 105),
            (  25,  49), (  26,  38), ( -13,  80), (   0,  54), (  -2,  32), (  -1,  59), (  17,  67), (  20,  70),
            (  -8,  23), (  -5,  24), (  -2,  22), (  -5,  -4), (   4,   1), (  -1,  24), (  21,  10), (  63, -49),
            (  18, -22), (  13,   5), (  -4,  12), ( -27,   7), (   8,  -6), (  -3,   6), (  27, -11), (  59, -50),
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            //Protected Pawns
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            (  14,  13), (  40,  25), (  25,  15), (  25,  15), (  15,  10), (  11,  10), (  26,  24), (  20,  18),
            (  12,  10), (  24,  14), (  67,  -2), (  62,  27), (  65,  32), (  57,  39), (  -3,   0), (   5,   8),
            ( -11,  33), (   2,  14), (  39, -31), (  16,   9), (  43,   1), (  10,  18), (  16,  -5), (   8, -17),
            ( -12,  29), (  13,  -3), (   5,  14), (  17,  30), (   4,  22), (   0,  15), (  26, -18), (   5,  -6),
            (   9,  16), (  13,  33), (  21,   3), (  19,  25), (  22,  37), (  21,   8), (  28, -10), (  40, -28),
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            //Connected Pawns
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
            (   7,   6), (  14,  12), (  11,   9), (   8,   7), (   9,   8), (   6,   5), (   7,   6), (   6,   5),
            (  35,  29), (  63,  46), (  54,  34), (  51,  35), (  52,  36), (  51,  36), (  57,  48), (  33,  30),
            (   6,  33), (  16,  41), (  34,  23), (  53,  15), (  80,  -5), (  59,   2), (  32,  23), (  17,  15),
            (   5,  -3), (  15,  -3), (   2,  26), (  15,  37), (  10,  10), (  43, -16), (  -6,   4), (  20,  -2),
            (   3,   1), (  -1,  19), (   9,  14), (  19, -28), (  19,  -8), (   7,  25), (   0,  -6), (  26, -17),
            (  14,  15), (  -2, -15), (   6,  27), (  16, -34), (  17,   5), ( -13,  -7), ( -10,  39), (  13, -21),
            (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0), (   0,   0),
        };

        //Max possible moves:
        //Pawn      = 12 + zero = 13  [00..12]
        //Knight    =  8 + zero =  9  [13..21]
        //Bishop    = 13 + zero = 14  [22..35]
        //Rook      = 14 + zero = 15  [36..50]
        //Queen     = 27 + zero = 28  [51..78]
        //King      =  8 + zero =  9  [79..87]
        //--------------
        //TOTAL     = 82        = 88
        //static short[] PieceMobilityIndices = new short[8] { 0, 0, 13, 22, 36, 51, 79, 88 };

        public static (short, short)[] Mobility = new (short, short)[88]
        {
            //Pawn:
            (-8,-19), (0,0), (0,0), (0,0), (99,147), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0),
            //Knight:
            (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0),
            //Bishop:
            (32,-48), (30,0), (44,17), (44,33), (50,56), (53,69), (58,67), (59,71), (64,71), (73,62), (76,51), (81,44), (74,31), (78,37),
            //Rook:
            (-1,106), (7,105), (12,133), (18,135), (23,125), (31,119), (36,119), (47,107), (54,107), (59,107), (65,107), (72,103), (85,94), (95,69), (93,76),
            //Queen:
            (87,-5), (96,-13), (97,-2), (96,-3), (98,-28), (96,29), (92,57), (94,55), (92,77), (98,67), (98,82), (101,81), (99,107), (102,100), (116,62), (103,107), (102,116), (93,134), (103,121), (110,90), (127,84), (118,88), (129,72), (126,76), (103,60), (89,52), (29,17), (26,16),
            //King:
            (3,-7), (12,30), (19,-1), (20,-2), (6,8), (9,-19), (-5,1), (-36,20), (-29,-30),
        };        
    }
}
