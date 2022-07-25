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

    private static readonly MazeCoordinates[] vectors = {
        new MazeCoordinates(0, 1),
        new MazeCoordinates(1, 0),
        new MazeCoordinates(0, -1),
        new MazeCoordinates(-1, 0)
    };

    public static MazeCoordinates ToMazeCoordiantes(this MazeDirection direction)
    {
        return vectors[(int)direction];
    }

    private static readonly MazeDirection[] opposites = {
        MazeDirection.South,
        MazeDirection.West,
        MazeDirection.North,
        MazeDirection.East
    };

    public static MazeDirection GetOpposite(this MazeDirection direction)
    {
        return opposites[(int)direction];
    }

    private static readonly Quaternion[] rotations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 90f, 0f),
        Quaternion.Euler(0f, 180f, 0f),
        Quaternion.Euler(0f, 270f, 0f)
    };

    public static Quaternion ToRotation(this MazeDirection direction)
    {
        return rotations[(int)direction];
    }
}