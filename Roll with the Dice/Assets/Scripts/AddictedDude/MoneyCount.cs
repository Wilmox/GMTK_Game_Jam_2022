using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyCount : MonoBehaviour
{
    // Start is called before the first frame update
    float moneyCountValue, maxMoneyCount = 1000;
    Color addictionColor;
    public Text moneyCountText;
    void Start()
    {
        moneyCountValue = maxMoneyCount;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountText.text = moneyCountValue.ToString();
        //ChangeColors();
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
