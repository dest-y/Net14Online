﻿using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV18(12, 7);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);
