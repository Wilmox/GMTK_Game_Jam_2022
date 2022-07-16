using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NavigationTileCustom : NavigationTile
{
    public Texture2D navigationTileIcon;
    public abstract void CustomEvent();

    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        mat = gameObject.GetComponent<MeshRenderer>().material;
        InitNavigationTileType();
    }

    private void InitNavigationTileType() {
        if (NavigationTileType.Empty.Equals(navigationTileType)) {
            navigationTileType = NavigationTileType.Custom;
        }
        mat.SetTexture("_TileIcon", navigationTileIcon);
    }
}
