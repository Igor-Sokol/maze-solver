## Task description

To model the maze a two-dimensional zero-based array is used. In array the value 0 is a cell, -1 is a wall. It is assumed that there is always a single entrance and a single exit in the maze. Look for the shortest path in the maze where there are two or more possible paths to complete the maze.
For example, to simulate a maze in the figure

![](/Maze.png)

matrix used

        {
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
            {  0,  0, -1,  0,  0,  0,  0,  0, -1,  0,  0, -1 },
            { -1,  0, -1,  0, -1, -1,  0,  0, -1, -1,  0, -1 },
            { -1,  0, -1,  0,  0, -1,  0,  0,  0,  0,  0, -1 },
            { -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1 },
            { -1,  0, -1,  0,  0, -1,  0, -1,  0,  0,  0, -1 },
            { -1,  0, -1,  0, -1, -1,  0,  0,  0, -1,  0, -1 },
            { -1,  0, -1,  0,  0,  0,  0, -1, -1, -1,  0, -1 },
            { -1,  0, -1,  0, -1,  0,  0, -1,  0, -1,  0, -1 },
            { -1,  0, -1, -1, -1, -1,  0, -1,  0, -1,  0, -1 },
            { -1,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
        }

