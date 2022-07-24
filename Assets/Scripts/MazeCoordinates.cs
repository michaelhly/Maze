
// Struct to help us manipluate maze coordindates as a single value
[System.Serializable]
public struct MazeCoordinates
{
    public int x, z;

    public MazeCoordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static MazeCoordinates operator +(MazeCoordinates a, MazeCoordinates b)
    {
        a.x += b.x;
        a.z += b.z;
        return a;
    }
}
