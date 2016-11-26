﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public enum Parts
    {
        Wall = (int)'#',
        Empty = (int)'-',
        Player = (int)'@',
        Goal = (int)'.',
        Block = (int)'$',
        BlockOnGoal = (int)'*',
        PlayerOnGoal = (int)'+'
    };
    public interface iFileable
    {
        char WhatsAt(int row, int column);
        int GetColumnCount();
        int GetRowCount();
    }
}
