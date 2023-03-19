using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject WayPointsRoot;

    public GameObject Troop;
    public float TroopSpeed;
    private GameObject[] WayPointsArray;

    private Vector3 CurrentGoalPosition;
    private int CurrentWayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadWayPoints();

        // Wie könnte man die "Troop" Instanz an den WayPoints langbewegen?

    }



    private void LoadWayPoints()
    {
        WayPointsArray = new GameObject[WayPointsRoot.transform.childCount];

        for (int i = 0; i < WayPointsRoot.transform.childCount; i++)
        {
            WayPointsArray[i] = WayPointsRoot.transform.GetChild(i).gameObject;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
