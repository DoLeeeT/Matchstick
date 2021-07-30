using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjcet : MonoBehaviour
{
    enum MoveType
    {
        RoundTrip,
        Loop,
    }

    [SerializeField]
    private MoveType moveType;
    [Header("�ړ��o�H�ݒ�")]
    [SerializeField]
    private float speed = 1.0f;
    public bool IsMove = true;
    [SerializeField]
    private List<GameObject> movePoint;

    private GameObject startPointObject;
    private Rigidbody2D rb;
    private int nowPoint = 0;
    private bool returnPoint = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �󔒂��폜
		for (int i = movePoint.Count - 1; i >= 0; i--)
		{
            if(movePoint[i] == null)
			{
                movePoint.RemoveAt(i);
			}
		}

        if (movePoint != null && movePoint.Count > 0 && rb != null)
        {
            // �X�^�[�g�n�_�̋L�^
            startPointObject = new GameObject("StartPointObject");
            startPointObject.transform.position = this.gameObject.transform.position;
            movePoint.Insert(0, startPointObject);
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            switch (moveType)
            {
                case MoveType.RoundTrip: RoundTrip(); break;
                case MoveType.Loop: Loop(); break;
            }
        }
    }

    private void RoundTrip()
    {
        if (movePoint.Count > 1 && rb != null)
        {
            int nextPoint = nowPoint + (returnPoint ? -1 : 1);
            //�ڕW�|�C���g�Ƃ̌덷���킸���ɂȂ�܂ňړ�
            if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
            {
                //���ݒn���玟�̃|�C���g�ւ̃x�N�g�����쐬
                Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                //���̃|�C���g�ֈړ�
                rb.MovePosition(toVector);
            }
            //���̃|�C���g���P�i�߂�
            else
            {
                rb.MovePosition(movePoint[nextPoint].transform.position);
                nowPoint = nowPoint + (returnPoint ? -1 : 1);

                //���ݒn���z��̍Ōゾ�����ꍇ
                if (0 >= nowPoint || nowPoint + 1 >= movePoint.Count)
                {
                    returnPoint = !returnPoint;
                }
            }
        }
    }

    private void Loop()
    {
        if (movePoint.Count > 1 && rb != null)
        {
            int nextPoint = nowPoint + 1;
            if(nextPoint >= movePoint.Count)
			{
                nextPoint = 0;
			}
            //�ڕW�|�C���g�Ƃ̌덷���킸���ɂȂ�܂ňړ�
            if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
            {
                //���ݒn���玟�̃|�C���g�ւ̃x�N�g�����쐬
                Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                //���̃|�C���g�ֈړ�
                rb.MovePosition(toVector);
            }
            //���̃|�C���g���P�i�߂�
            else
            {
                rb.MovePosition(movePoint[nextPoint].transform.position);
                if(nowPoint++ > movePoint.Count)
				{
                    nowPoint = 0;
                }
            }
        }
    }

}
