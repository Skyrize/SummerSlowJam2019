using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingComponent : MonoBehaviour
{
    public float speed = 5;
    private GameObject path;
    public GameObject wayPoint;
    private GameObject oldWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.Find("Path");
        findNewPlace();
    }

    public void findNewPlace()
    {
        if (path.GetComponent<PathComponent>().isFull() == false) {
            wayPoint = path.GetComponent<PathComponent>().getNextWaypoint();

            // if (!oldWayPoint || wayPoint.name != oldWayPoint.name) {
            //     oldWayPoint = wayPoint;
            // }

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoint) {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint.transform.position, speed * Time.deltaTime);  
            
            if (transform.position == Vector3.MoveTowards(transform.position, wayPoint.transform.position, speed * Time.deltaTime)) {
                GetComponent<Animator>().Play("philosopher1_idle");
            } else {
               GetComponent<Animator>().Play("philosopher1_walk");
            }
        }


    }
}
