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
    public float sphereSice = 10;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < diceCount; i++)
        {

            dices.Add(Instantiate(diceObject, transform.position + Random.insideUnitSphere * sphereSice, transform.rotation).GetComponent<Dice>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RollDices();
        }

        if (Input.GetKey(KeyCode.R)) {
            ReCollectDice();
        }

        if (!resulted) {
            if (dices.TrueForAll(d => d.resulted)) {
                int total = 0;
                foreach (var dice in dices)
                {
                    total += dice.result;
                }
                Debug.Log(total);
                resulted = true;
            }
        }
    }

    public void RollDices() {
        resulted = false;
        foreach (var dice in dices)
        {
            dice.Roll();
        }
    }

    public void ReCollectDice() {
        foreach (var dice in dices)
        {
            if (Vector3.Distance(dice.transform.position, transform.position) > 4) {
                dice.ApplyForce((transform.position - dice.transform.position) * Time.deltaTime * 200);
            } else {
                dice.FreezePosition();
            }
        }
    }
}
