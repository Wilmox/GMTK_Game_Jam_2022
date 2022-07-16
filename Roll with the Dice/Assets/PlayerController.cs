using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float AddictionPercentage = 100f;
    public float money = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAddictionPercentage(float newPercentage) {
        AddictionPercentage = Mathf.Clamp(newPercentage, 0f, 100f);
    }
}
