using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Controller controller;

    private void Start()
    {
        controller = GetComponent<Controller>();
    }
    //�÷��̾� �Է¸� �޴� Ŭ����
    public void OnMove(InputValue input)
    {
        Debug.Log(input.Get<Vector2>().ToString());
        controller.CalcMove(input.Get<Vector2>().normalized);
    }

    public void OnLook(InputValue input)
    {
        controller.CalcLook(input.Get<Vector2>().normalized);
    }

}

