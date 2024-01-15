using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{

    public void OnButtonClick()
    {
        LoadGame();

    }
    void LoadGame()
    {
        // Load by scene name
        SceneManager.LoadScene("SampleScene");

        // Or load by scene index
        // SceneManager.LoadScene(sceneBuildIndex);
    }

}
