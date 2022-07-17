using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public float diceCount= 2;
    //public GameObject[] diceModels;
    public GameObject diceObject;
    public List<Dice> dices;
    public bool resulted = true;
    public float sphereSize = 10;
    // Start is called before the first frame update
    
    public delegate void DiceResultCallback(int result);
    public DiceResultCallback diceResultCallback;
    void Start()
    {
        for (int i = 0; i < diceCount; i++)
        {

            dices.Add(Instantiate(diceObject, transform.position + Random.insideUnitSphere * sphereSize, transform.rotation).GetComponent<Dice>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!resulted) {
            if (dices.TrueForAll(d => d.resulted)) {
                int total = 0;
                foreach (var dice in dices)
                {
                    total += dice.result;
                }
                diceResultCallback?.Invoke(total);;
                resulted = true;
            }
        }
    }

    public void RollDices(DiceResultCallback callback) {
        diceResultCallback = callback;
        resulted = false;
        foreach (var dice in dices)
        {
            dice.Roll(DiceMovedCallback);
        }
    }

    public void ReCollectDice() {
        foreach (var dice in dices)
        {
            if (dice.transform.position.y < transform.position.y) {
                Debug.Log(dice.transform.position.y + " >= " + transform.position.y);
                dice.ApplyForce((transform.position - dice.transform.position) * Time.deltaTime * 200);
            } else {
                dice.FreezePosition();
            }
        }
    }

    public void DiceMovedCallback() {
        resulted = false;
    }
}
