using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void Selected()//입력부
    {
        ButtonManager.BtnInstance.ChoicePhase(this.gameObject);
    }
    public void CancelChoice()//입력부
    {
        ButtonManager.BtnInstance.ResetPhase();
    }
}
