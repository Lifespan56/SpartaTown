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
    [SerializeField] private List<GameObject> Buttons;

    [SerializeField] private GameObject NowSelectBtn;
    [SerializeField] private GameObject EnterBtn;
    [SerializeField] private GameObject NameInputTxt;

    private void Awake()
    {
        BtnInstance = this;
        ResetPhase();
    }

    public void ChoicePhase(GameObject Chosen)//��ó�� ButtonBehavior.cs Selected()//�Էº�
    {
        //�����Ѿ� > ����� �ڽ��� �Ű������� ����
        foreach (GameObject Button in Buttons)
        {
            if(Button.name == Chosen.name) ActivePhase(Chosen);
            Button.SetActive(false);
        }
        
    }
    //������ ���� �̹��� ����, �����Է�ĭ,���ù�ư Ȱ��ȭ
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
