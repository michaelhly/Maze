using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public MazeCoordinates coords;

    private int initializedEdgeCount;
    private readonly MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

    public bool IsFullyInitialized
    {
        get
        {
            return initializedEdgeCount == MazeDirections.Count;
        }
    }

    public MazeCellEdge GetEdge(MazeDirection direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(MazeDirection direction, MazeCellEdge edge)
    {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    // Randomly decide how many uninitialized directions we should skip
    public MazeDirection RandomUninitializedDirection
    {
        get
        {
            int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
            for (int i = 0; i < MazeDirections.Count; i++)
            {
                if (edges[i] == null)   // Hole found!
                {
                    if (skips == 0) // Out of skips, take this direction!
                    {
                        return (MazeDirection)i;
                    }
                    skips -= 1; // Skip this direction and decrement skips counter ...
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }

    public override string ToString()
    {
        return string.Format(
            "MazeCell(x:{0}, z:{1})", coords.x, coords.z
        );
    }
}
