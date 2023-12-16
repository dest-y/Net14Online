﻿using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class Hero : BaseCreature
    {
        public override string Symbol => "H";

        public Hero(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkYellow) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override bool Step(IBaseCreature creature)
        {
            throw new NotImplementedException();
        }

        public override IBaseCell ChooseCellToStep()
        {
            throw new NotImplementedException();
        }
    }
}
