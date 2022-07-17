using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatsNavigationTile : NavigationTileCustom
{
    public PlayerController playerController;
    public float moneyChange = 0;
    public float happinessChange = 0;
    // Start is called before the first frame update

    public override void CustomEvent()
    {
        Debug.Log(moneyChange);
        playerController.moneyCountValue += moneyChange;
        playerController.happiness += happinessChange;
    }
}
