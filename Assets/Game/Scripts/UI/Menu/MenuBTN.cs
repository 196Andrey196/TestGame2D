using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBTN : MonoBehaviour
{
    [SerializeField] private Button _quit, _play;
    void Start()
    {
        _quit.onClick.AddListener(Quit);
        _play.onClick.AddListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
