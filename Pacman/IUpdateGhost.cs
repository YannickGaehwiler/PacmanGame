﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public interface IUpdateGhost
    {
        void MoveGhostPanel(int row, int column);
    }
}
