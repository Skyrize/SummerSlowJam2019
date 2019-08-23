using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarComponent : MonoBehaviour
{
    private Transform bar;
    public float health = 100;
    public float dyingSpeed = 1;
    private float maxHealth = 100;

    private float fastTimer = 0.1f;
    private float slowTimer = 0.3f;
    private float timer = 0;
    private GameObject defeateHandler;
    
    void Start()
    {
        bar = transform.Find("Bar");
        maxHealth = health;
        defeateHandler = GameObject.Find("Defeate");
        defeateHandler.SetActive(false);
    }

    public void setSize(float size)
    {
        bar.localScale = new Vector3(size, 1.0f);
    }


    public void addHealth(float amount)
    {
        health += amount;
        health = Mathf.Min(maxHealth, health);
        setSize(health/maxHealth);
    }

    public void removeHealth(float amount)
    {
        health -= amount;
        health = Mathf.Max(0, health);
        setSize(health/maxHealth);
    }

    /*
     * Return true is the health bar is not empty, else false 
     */
    public bool isAlive()
    {
        if (health > 0) {
            return true;
        }

        return false;
    }

    public void SetColor(Color color)
    {
        transform.Find("Bar").Find("Sprite").GetComponent<SpriteRenderer>().color = color;
    }

    private void Update() {
        removeHealth(dyingSpeed * Time.deltaTime);
        if (!isAlive())
            defeateHandler.SetActive(true);
        if (health < 45) {
            if (timer <= 0) {
                if (health < 30) {
                    timer = fastTimer;
                } else {
                    timer = slowTimer;
                }
                
                if ((int)health % 2 == 0) {
                    SetColor(Color.white);
                } else {
                    SetColor(Color.green);
                }
            } else {
                timer -= Time.deltaTime;
            }
        } else {
            SetColor(Color.green);
        }
    }
}
