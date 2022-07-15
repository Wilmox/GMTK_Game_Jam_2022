using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public static NavigationController navigationController;
    public NavigationTile currentTile;
    public GameObject player;

    private bool runOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        navigationController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (runOnce) {
            EnableNextTileSelection(true);
            runOnce = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            GetNextTiles();
        }
        MovePlayer();
    }

    private void GetNextTiles() {
        foreach (var nextTile in currentTile.nextTiles)
        {
            Debug.Log(nextTile.tileName);
        }
    }

    private void EnableNextTileSelection(bool enable = true) {
        foreach (var nextTile in currentTile.nextTiles)
        {
            nextTile.EnableSelection(enable);
        }
    } 

    private void MovePlayer() {
        player.transform.position = Vector3.Lerp(player.transform.position, currentTile.gameObject.transform.position + Vector3.up, 3f * Time.deltaTime);
    }

    public void SetCurrentTile(NavigationTile navigationTile) {
        EnableNextTileSelection(false);
        currentTile = navigationTile;
        EnableNextTileSelection(true);
    }
}
