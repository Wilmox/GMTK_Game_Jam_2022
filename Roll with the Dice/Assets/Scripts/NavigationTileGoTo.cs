using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTileGoTo : NavigationTileCustom
{
    public NavigationTile goToNavigationTile;

    public override void CustomEvent() {
        NavigationController.navigationController.moves += 1;
        NavigationController.navigationController.SelectNextTile(goToNavigationTile);
    }
}
