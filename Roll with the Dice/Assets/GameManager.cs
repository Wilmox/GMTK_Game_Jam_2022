using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DiceRoller diceRoller;
    public PlayerController playerController;

    public Countdown countdown;
    public NavigationController navigationController;

    public int diceResult = 0;

    // Start is called before the first frame update
    void Start()
    {
        diceRoller = gameObject.GetComponent<DiceRoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            StartGame();
        }
    }

    public void StartGame() {
        StartTurn();
    }

    public void StartTurn() {
        diceRoller.RollDices(DiceResultCallback);
        StartTimer();
    }

    public void DiceResultCallback(int result) {
        diceResult = result;
    }

    public void StartTimer() {
        countdown.Restart(OnTimerEnd);
    }

    public void OnTimerEnd() {
        AddMoves();
    }

    public void AddMoves() {
        navigationController.AddMoves(diceResult, StartTurn);
    }
}
