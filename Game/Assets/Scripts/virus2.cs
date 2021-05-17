using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus2 : MonoBehaviour
{
    public Transform[] points;

    public float speed = 2f;

    public float waitTime = 3f;

    private bool CanDo = true;

    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].position.x, points[0].position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanDo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        if (transform.position == points[i].position)
        {
            if (i < points.Length - 1)
                i++;
            else
                i = 0;
        }
    }
    
}
