using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void Selected()//�Էº�
    {
        ButtonManager.BtnInstance.ChoicePhase(this.gameObject);
    }
    public void CancelChoice()
    {
        ButtonManager.BtnInstance.ResetPhase();
    }
}
