using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopliteComponent : MonoBehaviour
{
    public GameObject target;
    private EventComponent EventHandler;
    // Start is called before the first frame update
    void Start()
    {
        EventHandler = GameObject.Find("EventHandler").GetComponent<EventComponent>();
    }

    private bool isDecisionRight(bool accepted)
    {
        return (target.GetComponent<PhilosopherComponent>().question.GetComponent<QuestionComponent>().answer == accepted);
    }

    public void AnswerCorrectly()
    {
            //zeus
            //change animation hoplite
    }
    
    public void AnswerIncorrectly()
    {
        Debug.Log("Wrong Answer !");
        // gain time
    }

    public void KickOut()
    {
        Debug.Log("Kick out");
        target.GetComponent<PhilosopherComponent>().GetKickedOut();
        EventHandler.InvokePhilosopherLeft();
        target = null;
        //Change animation hoplite
        //Remonter vie
    }

    public void LetInside()
    {
        Debug.Log("let inside");
        target.GetComponent<PhilosopherComponent>().GetInside();
        EventHandler.InvokePhilosopherLeft();
        target = null;
        //Change animation hoplite
        //Remonter vie
    }

    public void TryKickOut()
    {
        if (isDecisionRight(false) == true) {
            KickOut();
        } else {
            AnswerIncorrectly();
        }
    }

    public void TryLetInside()
    {
        if (isDecisionRight(true) == true) {
            LetInside();
        } else {
            AnswerIncorrectly();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                TryKickOut();
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                TryLetInside();
            }
        }
    }
}
