using UnityEngine;
using System.Collections.Generic;

namespace Yee.Math
{
    public abstract class MazeDrawer : MonoBehaviour
    {
        [SerializeField] protected int mazeWidth;
        [SerializeField] protected int mazeDepth;
        [SerializeField] protected int scale;

        protected byte[,] map;

        protected List<ZVector2Int> directions = new List<ZVector2Int>() {
                                                        new ZVector2Int(1, 0),
                                                        new ZVector2Int(0, 1),
                                                        new ZVector2Int(-1, 0),
                                                        new ZVector2Int(0, -1) };

        protected void InitialiseMap() //1 equals a wall, 0 equals a corridor
        {
            map = new byte[mazeWidth, mazeDepth];
            for (int z = 0; z < mazeDepth; z++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    map[x, z] = 1;
                }
            }
        }

        protected void DrawMap()
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    if (map[x, z] == 1)
                    {
                        Vector3 pos = new Vector3(x * scale, 0, z * scale);
                        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        wall.transform.localScale = Vector3.one * scale;
                        wall.transform.position = pos;
                    }
                }
            }
        }

        protected int CountAllNeighbours(int x, int z) { return CountSquareNeighbours(x, z) + CountDiagonalNeighbours(x, z); }

        protected int CountSquareNeighbours(int x, int z)
        {
            int count = 0;
            if (x <= 0 || x >= mazeWidth - 1 || z <= 0 || z >= mazeDepth - 1) { return 5; }
            if (map[x - 1, z] == 0) { count++; }
            if (map[x + 1, z] == 0) { count++; }
            if (map[x, z + 1] == 0) { count++; }
            if (map[x, z - 1] == 0) { count++; }

            return count;
        }

        protected int CountDiagonalNeighbours(int x, int z)
        {
            int count = 0;
            if (x <= 0 || x >= mazeWidth - 1 || z <= 0 || z >= mazeDepth - 1) { return 5; }
            if (map[x - 1, z + 1] == 0) { count++; }
            if (map[x + 1, z + 1] == 0) { count++; }
            if (map[x - 1, z - 1] == 0) { count++; }
            if (map[x + 1, z - 1] == 0) { count++; }

            return count;
        }
    }
}