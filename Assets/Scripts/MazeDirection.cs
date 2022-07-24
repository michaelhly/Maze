using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeDirection
{
    North,
    East,
    South,
    West
}

public static class MazeDirections
{

    public const int Count = 4;

    public static MazeDirection RandomValue
    {
        get
        {
            return (MazeDirection)Random.Range(0, Count);
        }
    }

    private static MazeCoordinates[] vectors = {
        new MazeCoordinates(0, 1),
        new MazeCoordinates(1, 0),
        new MazeCoordinates(0, -1),
        new MazeCoordinates(-1, 0)
    };

    public static MazeCoordinates ToMazeCoordiantes(this MazeDirection direction)
    {
        return vectors[(int)direction];
    }
}