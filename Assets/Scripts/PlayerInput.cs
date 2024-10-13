using UnityEngine;
using UnityEngine.InputSystem;

//입력만 받는 클래스
public class PlayerInput : MonoBehaviour
{
    private Controller controller;
    
    private void Awake()
    {
        controller = GetComponent<Controller>();
    }
    
    public void OnMove(InputValue input)
    {
        controller.CalcMove(input.Get<Vector2>().normalized);
    }

    public void OnLook(InputValue input)
    {
        //.normalized로 보내면 안됨 ScreenToWorldPoint()시에 normalized아닌 값이 필요함
        controller.CalcLook(input.Get<Vector2>());
    }

}

