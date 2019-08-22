using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventComponent : MonoBehaviour
{
    //public UnityEvent philosopherLeft;

    public void InvokePhilosopherLeft()
    {
        //philosopherLeft.Invoke();
        //GameObject[] philosophers = GameObject.FindGameObjectsWithTag("Philosopher");

        //for (int i = 0; i != philosophers.Length; i++)
        //    philosophers[i].GetComponent<PathFollowingComponent>().findNewPlace();
    }
}
