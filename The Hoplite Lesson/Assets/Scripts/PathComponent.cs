using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathComponent : MonoBehaviour
{
    public GameObject[] wayPoints;
    // Start is called before the first frame update
    
    public GameObject getNextWaypoint()
    {
        
        for (int i = wayPoints.Length - 1; i != -1; i--) {
            if (wayPoints[i].GetComponent<WaypointComponent>().isOccupied == false) {
                
                Debug.Log(wayPoints[i].name + " is now occupied ..");
                wayPoints[i].GetComponent<WaypointComponent>().isOccupied = true;
                if (i != 0)
                    wayPoints[i-1].GetComponent<WaypointComponent>().isOccupied = false;
                return wayPoints[i];
            } else {
                Debug.Log(wayPoints[i].name + " is occupied !");
            }
        }
        return (null);
    }

    public bool isFull()
    {
        for (int i = 0; i != wayPoints.Length; i++) {
            if (wayPoints[i].GetComponent<WaypointComponent>().isOccupied == false)
                return false;
        }
        return true;
    }
    
}
