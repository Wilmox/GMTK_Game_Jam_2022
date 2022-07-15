using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTile : MonoBehaviour
{
    public string tileName = "Undefined name";
    public List<NavigationTile> nextTiles;
    private Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        NavigationController.navigationController.SetCurrentTile(this);
    }

    public void EnableSelection(bool enable = true) {
        col.enabled = enable;
    }
}
