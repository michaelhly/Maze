using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour
{
    public MazeCoordinates size;
    public float generationStepDelay;

    public MazeCell cellPrefab;

    private MazeCell[,] cells;

    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[size.x, size.z];
        List<MazeCell> activeCells = new List<MazeCell>();
        DoFirstGenerationStep(activeCells);
        while (activeCells.Count > 0)
        {
            Debug.Log(activeCells);
            yield return delay;
            DoNextGenerationStep(activeCells);
        }
    }

    public MazeCell GetCell(MazeCoordinates coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }

    public MazeCoordinates RandomCoordinates
    {
        get
        {
            return new MazeCoordinates(Random.Range(0, size.x), Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates(MazeCoordinates coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
    }

    private MazeCell CreateCell(MazeCoordinates coords)
    {
        MazeCell newCell = Instantiate(cellPrefab);
        cells[coords.x, coords.z] = newCell;
        newCell.coords = coords;
        newCell.name = "Maze Cell " + coords.x + ", " + coords.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coords.x - size.x * 0.5f + 0.5f, 0f, coords.z - size.z * 0.5f + 0.5f);
        return newCell;
    }

    private void DoFirstGenerationStep(List<MazeCell> activeCells)
    {
        activeCells.Add(CreateCell(RandomCoordinates));
    }

    private void DoNextGenerationStep(List<MazeCell> activeCells)
    {
        int currentIndex = activeCells.Count - 1;
        MazeCell currentCell = activeCells[currentIndex];
        MazeDirection direction = MazeDirections.RandomValue;
        MazeCoordinates coordinates = currentCell.coords + direction.ToMazeCoordiantes();
        if (ContainsCoordinates(coordinates) && GetCell(coordinates) == null)
        {
            activeCells.Add(CreateCell(coordinates));
        }
        else
        {
            activeCells.RemoveAt(currentIndex);
        }
    }
}