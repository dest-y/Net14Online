﻿using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Terminator3000 : BaseCreature
    {
        
        public Terminator3000(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Gray) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "(";

        public override BaseCell ChooseCellToStep()
        {
            var _random = new Random();
            var cells = Level.GetNearCells<BaseCell>(this);
            cells = cells.Except(cells.OfType<Wall>()).ToList();
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;

        }

        public override bool Step(BaseCreature creature)
        {
            if (creature is Terminator3000)
            {
                return false;
            }

            creature.Money /= 3;
            return false;
        }
    }
}
