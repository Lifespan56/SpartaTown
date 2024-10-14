using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBtn : MonoBehaviour
{
    [SerializeField] private List<GameObject> KeepObject;

    GameObject mainCam;
    GameObject player;

    public void ToStart()
    {
        foreach (GameObject obj in KeepObject)
        {
            if (obj.name == "Main Camera")
            {
                mainCam = obj;
                DontDestroyOnLoad(mainCam);
            }
            else if (obj.name == "Player")
            {
                player = obj;
                DontDestroyOnLoad(player);
            }
            else DontDestroyOnLoad(obj);
        }
        BeforeLoadSetting();
    }

    private void BeforeLoadSetting()
    {
        //자식화 시 부모의 포지션값을 그대로 가져감 원하는 곳을 비추지않음
        mainCam.transform.parent = player.transform;
        //캠의 로컬포지션을 다시 잡아줌 z는 -10이어야한다
        mainCam.transform.localPosition = new Vector3(0f, 0f, -10f);
        player.SetActive(true);
        SceneManager.LoadScene("MainScene");
    }
}
