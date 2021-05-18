using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonsControlScript : MonoBehaviour
{
    [SerializeField]
    private Button buttonStart;
    [SerializeField]
    private Button buttonEnd;

    [SerializeField]
    private Button buttonContinue;

    private int lastLoadScene = -1;

    void Start()
    {
        //Устанавливаю события которые будут происходить при нажатии на кнопку
        SetActionOnButton(buttonStart, NextScene);
        SetActionOnButton(buttonEnd, EndGame);
        SetActionOnButton(buttonContinue, ContinueScene);
    }
    //метод сохранения последнего достигнутого уровня. Если уровней не было, то начинает игру с 1-го уровня
    private void SetLoad()
    {
        #region PlayerPrefs.Get***

        lastLoadScene = PlayerPrefs.GetInt("Test", 1);

        #endregion
    }

    //метод который загружает последнюю сцену
    void ContinueScene()
    {
        SetLoad();
        SceneManager.LoadScene(lastLoadScene);
    }
    //метод позволяющий установить выбранное событие на выбранную кнопку
    void SetActionOnButton(Button btn, UnityAction act)
    {
        if(btn != null)
            btn.onClick.AddListener(act);
    }
    //загрузка последнего уровня
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    //выход из игры
    void EndGame()
    {
        Application.Quit();
    }
}
