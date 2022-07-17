using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DiceRoller diceRoller;
    public PlayerController playerController;

    public Countdown countdown;
    public NavigationController navigationController;

    public int diceResult = 0;

    public Text diceText;

    // Start is called before the first frame update
    void Start()
    {
        diceRoller = gameObject.GetComponent<DiceRoller>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
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
        diceText.text = diceResult.ToString();
    }

    public void OnDiceRecollected() {
        diceRoller.recollect = false;
        StartTurn();
    }

    public void StartTimer() {
        countdown.Restart(OnTimerEnd);
    }

    public void OnTimerEnd() {
        AddMoves();
    }

    public void ReCollectDice() {
        diceRoller.StartRecollectingDice(OnDiceRecollected);
    }

    public void AddMoves() {
        navigationController.AddMoves(diceResult, ReCollectDice);
    }
}
