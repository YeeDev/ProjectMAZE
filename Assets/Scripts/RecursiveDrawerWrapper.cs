using UnityEngine;
using Yee.Math;

namespace Maze.Core
{
    public class RecursiveDrawerWrapper : MazeDrawer
    {
        private void Awake()
        {
            GenerateMaze();
        }

        private void GenerateMaze()
        {
            InitialiseMap();
            RecursiveDrawer(Random.Range(1, mazeWidth), Random.Range(1, mazeDepth));
            DrawMap();
        }

        private void RecursiveDrawer(int x, int z)
        {
            if (CountSquareNeighbours(x, z) >= 2) { return; }
            map[x, z] = 0;

            directions.Shuffle();

            RecursiveDrawer(x + directions[0].x, z + directions[0].z);
            RecursiveDrawer(x + directions[1].x, z + directions[1].z);
            RecursiveDrawer(x + directions[2].x, z + directions[2].z);
            RecursiveDrawer(x + directions[3].x, z + directions[3].z);
        }
    }
}