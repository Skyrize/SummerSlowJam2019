using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusController : MonoBehaviour
{
    public float speed = 0.5f;
    public float limitationSliding = 0.5f;

    private float yStart;
    private int direction = 1;

    void Start()
    {
        yStart = transform.position.y;
    }

    void Update()
    {
        DirectionToggle();
        
        Vector2 movement = new Vector2  (0, direction);
        GetComponent<Rigidbody2D>().AddForce(movement * speed);
    }

    // Direction reverse
    void DirectionToggle()
    {
        // limitation top and bottom
        if (yStart + limitationSliding > transform.position.y && direction == -1) {
            direction = 1;
        }

        // limitation bottom
        if (yStart - limitationSliding < transform.position.y && direction == 1) {
            direction = -1;
        }
    }
}
