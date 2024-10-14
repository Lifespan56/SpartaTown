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
        //�ڽ�ȭ �� �θ��� �����ǰ��� �״�� ������ ���ϴ� ���� ����������
        mainCam.transform.parent = player.transform;
        //ķ�� ������������ �ٽ� ����� z�� -10�̾���Ѵ�
        mainCam.transform.localPosition = new Vector3(0f, 0f, -10f);
        player.SetActive(true);
        SceneManager.LoadScene("MainScene");
    }
}
