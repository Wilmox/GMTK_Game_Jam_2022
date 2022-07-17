using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float AddictionPercentage = 100f;
    public float money = 100f;
    public float happiness = 0f;
    public Text happinessMeter;
    public Text endScreenHappiness;
    //public Slider addictionBar;
    public Image addictionBar;
    float addictionLevel, maxAddictionLevel = 100f;
    float moneyCountValue = 500;
    float maxMoneyCount = 1000;
    
    public Text moneyCountText;
    public Text endScreenText;
    float lerpSpeed;
    Color addictionColor;
    Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        //TimerController.instance.BeginTimer();
        addictionLevel = maxAddictionLevel;
        moneyCountValue = maxMoneyCount;
        
        ColorUtility.TryParseHtmlString("#711CFD", out startColor);
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountText.text = moneyCountValue.ToString();
        endScreenText.text = moneyCountValue.ToString();
        happinessMeter.text = happiness.ToString();
        if (addictionLevel > maxAddictionLevel) addictionLevel = maxAddictionLevel;

        lerpSpeed = 3f * Time.deltaTime;
        //addictionBar.value = Mathf.Lerp(addictionBar.value, addictionLevel / maxAddictionLevel, lerpSpeed);
        addictionBar.fillAmount = Mathf.Lerp(addictionBar.fillAmount, addictionLevel / maxAddictionLevel, lerpSpeed);

        
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
        Color addictionColor = Color.Lerp(Color.green, startColor, (addictionLevel / maxAddictionLevel));
        addictionBar.color = addictionColor;
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
