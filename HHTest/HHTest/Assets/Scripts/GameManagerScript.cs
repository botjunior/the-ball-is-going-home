using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public enum PlayState
    {
        Play,
        Win,
        Lose,
    }

    public PlayState playState = PlayState.Play;

    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Canvas winCanvas;

    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Canvas loseCanvas;

    private EndLevelZoneScript[] endZones;

    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private GameObject playerPrefab;
    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private Transform playerInstantiatePostiton;
    // ������ �� ���������� ���� ��� ������ �������, �� ��������� ��� ���������� ����� Unity
    [SerializeField]
    private float timeSpawn;

    public GameObject startVFX;

    //������������� ��������� �������� � �������� �������� ��������� ����� ����������� �����
    void Start()
    {
        EndZonesSettings();
        Invoke(nameof(InstantianePlayer), timeSpawn);
    }
    //������� �����, � ������� �� ��������� �������, ������� ���� ���������� � ������ ������
    void EndZonesSettings()
    {
        if (FindObjectOfType<EndLevelZoneScript>() !=null)
        {
            endZones = FindObjectsOfType<EndLevelZoneScript>();
            for (int i = 0; i < endZones.Length;i++)
            {
                if (endZones[i].returnGameState())
                {
                    endZones[i].onPlayerWin = InstantiateWinCanvas;
                }
                else
                {
                    endZones[i].onPlayerWin = InstantiateLoseCanvas;
                }
            }
        }
    }
    // ������ �������� ���������, ������ ��� ���������, � ������� ������� ����� ������ �� �����, ��� �������� ����� � ��� � ������ ��� ��������� ������ ��������� ������� �� ���������
    void InstantianePlayer()
    {
        if (startVFX != null)
        {
            Instantiate(startVFX, playerInstantiatePostiton);
        }
        Instantiate(playerPrefab, playerInstantiatePostiton);
        if (FindObjectOfType<PlayerMoveScript>() != null)
        {
            EnemyVisibleScript[] enemys = FindObjectsOfType<EnemyVisibleScript>();
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].onPlayerContact = InstantiateLoseCanvas;
                enemys[i].SetPlayerCreate();
            }
        }

    }
    //������� Canvas ������ ������
    void InstantiateWinCanvas()
    {
        Instantiate(winCanvas);
    }
    //������� Canvas ������ ���������
    void InstantiateLoseCanvas()
    {
        Instantiate(loseCanvas);
    }

    
}
