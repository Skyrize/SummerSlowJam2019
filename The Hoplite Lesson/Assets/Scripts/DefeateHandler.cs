using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeateHandler : MonoBehaviour
{
	private HealthBarComponent healthBar;

    // Start is called before the first frame update
    void Start()
    {
    	healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarComponent>();
        gameObject.SetActive(false);
    }

    public void displayDeadText()
    {
    	gameObject.SetActive(true);
    }

    void Update()
    {
    	if (!healthBar.isAlive()) {
    		displayDeadText();
    	}
    }

}
