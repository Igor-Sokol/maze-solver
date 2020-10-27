## Task description

A two-dimensional zero-based boolean array  is used to model the maze. In array the value `false` is a cell, `true` is a wall. For example, the matrix is used

        {
            { true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true  },
            { false, false, true,  false, false, false, false, false, true,  false, false, true  },
            { true,  false, true,  false, true,  true,  false, false, true,  true,  false, true  },
            { true,  false, true,  false, false, true,  false, false, false, false, false, true  },
            { true,  false, true,  true,  false, true,  true,  true,  true,  true,  true,  true  },
            { true,  false, true,  false, false, true,  false, true,  false, false, false, true  },
            { true,  false, true,  false, true,  true,  false, false, false, true,  false, true  },
            { true,  false, true,  false, false, false, false, true,  true,  true,  false, true  },
            { true,  false, true,  false, true,  false, false, true,  false, true,  false, true  },
            { true,  false, true,  true,  true,  true,  false, true,  false, true,  false, true  },
            { true,  false, false, false, false, false, false, true,  false, false, false, false },
            { true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true  }
        }

to simulate the next maze

![](/Maze.png)

Implements a methods of the MazeSolver that look for the shortest path in the maze where there are two or more possible paths to complete the maze.  It is assumed that there is always a single entrance and a single exit in the maze. The task definition is given in the XML-comments for this methods. 