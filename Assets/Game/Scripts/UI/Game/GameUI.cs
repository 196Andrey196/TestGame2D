using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameCounter;
    [SerializeField] private GameObject _menu;
    public static Action<bool> menuActive;
    private int _gameCount;
    public static Action<int> changeGameCount;

    void OnEnable()
    {

        changeGameCount += ChnageGameCount;
        menuActive += ActiveMenu;
    }
        void OnDisable()
    {

        changeGameCount -= ChnageGameCount;
        menuActive -= ActiveMenu;
    }

    private void ActiveMenu(bool active)
    {
        _menu.SetActive(true);
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
    {
        ActiveMenu(true);
    }
    }
   
    void Start()
    {
        _gameCounter.text = 0.ToString();
    }
    private void ChnageGameCount(int count)
    {

        if (count != 0)
        {
            _gameCount += count;
            _gameCounter.text = _gameCount.ToString();

        }
    }
}
