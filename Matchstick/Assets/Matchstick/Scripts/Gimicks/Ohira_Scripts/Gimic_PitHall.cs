using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//落とし穴
//プレイヤーに触れると小さくなって消える
public class Gimic_PitHall : MonoBehaviour
{
    [SerializeField] private bool OnFire = false;//ギミックに火が点いているか
    [SerializeField] public float BurnSpeed = 3.0f;

    // Start is called before the first frame updat
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //燃えているとき
        if (OnFire == true)
        {
            Vector3 vector;
            if (transform.localScale.y < 0)
            {
                //オブジェクトの大きさが0以下になったら
                //オブジェクトを非アクティブにする
                vector = new Vector3(0.0f, 0.0f, 0.0f);
                gameObject.SetActive(false);
            }
            else
            {
                //オブジェクトを小さくする
                vector = new Vector3(transform.localScale.x, transform.localScale.y - (BurnSpeed * Time.deltaTime), 0.0f);
            }

            //オブジェクトの大きさを更新
            gameObject.transform.localScale = vector;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Player")
        {
            if (!OnFire) Debug.Log(gameObject.transform.name + "に火が点いた！");
            OnFire = true;
        }
    }
}