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
        
    }

    public void StartGame() {

    }

    public void StartTurn() {
    }

    public void StartTimer() {

    }
}
