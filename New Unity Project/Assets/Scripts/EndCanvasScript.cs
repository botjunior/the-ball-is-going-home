using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndCanvasScript : MonoBehaviour
{
    //делаем поле не изменяемым для других классов но видимым для редактора unity
    [SerializeField]
    private Button buttonRestart;
    [SerializeField]
    private Button buttonNextScene;
    

    //событие перезагрузки сцены
    public UnityAction onRestartLevel;
    //событие перехода между сценами
    public UnityAction onNextScene;

    private void Start()
    {
        if (buttonRestart != null && onRestartLevel != null)
        {
            //передает текущее событие в button если есть событие и они инициализированы то добваляет событие при нажатии на кнопку
            buttonRestart.onClick.AddListener(onRestartLevel);
        }
        if (buttonNextScene !=null && onNextScene != null)
        {
            //передает текущее событие в button если есть событие и они инициализированы то добваляет событие при нажатии на кнопку
            buttonNextScene.onClick.AddListener(onNextScene);
        }
    }
}
