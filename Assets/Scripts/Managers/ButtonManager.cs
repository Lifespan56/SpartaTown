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

    [Header("ĳ���� ���� ��ư��")]
    [SerializeField] private GameObject ChooseButtons;

    [Header("���� �� Ȱ��ȭ�� UI")]
    [SerializeField] private GameObject NowSelectImage;
    [SerializeField] private GameObject EnterBtn;
    [SerializeField] private GameObject NameInputTxt;

    private Camera mainCam;

    private GameObject TargetPrefab;
    private GameObject player;

    private string defalutNameTxt;//�⺻ �̸�
    private string NoEnteredTxt;//awake�� ������ inputField�� text �ƹ��͵� �Ƚ�ٸ� �̰Ͱ� ����

    private void Awake()
    {
        //����� ���ÿ� �ʱ�ȭ�Ұ� Awake�� Start���� �϶�� ����
        mainCam = Camera.main;
        BtnInstance = this;
        NoEnteredTxt = NameInputTxt.GetComponent<InputField>().text;
        ResetPhase();
    }

    public void ChoicePhase(GameObject Chosen)//��ó�� ButtonBehavior.cs Selected()//�Էº�
    {
        defalutNameTxt = Chosen.GetComponent<ButtonBehavior>().defalutNameTxt;

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
        NowSelectImage.SetActive(true);
        NowSelectImage.GetComponent<Image>().sprite = Chosen.GetComponent<Image>().sprite;
        EnterBtn.SetActive(true);
        NameInputTxt.SetActive(true);
    }

    public void ResetPhase()//��ó�� ButtonBehavior.cs CancelChoice()//�Էº�
    {
        NowSelectImage.SetActive(false);
        EnterBtn.SetActive(false);
        NameInputTxt.SetActive(false);
        ChooseButtons.SetActive(true);
    }
    public GameObject BeforeLoadSetting()
    {
        InstantiatePlayer();
        //��ǲ�ʵ尡 �Ⱦ��Ͱ� ���� �ʾƾ߸� �̸� ����
        if(NoEnteredTxt != NameInputTxt.GetComponent<InputField>().text)
            player.GetComponentInChildren<TextMesh>().text = NameInputTxt.GetComponent<InputField>().text;

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
