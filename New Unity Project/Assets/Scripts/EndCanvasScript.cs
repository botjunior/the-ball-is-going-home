using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndCanvasScript : MonoBehaviour
{
    //������ ���� �� ���������� ��� ������ ������� �� ������� ��� ��������� unity
    [SerializeField]
    private Button buttonRestart;
    [SerializeField]
    private Button buttonNextScene;
    

    //������� ������������ �����
    public UnityAction onRestartLevel;
    //������� �������� ����� �������
    public UnityAction onNextScene;

    private void Start()
    {
        if (buttonRestart != null && onRestartLevel != null)
        {
            //�������� ������� ������� � button ���� ���� ������� � ��� ���������������� �� ��������� ������� ��� ������� �� ������
            buttonRestart.onClick.AddListener(onRestartLevel);
        }
        if (buttonNextScene !=null && onNextScene != null)
        {
            //�������� ������� ������� � button ���� ���� ������� � ��� ���������������� �� ��������� ������� ��� ������� �� ������
            buttonNextScene.onClick.AddListener(onNextScene);
        }
    }
}
