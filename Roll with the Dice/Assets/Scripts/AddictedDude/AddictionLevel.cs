using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddictionLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider addictionBar;
    public Image addictionBarCool;

    // float AddictionLevel = player.getAddictionLevel()
    float addictionLevel, maxAddictionLevel = 100f;
    float lerpSpeed;

    void Start()
    {
        addictionLevel = maxAddictionLevel; 
    }

    // Update is called once per frame
    void Update()
    {
        if (addictionLevel > maxAddictionLevel) addictionLevel = maxAddictionLevel;

        lerpSpeed = 3f * Time.deltaTime;
        addictionBar.value = Mathf.Lerp(addictionBar.value, addictionLevel / maxAddictionLevel, lerpSpeed);
        addictionBarCool.fillAmount = Mathf.Lerp(addictionBarCool.fillAmount, addictionLevel / maxAddictionLevel, lerpSpeed);
        
        ChangeColors();
    }

    public void increaseAddictionLevel(float addictionPoints) 
    {
        if (addictionLevel < maxAddictionLevel) {
            addictionLevel += addictionPoints;
        }
    }

    public void decreaseAddictionLevel(float addictionPoints) 
    {
        if (addictionLevel > 0) {
            addictionLevel -= addictionPoints;
        }
    }

    void ChangeColors() {
        Color addictionColor = Color.Lerp(Color.green, Color.magenta, (addictionLevel / maxAddictionLevel));
        addictionBarCool.color = addictionColor;
    }

}
