using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _qiut, _continue;
    [SerializeField] private GameObject _menu;
    void Start()
    {
        _qiut.onClick.AddListener(Quit);
        _continue.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        _menu.SetActive(false);
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
