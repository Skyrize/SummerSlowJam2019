using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilosopherComponent : MonoBehaviour
{
    public GameObject hoplite;
    public GameObject question;
    // Start is called before the first frame update
    private GameObject path;
    void Start()
    {
        question.SetActive(false);
        path = GameObject.Find("Path");
        hoplite = GameObject.Find("Hoplite");
    }

    public void AskQuestion()
    {
        Debug.Log("Asking question ..");
        hoplite.GetComponent<HopliteComponent>().target = gameObject;
        question.SetActive(true);
    }

    public void LeaveWaypoint()
    {
        path.GetComponent<PathComponent>().wayPoints[path.GetComponent<PathComponent>().wayPoints.Length - 1].GetComponent<WaypointComponent>().isOccupied = false;
    }

    public void GetKickedOut()
    {
        LeaveWaypoint();
        //animate
        Debug.Log("Get Kicked out !");
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 10));
    }

    public void GetInside()
    {
        LeaveWaypoint();
        Debug.Log("Get inside !");
        GetComponent<Rigidbody2D>().simulated = true;
        //animate
        GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10));

    }

    // Update is called once per frame
    void Update()
    {
        if (question.activeInHierarchy == false && Vector3.Distance(transform.position, path.GetComponent<PathComponent>().wayPoints[path.GetComponent<PathComponent>().wayPoints.Length - 1].transform.position) < 0.001f)
            AskQuestion();
    }
}
