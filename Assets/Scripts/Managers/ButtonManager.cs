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
    [SerializeField] private List<GameObject> Buttons;

    [SerializeField] private GameObject NowSelectBtn;
    [SerializeField] private GameObject EnterBtn;
    [SerializeField] private GameObject NameInputTxt;

    private void Awake()
    {
        BtnInstance = this;
        ResetPhase();
    }

    public void ChoicePhase(GameObject Chosen)//전처리 ButtonBehavior.cs Selected()//입력부
    {
        //선택한애 > 여기로 자신을 매개변수로 전달
        foreach (GameObject Button in Buttons)
        {
            if(Button.name == Chosen.name) ActivePhase(Chosen);
            Button.SetActive(false);
        }
        
    }
    //선택한 쪽의 이미지 적용, 문자입력칸,선택버튼 활성화
    private void ActivePhase(GameObject Chosen)
    {
        NowSelectBtn.SetActive(true);
        NowSelectBtn.GetComponent<Image>().sprite = Chosen.GetComponent<Image>().sprite;
        EnterBtn.SetActive(true);
        NameInputTxt.SetActive(true);
    }

    public void ResetPhase()
    {
        NowSelectBtn.SetActive(false);
        EnterBtn.SetActive(false);
        NameInputTxt.SetActive(false);
        foreach (GameObject Button in Buttons)
        {
            Button.SetActive(true);
        }
    }
}
