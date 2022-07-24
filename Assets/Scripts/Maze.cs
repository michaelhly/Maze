using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour
{
    public MazeCoordinates size;
    public float generationStepDelay;

    public MazeCell cellPrefab;

    private MazeCell[,] cells;

    public MazeCell GetCell(MazeCoordinates coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }

    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[size.x, size.z];
        MazeCoordinates coordinates = RandomCoordinates;
        while (ContainsCoordinates(coordinates) && GetCell(coordinates) == null)
        {
            yield return delay;
            CreateCell(coordinates);
            coordinates += MazeDirections.RandomValue.ToMazeCoordiantes();
        }
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

    private void CreateCell(MazeCoordinates coords)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[coords.x, coords.z] = newCell;
        newCell.name = "Maze Cell " + coords.x + ", " + coords.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coords.x - size.x * 0.5f + 0.5f, 0f, coords.z - size.z * 0.5f + 0.5f);
    }
}