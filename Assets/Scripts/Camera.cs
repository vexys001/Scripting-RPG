using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Tracking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float diffX = Tracking.transform.position.x - transform.position.x;
        float diffY = Tracking.transform.position.y - transform.position.y;

        Vector2 dist = new Vector2(diffX, diffY);

        if (dist.magnitude > 0.5f)
        {
            transform.Translate(dist * Time.deltaTime);
        }
    }
}
