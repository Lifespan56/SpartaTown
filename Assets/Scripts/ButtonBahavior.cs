using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void Selected()//ÀÔ·ÂºÎ
    {
        ButtonManager.BtnInstance.ChoicePhase(this.gameObject);
    }
    public void CancelChoice()
    {
        ButtonManager.BtnInstance.ResetPhase();
    }
}
