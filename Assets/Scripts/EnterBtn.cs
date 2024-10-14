using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBtn : MonoBehaviour
{
    public void ToStartScene()//OnClick
    {
        DontDestroyOnLoad(ButtonManager.BtnInstance.BeforeLoadSetting());
        SceneManager.LoadScene("MainScene");
    }

}
