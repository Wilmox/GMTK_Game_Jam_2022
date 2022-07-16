using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float AddictionPercentage = 100f;
    public float money = 100f;
    public Slider addictionBar;
    //public Image addictionBarCool;
    float addictionLevel, maxAddictionLevel = 100f;
    float moneyCountValue, maxMoneyCount = 1000;
    
    public Text moneyCountText;
    float lerpSpeed;
    Color addictionColor;

    // Start is called before the first frame update
    void Start()
    {
        addictionLevel = maxAddictionLevel;
        moneyCountValue = maxMoneyCount;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountText.text = moneyCountValue.ToString();
        if (addictionLevel > maxAddictionLevel) addictionLevel = maxAddictionLevel;

        lerpSpeed = 3f * Time.deltaTime;
        addictionBar.value = Mathf.Lerp(addictionBar.value, addictionLevel / maxAddictionLevel, lerpSpeed);
        //addictionBarCool.fillAmount = Mathf.Lerp(addictionBarCool.fillAmount, addictionLevel / maxAddictionLevel, lerpSpeed);
        
        ChangeColors();
    }

    public void SetAddictionPercentage(float newPercentage) {
        AddictionPercentage = Mathf.Clamp(newPercentage, 0f, 100f);
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

    public void increaseMoneyCount(float increaseMoney) 
    {
        if (moneyCountValue < maxMoneyCount) {
            moneyCountValue += increaseMoney;
        }
    }

    public void decreaseMoneyCount(float decreaseMoney) 
    {
        if (moneyCountValue > 0) {
            moneyCountValue -= decreaseMoney;
        }
    }

    void ChangeColors() {
        Color addictionColor = Color.Lerp(Color.green, Color.magenta, (addictionLevel / maxAddictionLevel));
        //addictionBarCool.color = addictionColor;
        switch (moneyCountValue)
        {
            case < 0:
                addictionColor = Color.red;
                break;
            default:
                addictionColor = Color.white;
                break;
        }
        moneyCountText.color = addictionColor;
    }
}
