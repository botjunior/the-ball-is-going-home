using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WinCanvasScript : MonoBehaviour
{
    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Button buttonWin;

    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Button buttonRestart;

    void Start()
    {
        //инициализация listener для каждой кнопки
        AddButtonListener(buttonRestart, Restartlevel);
        AddButtonListener(buttonWin, WinLevel);

    }
    //добавляет listener к определённой button
    void AddButtonListener(Button btnTmp, UnityAction tmpAction)
    {
        btnTmp.onClick.AddListener(tmpAction);
    }
    //событие в случае победы
    void WinLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }
    //перезапускает сцену
    void Restartlevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
