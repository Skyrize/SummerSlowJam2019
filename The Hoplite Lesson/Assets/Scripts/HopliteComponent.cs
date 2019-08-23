using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopliteComponent : MonoBehaviour
{
    public GameObject target;
    private EventComponent EventHandler;
    private HealthBarComponent healthBar;
    private ThunderboldHandler flashCamera;

    // Start is called before the first frame update
    void Start()
    {
        EventHandler = GameObject.Find("EventHandler").GetComponent<EventComponent>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarComponent>();
        flashCamera = GameObject.Find("Flash").GetComponent<ThunderboldHandler>();
    }

    private bool isDecisionRight(bool accepted)
    {
        Debug.Log(target.GetComponent<PhilosopherComponent>().question.GetComponent<QuestionComponent>().answer);
        return (target.GetComponent<PhilosopherComponent>().question.GetComponent<QuestionComponent>().answer == accepted);
    }

    public void AnswerCorrectly()
    {
        healthBar.addHealth(20);
            //change animation hoplite
    }
    
    public void AnswerIncorrectly()
    {
        healthBar.removeHealth(10);
        Debug.Log("Wrong Answer !");
        flashCamera.doCameraFlash = true;
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
        Debug.Log("try kickout");
        if (isDecisionRight(false) == true) {
            AnswerCorrectly();
            KickOut();
        } else {
            AnswerIncorrectly();
        }
    }

    public void TryLetInside()
    {
        if (isDecisionRight(true) == true) {
            AnswerCorrectly();
            LetInside();
        } else {
            AnswerIncorrectly();
        }
    }

    void Update()
    {
        // When the Hoplite is dead
        if (!healthBar.isAlive()) {
            return;
        }

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
