using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTile : MonoBehaviour
{
    public string tileName = "Undefined name";
    public List<NavigationTile> nextTiles;
    public NavigationTileType navigationTileType = NavigationTileType.Random;
    protected Collider col;

    protected Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        mat = gameObject.GetComponent<MeshRenderer>().material;
        InitNavigationTileType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        NavigationController.navigationController.SelectNextTile(this);
    }

    public void EnableSelection(bool enable = true) {
        col.enabled = enable;
        mat.SetInt("_Selectable", enable?1:0);
    }

    private void InitNavigationTileType() {
        if (NavigationTileType.Random.Equals(navigationTileType)) {
            navigationTileType = (NavigationTileType)Random.Range(0, System.Enum.GetValues(typeof(NavigationTileType)).Length - 2);
        }
        mat.SetTexture("_TileIcon", GameData.navigationTileIcons[(int)navigationTileType]);
    }
}

public enum NavigationTileType {
    Empty,
    GetMoney,
    LoseMoney,
    Chance,
    Random,
    Custom
}
