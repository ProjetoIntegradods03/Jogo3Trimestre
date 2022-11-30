using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string cena;
    public GameObject OptionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        //Application.Quit();
    }

    public void ShowOptions()
    {
        OptionsPanel.SetActive(true);

    }

    public void BackToMenu()
    {
        OptionsPanel.SetActive(false);
    }
}
