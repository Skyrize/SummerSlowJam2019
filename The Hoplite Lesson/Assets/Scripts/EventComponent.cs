using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventComponent : MonoBehaviour
{
    //public UnityEvent philosopherLeft;
    public GameObject path;

    public GameObject crowd;
    // private Color[] colors = new Color[7];

    private void Start() {
        path = GameObject.Find("Path");
        crowd = GameObject.Find("Crowd");
        // colors[0] = new Color(0, 0, 0);
        // colors[1] = new Color(255, 0, 0);
        // colors[2] = new Color(0, 255, 0);
        // colors[3] = new Color(0, 0, 255);
        // colors[4] = new Color(255, 255, 0);
        // colors[5] = new Color(0, 255, 255);
        // colors[6] = new Color(255, 0, 255);
    }
    public void InvokePhilosopherLeft()
    {
        for (int i = 0; i != crowd.transform.childCount; i++) {
            // crowd.transform.GetChild(i).GetComponent<SpriteRenderer>().color = colors[i];
            crowd.transform.GetChild(i).GetComponent<PathFollowingComponent>().findNewPlace();
        }
    }
}
