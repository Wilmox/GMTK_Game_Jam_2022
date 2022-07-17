using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float secondsToRotate = 20f;
    float secondsElapsed = 0f;
    Vector3 targetLeft;
    Vector3 targetRight;
    //Vector3 lerpPoint;
    // Start is called before the first frame update
    void Start()
    {
        targetLeft = new Vector3(260f, 16f, -140f);
        targetRight = new Vector3(50f, 16f, -11f);

        /*if (transform.rotation == targetLeft)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRight, rotationSpeed * Time.deltaTime);
        }

        if (transform.rotation == targetRight) 
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLeft, rotationSpeed * Time.deltaTime);
        }*/
    }

    // Update is called once per frame
    void Update()
    {   secondsElapsed += Time.deltaTime;

        Vector3 lerpPoint = Vector3.Lerp(targetLeft, targetRight, secondsElapsed / secondsToRotate);
        

        /*if(secondsElapsed.Equals(secondsToRotate)) {
            secondsElapsed = 0f;
            lerpPoint = Vector3.Lerp(targetRight, targetLeft, secondsElapsed / secondsToRotate);
        }*/
        transform.rotation = Quaternion.LookRotation(lerpPoint);
        Debug.Log("Looking at: " + lerpPoint);

    }
}
