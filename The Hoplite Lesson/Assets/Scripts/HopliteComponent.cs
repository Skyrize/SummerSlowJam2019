using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HopliteComponent : MonoBehaviour
{
    public GameObject target;
    private EventComponent EventHandler;
    private HealthBarComponent healthBar;
    private ThunderboldHandler flashCamera;

    private float timeAlive = 0;
    private AudioManagerComponent audioManager;
    // private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        EventHandler = GameObject.Find("EventHandler").GetComponent<EventComponent>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarComponent>();
        flashCamera = GameObject.Find("Flash").GetComponent<ThunderboldHandler>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManagerComponent>();
        // currentScene = SceneManager.GetActiveScene();
        audioManager.PlaySound("GameBeginMusic");
        audioManager.PlaySoundDelayed("GameMusic", audioManager.GetSound("GameBeginMusic").clip.length);
    }

    private bool isDecisionRight(bool accepted)
    {
        return (target.GetComponent<PhilosopherComponent>().question.GetComponent<QuestionComponent>().answer == accepted);
    }

    public void Die()
    {
        GameObject.Find("TextHandler").transform.Find("Defeate").GetComponent<Text>().text = "Well done buddy, you succed to hold for " + ((int)timeAlive).ToString() + " seconds !\r Press 'R' to restart the game.";
        flashCamera.doCameraFlash = true;
        audioManager.PlaySound("LightningSound");
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 500));
        GetComponent<Rigidbody2D>().AddTorque(-500);
    }

    public void AnswerCorrectly()
    {
        healthBar.addHealth(20);
            //change animation hoplite
    }
    
    public void AnswerIncorrectly()
    {
        healthBar.removeHealth(10);
        flashCamera.doCameraFlash = true;
        audioManager.PlaySound("LightningSound");
        KickOut();
        // gain time
    }

    public void KickOut()
    {
        target.GetComponent<PhilosopherComponent>().GetKickedOut();
        EventHandler.InvokePhilosopherLeft();
        target = null;
        audioManager.PlaySound("KickOutSound");
        //Change animation hoplite
        //Remonter vie
    }

    public void LetInside()
    {
        target.GetComponent<PhilosopherComponent>().GetInside();
        EventHandler.InvokePhilosopherLeft();
        target = null;
        //Change animation hoplite
        //Remonter vie
    }

    public void TryKickOut()
    {
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
        if (healthBar.isAlive()) {
            timeAlive += Time.deltaTime;
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
}
