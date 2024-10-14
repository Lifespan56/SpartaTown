using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //활성화 버튼 2개 있음

    //다시 누름 > 이동, 다른쪽 활성화, 문자입력칸,선택버튼 비활성화
    //버튼 3개이상일때 호환은? List<GameObject>
    public static ButtonManager BtnInstance;
    [Header("프리팹목록")]
    [SerializeField] private List<GameObject> PlayerPrefab;

    [Header("캐릭터 선택 버튼들")]
    [SerializeField] private GameObject ChooseButtons;

    [Header("선택 후 활성화할 UI")]
    [SerializeField] private GameObject NowSelectImage;
    [SerializeField] private GameObject EnterBtn;
    [SerializeField] private GameObject NameInputTxt;

    private Camera mainCam;

    private GameObject TargetPrefab;
    private GameObject player;

    private string defalutNameTxt;//기본 이름
    private string NoEnteredTxt;//awake때 가져온 inputField의 text 아무것도 안썼다면 이것과 같음

    private void Awake()
    {
        //선언과 동시에 초기화불가 Awake나 Start에서 하라고 경고뜸
        mainCam = Camera.main;
        BtnInstance = this;
        NoEnteredTxt = NameInputTxt.GetComponent<InputField>().text;
        ResetPhase();
    }

    public void ChoicePhase(GameObject Chosen)//전처리 ButtonBehavior.cs Selected()//입력부
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

    //선택한 쪽의 이미지 적용, 문자입력칸,선택버튼 활성화
    private void ActivePhase(GameObject Chosen)
    { 
        ChooseButtons.SetActive(false);
        NowSelectImage.SetActive(true);
        NowSelectImage.GetComponent<Image>().sprite = Chosen.GetComponent<Image>().sprite;
        EnterBtn.SetActive(true);
        NameInputTxt.SetActive(true);
    }

    public void ResetPhase()//전처리 ButtonBehavior.cs CancelChoice()//입력부
    {
        NowSelectImage.SetActive(false);
        EnterBtn.SetActive(false);
        NameInputTxt.SetActive(false);
        ChooseButtons.SetActive(true);
    }
    public GameObject BeforeLoadSetting()
    {
        InstantiatePlayer();
        //인풋필드가 안쓴것과 같지 않아야만 이름 변경
        if(NoEnteredTxt != NameInputTxt.GetComponent<InputField>().text)
            player.GetComponentInChildren<TextMesh>().text = NameInputTxt.GetComponent<InputField>().text;

        //자식화 시 부모의 포지션값을 그대로 가져감 원하는 곳을 비추지않음
        mainCam.transform.parent = player.transform;
        //캠의 로컬포지션을 다시 잡아줌 z는 -10이어야한다
        mainCam.transform.localPosition = new Vector3(0f, 0f, -10f);

        return player;
    }

    private void InstantiatePlayer()
    {
        player = Instantiate(TargetPrefab);
    }
}
