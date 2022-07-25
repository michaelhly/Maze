using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public MazeCoordinates coords;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override string ToString()
    {
        return string.Format(
            "MazeCell(x:{0}, z:{1})", coords.x, coords.z
        );
    }
}
