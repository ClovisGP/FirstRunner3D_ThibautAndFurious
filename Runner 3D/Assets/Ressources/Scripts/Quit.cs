using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void LunchGame() {
        SceneManager.LoadScene("Game");
        Debug.Log("Lunch game");
    }
}