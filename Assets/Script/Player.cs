using System.Dynamic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    Vector2 InputVec;
    Rigidbody2D rigid;
    public Vector2 limitMax;
    public Vector2 limitMin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Arealimits();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 NextVec = InputVec * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + NextVec);   
    }

    private void OnMove(InputValue value)
    {
        InputVec = value.Get<Vector2>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitMin, new Vector2(limitMax.x, limitMin.y));
        Gizmos.DrawLine(limitMin, new Vector2(limitMin.x, limitMax.y));
        Gizmos.DrawLine(limitMax, new Vector2(limitMax.x, limitMin.y));
        Gizmos.DrawLine(limitMax, new Vector2(limitMin.x, limitMax.y));
    }
    void Arealimits()
    {
        Vector2 temp = transform.position; // 현재 위치 가져오기

        // X축 제한
        temp.x = Mathf.Clamp(temp.x, limitMin.x, limitMax.x);
        // Y축 제한
        temp.y = Mathf.Clamp(temp.y, limitMin.y, limitMax.y);

        transform.position = temp; // 위치 업데이트
    }
}
