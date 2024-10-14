using UnityEngine;
using UnityEngine.InputSystem;

//�Է¸� �޴� Ŭ����
public class PlayerInput : MonoBehaviour
{
    //���� �Է°� �ٸ� ��� �������̵�
    //�ٸ� �Է°� �ٸ� ��� �����ε�
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
        //.normalized�� ������ �ȵ� ScreenToWorldPoint()�ÿ� normalized�ƴ� ���� �ʿ���
        controller.CalcLook(input.Get<Vector2>());
    }
}

