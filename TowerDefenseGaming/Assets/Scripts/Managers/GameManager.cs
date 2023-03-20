using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    public GameObject WayPointsRoot;

    public GameObject Troop;
    public float TroopSpeed;
    private GameObject[] WayPointsArray;

    private Vector3 CurrentGoalPosition;
    private int CurrentWayPointIndex = 0;

    private void Awake()
    {
        _instance = this;
    }

    public Vector3 GetWaypoint(int index)
    {
        if(index < WayPointsArray.Length)
        {
            return WayPointsArray[index].transform.position;
        }
        return new Vector3(666,666,666);
    }

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
