using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayTile : MonoBehaviour
{
    public Material BaseMaterial;
    public Material SelectedMaterial;

    public GameObject Building = null;

    public void Select()
    {
        GetComponent<MeshRenderer>().material = SelectedMaterial;
    }

    public void DeSelect()
    {
        GetComponent<MeshRenderer>().material = BaseMaterial;
    }

    public void BuildTurret(GameObject Prefab)
    {
        if(Building == null)
        {
            Building = Instantiate(Prefab, this.transform.position, Quaternion.identity);
        }
    }

    public void RemoveBuilding()
    {
        if(Building != null)
        {
            Destroy(Building);
            Building = null;
        }
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
