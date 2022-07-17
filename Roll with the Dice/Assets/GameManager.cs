using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DiceRoller diceRoller;

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
    }

    public void DiceResultCallback(int result) {
        Debug.Log(result);
        StartTimer();
    }

    public void StartTimer() {

    }
}
