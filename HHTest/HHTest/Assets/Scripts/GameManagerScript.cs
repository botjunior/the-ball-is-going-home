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

    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Canvas winCanvas;

    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Canvas loseCanvas;

    private EndLevelZoneScript[] endZones;

    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private GameObject playerPrefab;
    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private Transform playerInstantiatePostiton;
    // делаем не доступными поля для других классов, но доступные для добывления через Unity
    [SerializeField]
    private float timeSpawn;

    public GameObject startVFX;

    //инициализация стартовых настроек и создание игрового персонажа через определённое время
    void Start()
    {
        EndZonesSettings();
        Invoke(nameof(InstantianePlayer), timeSpawn);
    }
    //передаёт месту, в котором мы побеждаем событие, которое буде вызываться в случае победы
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
    // создаёт главного персонажа, эффект его появления, и передаёт событие всемм врагам на сцене, что появился игрок и что в случае его поражения должно произойти событие на поражение
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
    //создает Canvas случае победы
    void InstantiateWinCanvas()
    {
        Instantiate(winCanvas);
    }
    //создает Canvas случае поражения
    void InstantiateLoseCanvas()
    {
        Instantiate(loseCanvas);
    }

    
}
