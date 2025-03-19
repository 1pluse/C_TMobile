using System.Dynamic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Vector2 InputVec;
    Rigidbody2D rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
}
