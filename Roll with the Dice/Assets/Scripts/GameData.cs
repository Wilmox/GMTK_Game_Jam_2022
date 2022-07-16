using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static Texture2D[] navigationTileIcons;

    void Awake() {
        navigationTileIcons = Resources.LoadAll<Texture2D>("NavigationTileIcons");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
