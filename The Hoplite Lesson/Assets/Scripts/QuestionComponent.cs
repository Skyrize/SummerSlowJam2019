using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionComponent : MonoBehaviour
{
    static private string[] rightAnswers = {
        "Zeus is the king of the gods of Mount Olympus."
    };
    static private string[] wrongAnswers = {
        "Zeus is the god of the sea."
    };
    public bool answer = false;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 1) == 0) {
            answer = false;
            text.text = wrongAnswers[Random.Range(0, wrongAnswers.Length - 1)];
        } else {
            answer = true;
            text.text = rightAnswers[Random.Range(0, wrongAnswers.Length - 1)];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
