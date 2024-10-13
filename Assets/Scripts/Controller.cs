using UnityEngine;

//델리게이트+=출력()
//출력부cs in 델리,출력()
//입력부cs input값을 델리(매개)
public class Controller : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private StatHandler statHandler;
    private SpriteRenderer spriteRenderer;
    private Camera cam;

    private Vector2 lookDiraction;
    private float rotZ;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        statHandler = GetComponent<StatHandler>();
        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
        cam = Camera.main;
    }

    public void CalcMove(Vector2 InputVector2)//입력>전처리
    {
        Move(InputVector2);
    }

    public void Move(Vector2 moveDirection)//출력부
    {
        rigid2D.velocity = moveDirection * statHandler.currentSO.speed;
    }

    public void CalcLook(Vector2 InputVector2)//입력>전처리
    {
        Vector2 camWorldPos = cam.ScreenToWorldPoint(InputVector2);
        InputVector2 = (camWorldPos - (Vector2)transform.position).normalized;
        //좌표와 좌표를 역탄젠트로 각도로 변경 결과는 파이로 계산됨3.14.... 
        //Rad2Deg로 파이 값을 각도로 변경
        rotZ = Mathf.Atan2(InputVector2.y, InputVector2.x) * Mathf.Rad2Deg;
        //절대값으로 기준점에서 왼쪽인지 오른쪽인지 판단할것
        rotZ = Mathf.Abs(rotZ);
        /*  
            -90
        -180 
            기준  0
         180
             90
        */
        //Debug.Log(rotZ);
        Look(rotZ > 90.0f);
    }

    public void Look(bool isLeft)//출력부
    {
        spriteRenderer.flipX = isLeft;
    }
}

