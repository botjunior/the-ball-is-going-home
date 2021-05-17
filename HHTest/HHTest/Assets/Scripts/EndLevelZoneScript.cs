using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndLevelZoneScript : MonoBehaviour
{
    public UnityAction onPlayerWin;

    public enum GameStateCanvasInstantiate
    {
        Lose,
        Win,
    } //������ enum ��� ����, ����� � ���������� ����� ���� �������������� ���� . ���������� ����� ������� �� ������ ��� ���������

    public GameStateCanvasInstantiate gameState = GameStateCanvasInstantiate.Lose;

    public bool returnGameState() //���������� ������� ��������� ����
    {
        if (gameState == GameStateCanvasInstantiate.Win)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //���� ����� ������ �� ������� ���� ������ ������������ � ����������, �� ��������� ������� �� ������
    //������� UnityAction ��� ����, ����� �� ������ ������� �� ������ ������� ������� ������. ������������� ������������  GameManager
    private void OnTriggerEnter(Collider other)                                       
    {
        if (onPlayerWin!=null && other.GetComponent<PlayerMoveScript>())
        {
            onPlayerWin.Invoke();
        }
    }
}
