using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayTile : MonoBehaviour
{
    public Material BaseMaterial;
    public Material SelectedMaterial;



    public void Select()
    {
        GetComponent<MeshRenderer>().material = SelectedMaterial;
    }

    public void DeSelect()
    {
        GetComponent<MeshRenderer>().material = BaseMaterial;
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
