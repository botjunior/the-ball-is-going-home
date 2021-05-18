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
        //������������ ������� ������� ����� ����������� ��� ������� �� ������
        SetActionOnButton(buttonStart, NextScene);
        SetActionOnButton(buttonEnd, EndGame);
        SetActionOnButton(buttonContinue, ContinueScene);
    }
    //����� ���������� ���������� ������������ ������. ���� ������� �� ����, �� �������� ���� � 1-�� ������
    private void SetLoad()
    {
        #region PlayerPrefs.Get***

        lastLoadScene = PlayerPrefs.GetInt("Test", 1);

        #endregion
    }

    //����� ������� ��������� ��������� �����
    void ContinueScene()
    {
        SetLoad();
        SceneManager.LoadScene(lastLoadScene);
    }
    //����� ����������� ���������� ��������� ������� �� ��������� ������
    void SetActionOnButton(Button btn, UnityAction act)
    {
        if(btn != null)
            btn.onClick.AddListener(act);
    }
    //�������� ���������� ������
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    //����� �� ����
    void EndGame()
    {
        Application.Quit();
    }
}
