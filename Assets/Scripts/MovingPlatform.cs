using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform start, end;
    public Transform BeginPoint;
    Vector3 nextposition;
    // Start is called before the first frame update
    void Start()
    {
        nextposition = start.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position == start.position)
        {
            nextposition = end.position;
        }
        if (transform.position == end.position)
        {
            nextposition = start.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextposition, speed * Time.deltaTime);
    }
}
