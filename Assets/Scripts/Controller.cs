using UnityEngine;

//델리게이트+=출력()
//출력부cs in 델리,출력()
//입력부cs input값을 델리(매개)
public class Controller : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float speed;
    [SerializeField] CharactersSO chaSO;
    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        speed = chaSO.speed;
    }

    public void CalcMove(Vector2 vector2)
    {
        Move(vector2);
    }

    public void Move(Vector2 moveDirection)
    {
        rigid2D.velocity = moveDirection * speed;
    }

    public void CalcLook(Vector2 vector2)
    {
        Vector2 camWorldPos = Camera.main.ScreenToWorldPoint(vector2);
        vector2 = (camWorldPos - (Vector2)transform.position).normalized;
        float rotZ = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
        Quaternion.Euler(0f, 0f, rotZ);
        Look(vector2);
    }

    public void Look(Vector2 LookDirection)
    {

    }
}

