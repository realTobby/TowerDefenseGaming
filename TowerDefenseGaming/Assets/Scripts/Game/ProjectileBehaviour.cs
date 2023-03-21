using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public Transform Target;
    public float ProjectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartProjectile(Transform target, float speed)
    {
        Target = target;
        ProjectileSpeed = speed;
        StartCoroutine(nameof(Move));
    }

    private bool AmIAtTarget(Vector3 a, Vector3 b)
    {
        if(a == null || b == null)
        {
            Destroy(this.gameObject);
        }

        if (a.x == b.x && a.z == b.z) // because in our game, the troops dont actually care about their y-dimension :)
        {
            return true;
        }

        return false;
    }

    IEnumerator Move()
    {
        float time = 0;
        Vector3 startPosition = this.transform.position;
        if (startPosition == Target.position) yield return null;
        while (Target != null && AmIAtTarget(this.transform.position, Target.position) == false)
        {
            transform.position = Vector3.Lerp(startPosition, Target.position, time);
            time += Time.deltaTime * ProjectileSpeed;
            yield return null;
        }
        Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if(Target == null)
        {
            Destroy(this.gameObject);
        }
    }
}
