using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TabController : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> ButtonImages;
    [SerializeField] private List<GameObject> Games;


    public void OnClick(int index)
    {
        foreach (var buttonImages in ButtonImages)
        {
            buttonImages.SetActive(false);
        }
        ButtonImages[index].SetActive(true);
        foreach (var games in Games)
        {
            games.SetActive(false);
        }
        Games[index].SetActive(true);
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}