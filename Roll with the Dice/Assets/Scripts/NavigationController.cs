using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public static NavigationController navigationController;
    public NavigationTile currentTile;
    public GameObject player;
    private TileEventHandler tileEventHandler;
    public int moves = 0;

    public Vector3 goToPosition;

    public NavigationState navigationState = NavigationState.Init;

    public delegate void OutOfMovesCallback();
    public OutOfMovesCallback outOfMovesCallback;

    public delegate void EndReachedCallback();
    public EndReachedCallback endReachedCallback;

    // Start is called before the first frame update
    void Start()
    {
        navigationController = this;
        tileEventHandler = gameObject.GetComponent<TileEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (navigationState)
        {
            case NavigationState.Init:
                InitState();
                break;
            case NavigationState.StartMoving:
                StartMovingState();
                break;
            case NavigationState.Moving:
                MovingState();
                break;
            case NavigationState.ReachedTile:
                ReachedTileState();
                break;
            case NavigationState.WaitForSelection:
                WaitForSelectionState();
                break;
            case NavigationState.HandlingEvent:
                HandlingEventState();
                break;
            case NavigationState.ContinueMoving:
                ContinueMovingState();
                break;
            case NavigationState.OutOfMoves:
                OutOfMovesState();
                break;
            case NavigationState.EndOfPath:
                EndOfPathState();
                break;
            default:
                break;
        }
    }

    private void InitState() {
        SetCurrentTile(currentTile);
        navigationState = NavigationState.Moving;
    }

    private void StartMovingState() {
        moves -=1;
        navigationState = NavigationState.Moving;
    }

    private void MovingState() {
        MovePlayer();
        CheckIfPlayerReachedTile();
    }

    private void ReachedTileState() {
        OnPlayerReachedTile();
    }

    private void WaitForSelectionState() {
        EnableNextTileSelection(true);
    }

    private void HandlingEventState() {
        tileEventHandler.HandleEvent(currentTile);
        if (navigationState == NavigationState.HandlingEvent) {
            navigationState = NavigationState.ContinueMoving;
        }
    }

    private void ContinueMovingState() {
        if (currentTile.nextTiles.Count == 1) {
            SetCurrentTile(currentTile.nextTiles[0]);
            navigationState = NavigationState.StartMoving;
        } else if (currentTile.nextTiles.Count > 1) {
            navigationState = NavigationState.WaitForSelection;
        } else {
            navigationState = NavigationState.EndOfPath;
        }
    }

    private void OutOfMovesState() {
        if (moves > 0) {
            navigationState = NavigationState.ReachedTile;
        } else {
            outOfMovesCallback?.Invoke();
            outOfMovesCallback = null;
        }
    }

    private void EndOfPathState() {
        Debug.Log("This is the end");
        endReachedCallback?.Invoke();
    }

    private void EnableNextTileSelection(bool enable = true) {
        foreach (var nextTile in currentTile.nextTiles)
        {
            nextTile.EnableSelection(enable);
        }
    } 

    private void MovePlayer() {
        player.transform.position = Vector3.Lerp(player.transform.position, goToPosition, 100f * Time.deltaTime);
    }

    private void CheckIfPlayerReachedTile() {
        if (Vector3.Distance(player.transform.position, goToPosition) <= 0.1f) {
            navigationState = NavigationState.ReachedTile;
        }
    }

    public void SetCurrentTile(NavigationTile navigationTile) {
        EnableNextTileSelection(false);
        currentTile = navigationTile;
        goToPosition = currentTile.gameObject.transform.position;
    }

    public void SelectNextTile(NavigationTile navigationTile) {
        SetCurrentTile(navigationTile);
        navigationState = NavigationState.StartMoving;
    }

    public void OnPlayerReachedTile() {
        if (moves == 0) {
            navigationState = NavigationState.OutOfMoves;
        } else if(moves > 0) {
            navigationState = NavigationState.HandlingEvent;
        }
    }

    public void AddMoves(int amount, OutOfMovesCallback callback) {
        outOfMovesCallback = callback;
        moves += amount;
    }
}

public enum NavigationState {
    Init,
    StartMoving,
    Moving,
    ReachedTile,
    WaitForSelection,
    HandlingEvent,
    ContinueMoving,
    OutOfMoves,
    EndOfPath,
}
