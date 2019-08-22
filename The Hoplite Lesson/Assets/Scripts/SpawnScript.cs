using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject SpawningEntity;
    private GameObject path;
    public float cooldown = 3;
    private float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.Find("Path");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0) {
            if (path.GetComponent<PathComponent>().isFull() == false) {
                timer = cooldown;
                Instantiate(SpawningEntity, transform.position, Quaternion.identity);
            }
        } else {
            timer -= Time.fixedDeltaTime;
        }
    }
}
