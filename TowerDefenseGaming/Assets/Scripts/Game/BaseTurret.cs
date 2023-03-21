using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public float Range = 1;

    public bool TargetLocked = false;
    public GameObject CurrentTarget = null;

    public bool DEBUG_SHOW_RANGE_GIZMO = false;
    public bool DEBUG_SHOW_AIMLOCK = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();
        AimAtTroop();


    }


    private void AimAtTroop()
    {
        if(CurrentTarget != null)
            this.transform.LookAt(CurrentTarget.transform);
    }

    private void FindNearestEnemy()
    {
        foreach(var troop in GameManager.Instance.TroopManager.AliveTroops)
        {
            if(troop != null)
            {
                if (Vector3.Distance(troop.transform.position, transform.position) < Range)
                {
                    if(TargetLocked == false && CurrentTarget == null)
                    {
                        CurrentTarget = troop;
                        TargetLocked = true;
                    }
                }
                else
                {
                    if(CurrentTarget == troop)
                    {
                        CurrentTarget = null;
                        TargetLocked = false;
                    }
                }
            }
            
        }
        
    }

    private void OnDrawGizmos()
    {
        if(DEBUG_SHOW_RANGE_GIZMO)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.position, Range);
        }
        
        if(DEBUG_SHOW_AIMLOCK)
        {
            if (TargetLocked && CurrentTarget != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(this.transform.position, CurrentTarget.transform.position);
            }
        }
        

    }

}
