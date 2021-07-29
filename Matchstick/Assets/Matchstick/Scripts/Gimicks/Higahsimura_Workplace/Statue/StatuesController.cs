using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class StatuesController : MonoBehaviour
{
    [SerializeField] private UnityEvent GimmickClear = new UnityEvent();
    [SerializeField] private int[] answer;

    private List<GameObject> StatueList;
    private List<int> playerAnswer;

    [SerializeField] private bool DebugLog = true;

    // 像が点灯したら、像側から呼ばれる
    public void StatueIgnited(int No)
	{
        playerAnswer.Add(No);
	}

	private void Awake()
	{
        StatueList = new List<GameObject>();
        playerAnswer = new List<int>();
        // 像の取得
        this.GetStatues();
        // 問題の作成
        this.CreateQuestion();
    }

	private void FixedUpdate()
	{
		if(answer.Length == playerAnswer.Count)
		{
			if (answer.SequenceEqual(playerAnswer))
			{
                GimmickClear.Invoke();
                playerAnswer.Clear(); // クリアフラグの代わり
				if (DebugLog) { Debug.Log("GimmickClear"); }
			}
		}
	}


	private void GetStatues()
	{
        var count = 0;
        while (true)
        {
            GameObject child;

            try { child = transform.GetChild(count++).gameObject; }
            catch { break; }

            var statue = child.transform.GetComponent<Statue>();
            if (statue)
			{
                statue.No = count - 1;
                StatueList.Add(child);
			}
        }
    }


    private void CreateQuestion()
	{
        answer = new int[StatueList.Count];
        answer = Enumerable.Range(0, StatueList.Count).ToArray();
        answer = answer.OrderBy(i => Guid.NewGuid()).ToArray();
    }
}
