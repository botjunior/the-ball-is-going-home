using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class LoseCanvasScript : MonoBehaviour
{
    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Button buttonLose;
    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Button buttonRestart;

    void Start()
    {
        //������������� listener ��� ������ ������
        AddButtonListener(buttonRestart, Restartlevel);
        AddButtonListener(buttonLose, WinLevel);
        //Time.timeScale = 0;
    }
    //��������� listener � ����������� button
    void AddButtonListener(Button btnTmp, UnityAction tmpAction)
    {
        if (btnTmp != null)
        {
            btnTmp.onClick.AddListener(tmpAction);
        }
    }
    //������� � ������ ���������
    void WinLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    //������������� �����
    void Restartlevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
