using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DefeateHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Transform crowd = GameObject.Find("Crowd").transform;

        GetComponent<Text>().text = "Well done buddy, you succed to hold for " + ((int)Time.time).ToString() + " seconds !\r Press 'R' to restart the game.";
        Color tmp = GameObject.Find("Image").GetComponent<Image>().color;
        tmp.a = 0.7f;
        GameObject.Find("Image").GetComponent<Image>().color = tmp;
        GameObject.Find("Hoplite").GetComponent<HopliteComponent>().Die();
        while (crowd.childCount != 0)
            crowd.GetChild(0).GetComponent<PhilosopherComponent>().GetKickedOut();
        GameObject.Find("Spawner").SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
