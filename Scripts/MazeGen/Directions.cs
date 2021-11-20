﻿using System;

namespace Demonomania.Scripts.MazeGen {
    [Flags]
    public enum Directions {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8,
    }
}