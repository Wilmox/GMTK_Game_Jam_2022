using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTile : MonoBehaviour
{
    public string tileName = "Undefined name";
    public List<NavigationTile> nextTiles;
    private Collider col;

    private Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        mat = gameObject.GetComponent<MeshRenderer>().material;
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
        mat.SetInt("_Selectable", enable?1:0);
    }
}
