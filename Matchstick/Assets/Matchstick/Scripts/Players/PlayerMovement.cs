using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private  Rigidbody2D rigidbody2d;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask layerGround;


    private float directionX;
    private bool jumpFlg;
    private bool groundedFlg;
    private bool canJumpFlg;
    private bool playerReverce;

    // Start is called before the first frame update
    void Start()
    {
        if (null == rigidbody2d)
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //キーを取得
        directionX = Input.GetAxis("Horizontal");
        jumpFlg    = Input.GetButtonDown("Jump");
        //ジャンプが可能かチェック
        CheckCanJump();
        //ジャンプ処理
        Jump();
    }

    void FixedUpdate() 
    {
        //移動処理
        Move();
        //地面接触チェック
        CheckSurroundings();
    }

   


    private void Move()
    {
        if (directionX < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            //playerReverce = true;
            transform.localScale = new Vector2(-1,1);
        }
        else if (directionX > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            transform.localScale = new Vector2(1,1);
            //playerReverce = false;
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        // if(playerReverce)
        // {
        //     transform.Rotate(0.0f,180.0f,0.0f);
        // }
        // else
        // {
        //     // if(rigidbody2d.velocity.x > 0)
        //     // {
        //     //     rigidbody2d.velocity.x =
        //     // }
        // }
    }

    private void CheckCanJump()
    {
        if(groundedFlg && rigidbody2d.velocity.y <= 0)
        {
            canJumpFlg = true;
        }
        else
        {
            canJumpFlg = false;
        }
    }
     //地面接触チェック
    private void CheckSurroundings()
    {
        groundedFlg = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,layerGround);

    }
    private void Jump()
    {
        if(jumpFlg && canJumpFlg)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
        }
    }
    

    //地面への当たり判定描画
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
