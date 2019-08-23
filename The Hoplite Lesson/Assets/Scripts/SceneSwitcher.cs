using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    private void Start()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManagerComponent>().PlaySound("MenuMusic");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GotoCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void GotoGameScene()
    {
    	SceneManager.LoadScene("SampleScene");
    }
}