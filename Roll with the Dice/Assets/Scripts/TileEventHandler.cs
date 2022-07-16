using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEventHandler : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleEvent(NavigationTile navigationTile) {
        switch (navigationTile.navigationTileType)
        {
            case NavigationTileType.Empty:
                break;
            case NavigationTileType.GetMoney:
                playerController.money += 100;
                break;
            case NavigationTileType.LoseMoney:
                playerController.money -= 100;
                break;
            case NavigationTileType.Chance:
                playerController.SetAddictionPercentage(playerController.AddictionPercentage + 10f);
                playerController.money += Random.Range(-50f, 50f);
                break;
            case NavigationTileType.Custom:
                ((NavigationTileCustom)navigationTile).CustomEvent();
                break;
            default:
                break;
        }
    }
}
