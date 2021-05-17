using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] walkerPosition;//хранение всех позиций для перемещения
    public int indexNowWalkerPosition = 0; //индекс позиции к которой идти
    public float speedCharter; // скорость объекта
    public float ToPointDistance; //минимальная дистанция до точки

    public enum BotState//состояние для оьъекта
    {
        Walk,
        Wait,
    }
    //не реализовано состояние для wait, но оно может быть модифицировано

    public BotState botState;

    // Update is called once per frame
    void Update()
    {
        botController();
    }
    void botController()
    {
        switch (botState)
        {
            case BotState.Walk: // если состояние walk, то выполнять движения
                botMove();
                break;
        }
    }

    void botMove()
    {
        //использовалось примитивное передвижение без использования rigitbody и navMeshAgent(а). Для оптимизации движения и сохранения ресурсов. При необходимости моге их реализовать.
        if (Vector3.Distance(transform.position, walkerPosition[indexNowWalkerPosition].transform.position) > ToPointDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkerPosition[indexNowWalkerPosition].transform.position, speedCharter * Time.deltaTime);
            //перемещение объекта 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(walkerPosition[indexNowWalkerPosition].transform.position - transform.position), speedCharter * Time.deltaTime);
            //поворот объекта
        }
        else
        {
            nextIndex();
        }

    }
    //переход между индексами для массива с объектами
    void nextIndex()
    {
        indexNowWalkerPosition++;
        if (indexNowWalkerPosition >= walkerPosition.Length)
        {
            indexNowWalkerPosition = 0;
        }
    }

}
