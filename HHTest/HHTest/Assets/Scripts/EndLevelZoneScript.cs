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
    } //сделал enum для того, чтобы в дальнейшем можно было модифицировать игру . Добавление новых событий на победу или поражение

    public GameStateCanvasInstantiate gameState = GameStateCanvasInstantiate.Lose;

    public bool returnGameState() //возвращает текущее состояние игры
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

    //если попал объект на котором есть скрипт передвижения с клавиатуры, то запускает событие на победу
    //сделано UnityAction для того, чтобы на каждое событие не вешать вручную событие победы. Инициализация происходится  GameManager
    private void OnTriggerEnter(Collider other)                                       
    {
        if (onPlayerWin!=null && other.GetComponent<PlayerMoveScript>())
        {
            onPlayerWin.Invoke();
        }
    }
}
