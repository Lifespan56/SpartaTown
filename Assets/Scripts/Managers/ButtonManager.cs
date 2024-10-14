using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //Ȱ��ȭ ��ư 2�� ����

    //�ٽ� ���� > �̵�, �ٸ��� Ȱ��ȭ, �����Է�ĭ,���ù�ư ��Ȱ��ȭ
    //��ư 3���̻��϶� ȣȯ��? List<GameObject>
    public static ButtonManager BtnInstance;
    [Header("�����ո��")]
    [SerializeField] private List<GameObject> PlayerPrefab;

    [Header("ĳ���� ���� ��ư")]
    [SerializeField] private GameObject ChooseButtons;

    [Header("���� �� Ȱ��ȭ�� UI")]
    [SerializeField] private GameObject NowSelectBtn;
    [SerializeField] private GameObject EnterBtn;
    [SerializeField] private GameObject NameInputTxt;

    private Camera mainCam;

    private GameObject TargetPrefab;
    private GameObject player;

    private void Awake()
    {
        //����� ���ÿ� �ʱ�ȭ�Ұ� Awake�� Start���� �϶�� ����
        mainCam = Camera.main;
        BtnInstance = this;
        ResetPhase();
    }

    public void ChoicePhase(GameObject Chosen)//��ó�� ButtonBehavior.cs Selected()//�Էº�
    {
        foreach (GameObject obj in PlayerPrefab)
        {
            if (obj.name == Chosen.name)
            {
                TargetPrefab = obj;
                ActivePhase(Chosen);
                break;
            }
        }
    }

    //������ ���� �̹��� ����, �����Է�ĭ,���ù�ư Ȱ��ȭ
    private void ActivePhase(GameObject Chosen)
    { 
        ChooseButtons.SetActive(false);
        NowSelectBtn.SetActive(true);
        NowSelectBtn.GetComponent<Image>().sprite = Chosen.GetComponent<Image>().sprite;
        EnterBtn.SetActive(true);
        NameInputTxt.SetActive(true);
    }

    public void ResetPhase()//��ó�� ButtonBehavior.cs CancelChoice()//�Էº�
    {
        NowSelectBtn.SetActive(false);
        EnterBtn.SetActive(false);
        NameInputTxt.SetActive(false);
        ChooseButtons.SetActive(true);
    }
    public GameObject BeforeLoadSetting()
    {
        InstantiatePlayer();

        //�ڽ�ȭ �� �θ��� �����ǰ��� �״�� ������ ���ϴ� ���� ����������
        mainCam.transform.parent = player.transform;
        //ķ�� ������������ �ٽ� ����� z�� -10�̾���Ѵ�
        mainCam.transform.localPosition = new Vector3(0f, 0f, -10f);
        return player;
    }

    private void InstantiatePlayer()
    {
        player = Instantiate(TargetPrefab);
    }
}
