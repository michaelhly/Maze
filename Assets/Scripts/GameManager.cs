using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;

    private Maze mazeInstance;

    public Player playerPrefab;

    private Player playerInstance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        // Set the main camera to cover the entire view before we start generating the maze.
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);

        mazeInstance = Instantiate(mazePrefab);
        yield return StartCoroutine(mazeInstance.Generate());

        // Instantiate a new player after the maze has finished generating.
        playerInstance = Instantiate(playerPrefab);
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));


        Camera.main.clearFlags = CameraClearFlags.Depth;
        // Turn the main camera into a smaller overlay by reducing its view rectangle after a maze has been generated
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }
}
