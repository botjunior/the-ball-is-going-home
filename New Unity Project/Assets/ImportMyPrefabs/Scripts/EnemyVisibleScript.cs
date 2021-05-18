using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyVisibleScript : MonoBehaviour
{
	public enum PlayerCreate
    {
		Create,
		NotCreate,
    }
	private PlayerCreate playerCreate = PlayerCreate.NotCreate;

	public void SetPlayerCreate() {
		playerCreate = PlayerCreate.Create;
		if (target == null)
		{
			target = FindObjectOfType<PlayerMoveScript>().gameObject;
			targetTransform = target.transform;
		}
	}
	public void SetPlayerDestroy()
    {
		target = null;

	}
	public void SetPlayerNotCreate() { playerCreate = PlayerCreate.NotCreate; }

	public int rays = 6;//текущее колличество лучей(2 * rays - 1)
	public float distance = 15; //дистанция при которой мы начинаем отрпсовывать лучи
	public float angle = 20;//угол при котором рисуются лучи
	public Vector3 offset; //вектор удаления от объекта 
	public GameObject target;
	public Transform targetTransform;//текущий targer

	public UnityAction onPlayerContact;

	//если луч соприкоснулся с персонажем, то возвращаем true, иначе false
	bool GetRaycast(Vector3 dir)
	{
		bool result = false;// переменная что возвращает было ли соприкосновение луча с target или нет
		RaycastHit hit = new RaycastHit(); //c
		Vector3 pos = transform.position + offset;//позиция из которой мы будет получать наши лучи = берём текущую позицию на которой весит скрипт + некое отдаление от объекта
		if (Physics.Raycast(pos, dir, out hit, distance))//возвращает true, если луч пересекает коллайдер, иначе false.
		{
			if (hit.transform == target.transform)//проверяет посылающий луч с позицией target на карте
			{
				result = true;
				Debug.DrawLine(pos, hit.point, Color.green);//если луч попадает на объект target то цвет зелёный
			}
			else
			{
				Debug.DrawLine(pos, hit.point, Color.blue);//если луч попададает на любой объект
			}
		}
		else
		{
			Debug.DrawRay(pos, dir * distance, Color.red);//если луч не попадает ни на какой объект
		}
		return result;//если луч соприкоснулся с персонажем, то возвращаем true, иначе false
	}

	bool RayToScan()
	{
		bool result = false;
		bool a = false;
		bool b = false;
		float j = 0;
		for (int i = 0; i < rays; i++)//создаём лучи направления от текущего вектора. Всего лучей = rays * 2 - 1s
		{
			var x = Mathf.Sin(j);
			var y = Mathf.Cos(j);

			j += angle * Mathf.Deg2Rad / rays;

			Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
			if (GetRaycast(dir)) a = true;

			if (x != 0)
			{
				dir = transform.TransformDirection(new Vector3(-x, 0, y));
				if (GetRaycast(dir)) b = true;
			}
		}

		if (a || b) result = true; // возвразает true если хоть 1 луч соприкоснулся с игроком
		return result;
	}

	void FixedUpdate()
	{
        switch (playerCreate) // начинает отрисовывать лучи, если есть префаб игрока на сцене
        {
			case PlayerCreate.Create:
				if (target != null) {
					if (Vector3.Distance(transform.position, target.transform.position) < distance + 10 )//дистанция отрисовки лучей(чтобы не нагружать сцену вычислениями)
					{
						if (RayToScan())
						{
							Destroy(target.gameObject);
							SetPlayerDestroy();
							onPlayerContact.Invoke(); // событие при соприкосновении с игроком
							

						}
					}
				}
				break;
        }
	}
}