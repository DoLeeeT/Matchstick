using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Փ˔���
    void OnTriggerEnter2D(Collider2D collision)
    {
        //�}�b�`�̉΂�����
        if (collision.gameObject.GetComponent<PlayerIgniteMatch>())
        {
            collision.gameObject.GetComponent<PlayerIgniteMatch>().SetLightMatchFlg(false);
        }
        //���H�{�̂��A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }
}
