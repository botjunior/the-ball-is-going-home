using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class LoseCanvasScript : MonoBehaviour
{
    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Button buttonLose;
    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Button buttonRestart;

    void Start()
    {
        //инициализация listener для каждой кнопки
        AddButtonListener(buttonRestart, Restartlevel);
        AddButtonListener(buttonLose, WinLevel);
        //Time.timeScale = 0;
    }
    //добавляет listener к определённой button
    void AddButtonListener(Button btnTmp, UnityAction tmpAction)
    {
        if (btnTmp != null)
        {
            btnTmp.onClick.AddListener(tmpAction);
        }
    }
    //событие в случае поражения
    void WinLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    //перезапускает сцену
    void Restartlevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
