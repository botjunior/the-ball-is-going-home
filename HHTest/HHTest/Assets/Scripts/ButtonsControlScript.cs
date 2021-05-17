using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class ButtonsControlScript : MonoBehaviour
{
    [SerializeField]
    private Button buttonStart;
    [SerializeField]
    private Button buttonEnd;

    void Start()
    {
        Debug.Log("������� �����"+SceneManager.sceneCount);
        Debug.Log("����� ����" + SceneManager.sceneCountInBuildSettings);
        if (buttonStart != null && buttonEnd != null) {
            buttonStart.onClick.AddListener(NextScene);
            buttonEnd.onClick.AddListener(EndGame);
        }
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    void EndGame()
    {
        Application.Quit();
    }
}
