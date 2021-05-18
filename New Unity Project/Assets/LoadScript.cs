using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int SavingIt;
    private void SetSave()
    {
        #region PlayerPrefs.Set***
        PlayerPrefs.SetInt("Test", SavingIt);

        #endregion
    }

    private void SetLoad()
    {
        #region PlayerPrefs.Get***

        SavingIt = PlayerPrefs.GetInt("Test", 1);

        #endregion
    }


    void Start()
    {
        SetLoad();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        SetSave();
    }
}
