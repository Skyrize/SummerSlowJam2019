using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilosopherComponent : MonoBehaviour
{
    public GameObject hoplite;
    public GameObject question;
    // Start is called before the first frame update
    private GameObject path;

    private GameObject entry;
    void Start()
    {
        question.SetActive(false);
        path = GameObject.Find("Path");
        hoplite = GameObject.Find("Hoplite");
        entry = GameObject.Find("Entry");
    }

    public void AskQuestion()
    {
        hoplite.GetComponent<HopliteComponent>().target = gameObject;
        question.SetActive(true);
    }

    public void LeaveWaypoint()
    {
        GetComponent<PathFollowingComponent>().wayPoint.GetComponent<WaypointComponent>().isOccupied = false;
        GetComponent<PathFollowingComponent>().wayPoint = null;
    }

    public void GetKickedOut()
    {
        transform.parent = null;
        LeaveWaypoint();
        //animate
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 500));
        GetComponent<Rigidbody2D>().AddTorque(500);
        question.SetActive(false);
        
    }

    private bool isAllowedInside = false;
    public void GetInside()
    {
        transform.parent = null;
        LeaveWaypoint();
        isAllowedInside = true;
    }

    // Update is called once per frame
    private float speed = 5;
    void Update()
    {
        if (question.activeInHierarchy == false && Vector3.Distance(transform.position, path.GetComponent<PathComponent>().wayPoints[path.GetComponent<PathComponent>().wayPoints.Length - 1].transform.position) < 0.001f)
            AskQuestion();
        if (isAllowedInside) {
            if (Vector3.Distance(transform.position, entry.transform.position) < 0.001f) {
                Destroy(this.gameObject);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, entry.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
