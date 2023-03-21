using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTileSelector : MonoBehaviour
{
    // Raycasting!!!!!!!!!
    // We use rays that are casted from the maincamera calculated with the current mouse position on the screen, if they hit a PlayTile
    // we react to it! For example: changing the material of the groundTile with another material!
    // and when mouse-ray dont hit anything, switch back
    // We need, Raycasting, MousePosition, a seperate basetile script that handles the selection (for later gamplay aspects!!)

    public BasePlayTile LastSelectedTile;

    public GameObject Prefab_Turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void HandleMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("MouseInteraction")))
        {
            if(hit.transform.CompareTag("PlayTile"))
            {
                if (LastSelectedTile != null)
                {
                    LastSelectedTile.DeSelect();
                    LastSelectedTile = null;
                }

                LastSelectedTile = hit.transform.GetComponent<BasePlayTile>();
                LastSelectedTile.Select();
            }
            else
            {
                if(LastSelectedTile != null)
                {
                    LastSelectedTile.DeSelect();
                    LastSelectedTile = null;
                }
            }
        }
        else
        {
            if (LastSelectedTile != null)
            {
                LastSelectedTile.DeSelect();
                LastSelectedTile = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseOver();
        HandleMouseClick();
    }

    private void HandleMouseClick()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (LastSelectedTile != null)
            {
                LastSelectedTile.BuildTurret(Prefab_Turret);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            if(LastSelectedTile != null)
            {
                LastSelectedTile.RemoveBuilding();
            }
        }
        
    }

}
