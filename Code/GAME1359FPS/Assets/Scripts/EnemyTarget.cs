using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField, Header("Targets")]
    Transform[] targets;
    int targetIndex = 0;

    Transform currentTarget;

    [SerializeField, Header("Movement Speed")]
    float speed;

    [SerializeField, Header("Distance")]
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        updateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Lerp = Linear Interpolation
        // Takes two positions and a float for time
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < dist)
        {
            targetIndex++;
            if(targetIndex >= targets.Length)
            {
                targetIndex = 0;
            }
            updateTarget();
        }
    }

    void updateTarget()
    {
        currentTarget = targets[targetIndex];
    }
}
