using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(5)]
public class BaseTroop : MonoBehaviour
{
    public int MaxHP = 10;
    public int CurrentHP = 10;

    public float Speed = 5f;

    int waypointIndex = 1;
    Vector3 currentTargetPos;

    private void GetNextWaypoint()
    {
        currentTargetPos = GameManager.Instance.GetWaypoint(waypointIndex);
        waypointIndex++;
        if(currentTargetPos.x == 666 && currentTargetPos.y == 666 && currentTargetPos.z == 666) // Pretty evil code if you know what it does. Cruel even. Caused by a hate for non-nullable values :)
        {
            SelfDestruct();
        }
        currentTargetPos.y = this.transform.position.y;
    }

    private void SelfDestruct()
    {
        GameManager.Instance.TroopManager.RemoveTroop(this.gameObject);
        Destroy(this.gameObject);
    }


    IEnumerator Move()
    {
        float time = 0;
        Vector3 startPosition = this.transform.position;
        if (startPosition == currentTargetPos) yield return null;
        while (AmIAtTarget(this.transform.position, currentTargetPos) == false)
        {
            transform.position = Vector3.Lerp(startPosition, currentTargetPos, time);
            time += Time.deltaTime * Speed;
            yield return null;
        }

        GetNextWaypoint();
        StartCoroutine(nameof(Move));
    }

    private bool AmIAtTarget(Vector3 a, Vector3 b)
    {
        if(a.x == b.x && a.z == b.z) // because in our game, the troops dont actually care about their y-dimension :)
        {
            return true;
        }

        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        GetNextWaypoint();
        StartCoroutine(nameof(Move));

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHP <= 0)
        {
            SelfDestruct();
        }
    }
}
