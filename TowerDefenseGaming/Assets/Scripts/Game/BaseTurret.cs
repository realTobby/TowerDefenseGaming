using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public float Range = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();
    }

    private void FindNearestEnemy()
    {
        foreach(var troop in GameManager.Instance.TroopManager.AliveTroops)
        {
            if(troop != null)
            {
                if (Vector3.Distance(troop.transform.position, transform.position) < Range)
                {
                    this.transform.LookAt(troop.transform);
                }
            }
            
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Range);
    }

}
