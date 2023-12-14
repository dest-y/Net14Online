﻿using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{

    public class Thief : BaseCreature
    {
        private int _robMoney = 10;

        private Random _random = new Random();

        public Thief(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "t";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(BaseCreature creature)
        {
            if (creature is Hero)
            {
                if (creature.Money > _robMoney)
                {
                    creature.Money -= 10;
                }
                else
                {
                    creature.Money = 0;
                }
            }
            return true;
        }
    }
}