using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public string defalutNameTxt;

    public void Selected()//입력부
    {
        defalutNameTxt = GetComponentInChildren<Text>().text;
        ButtonManager.BtnInstance.ChoicePhase(this.gameObject);
    }
    public void CancelChoice()//입력부
    {
        ButtonManager.BtnInstance.ResetPhase();
    }

}
