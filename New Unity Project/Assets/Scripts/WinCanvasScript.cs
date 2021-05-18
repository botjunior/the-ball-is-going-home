using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WinCanvasScript : MonoBehaviour
{
    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Button buttonWin;

    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Button buttonRestart;

    void Start()
    {
        //������������� listener ��� ������ ������
        AddButtonListener(buttonRestart, Restartlevel);
        AddButtonListener(buttonWin, WinLevel);

    }
    //��������� listener � ����������� button
    void AddButtonListener(Button btnTmp, UnityAction tmpAction)
    {
        btnTmp.onClick.AddListener(tmpAction);
    }
    //������� � ������ ������
    void WinLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }
    //������������� �����
    void Restartlevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
