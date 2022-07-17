using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public List<Transform> sides;
    private Rigidbody rigy;
    public bool resulted = true;
    public int result;
    public float rerollTimer = -1f;
    public static float maxRollTime = 5f;

    public delegate void DiceMovedCallback();
    public DiceMovedCallback diceMovedCallback;
    // Start is called before the first frame update
    void Start()
    {
        rigy = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!resulted) {
            rerollTimer += Time.deltaTime;
            if (Vector3.Distance(rigy.velocity, Vector3.zero) <= .01f && rerollTimer >= 0) {
                result = GetDiceResult();
            } else if (rerollTimer >= maxRollTime) {
                Roll(diceMovedCallback);
            }
        }
    }

    public void Roll(DiceMovedCallback callback, float forceStrength = 5, float torqueStrength = 2) {
        diceMovedCallback = callback;
        rigy.constraints = RigidbodyConstraints.None;
        Vector3 forceImpulse = new Vector3(Random.Range(-1f, 1f), Random.Range(.5f, 1f), Random.Range(-1f, 1f)) * forceStrength;
        Vector3 torqueImpulse = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueStrength;
        rigy.AddForce(forceImpulse, ForceMode.Impulse);
        rigy.AddTorque(torqueImpulse, ForceMode.Impulse);
        resulted = false;
        ResetRerollTimer();
    }

    public void FreezePosition() {
        rigy.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void ApplyForce(Vector3 force) {
        rigy.AddForce(force);
        diceMovedCallback();
        ResetRerollTimer();
    }

    public void ApplyForceAtPosition(Vector3 force, Vector3 point) {
        rigy.AddForceAtPosition(force, point, ForceMode.Impulse);
        resulted = false;
        diceMovedCallback();
        ResetRerollTimer();
    }

    public int GetDiceResult() {
        int highestIndex = 0;
        for (int i = 1; i < sides.Count; i++)
        {
            if (sides[i].position.y > sides[highestIndex].position.y) {
                highestIndex = i;
            }
        }

        resulted = true;
        return highestIndex + 1;
    }

    public void ResetRerollTimer() {
        rerollTimer = -1f;
    }
}
