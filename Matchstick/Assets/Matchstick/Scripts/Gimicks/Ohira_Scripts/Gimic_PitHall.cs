using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ƃ���
//�v���C���[�ɐG���Ə������Ȃ��ď�����
public class Gimic_PitHall : MonoBehaviour
{
    [SerializeField] private bool OnFire = false;//�M�~�b�N�ɉ΂��_���Ă��邩
    [SerializeField] public float BurnSpeed = 3.0f;

    // Start is called before the first frame updat
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�R���Ă���Ƃ�
        if (OnFire == true)
        {
            Vector3 vector;
            if (transform.localScale.y < 0)
            {
                //�I�u�W�F�N�g�̑傫����0�ȉ��ɂȂ�����
                //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
                vector = new Vector3(0.0f, 0.0f, 0.0f);
                gameObject.SetActive(false);
            }
            else
            {
                //�I�u�W�F�N�g������������
                vector = new Vector3(transform.localScale.x, transform.localScale.y - (BurnSpeed * Time.deltaTime), 0.0f);
            }

            //�I�u�W�F�N�g�̑傫�����X�V
            gameObject.transform.localScale = vector;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Player")
        {
            if (!OnFire) Debug.Log(gameObject.transform.name + "�ɉ΂��_�����I");
            OnFire = true;
        }
    }
}