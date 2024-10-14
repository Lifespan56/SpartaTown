using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject mainCam;
    GameObject player;
    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        OnLoadSetting();
    }

    private void OnLoadSetting()
    {
        mainCam.transform.parent = player.transform;
        player.SetActive(true);
    }
}
