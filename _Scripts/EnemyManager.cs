using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    float fTime = 0.0f;
    public float fCreateDelay;


    public float StartPos = 400.0f;

    // 게임 레벨
    float nlevel = 1;

    // 게임 레벨업 가능한 카운트
    int nCurCount = 0;
    public int nlevelCount = 10;

    // 게임 레벨 상승시 쉬는 타임
    public float fWaitTime = 1.0f;

	void Start () {

        SETools.AllChildDestroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (fTime < Time.time)
        {
            fTime = Time.time + fCreateDelay;
            GameObject go = SETools.AddChild(gameObject, "Prefab/Enemy");

            go.name = "Enemy";

            nMoveController mc = go.GetComponent<nMoveController>();

            if (Random.Range(0, 2) == 1)
            {
                mc.MoveValue = new Vector3( -1.0f, 0.0f, 0.0f);
                go.transform.localPosition = new Vector3(StartPos, 0.0f, 0.0f);
            }
            else
            {
                mc.MoveValue = new Vector3(1.0f, 0.0f, 0.0f);
                go.transform.localPosition = new Vector3(-StartPos, 0.0f, 0.0f);
                go.transform.localRotation = Quaternion.Euler(0f, 180.0f, 0f);
            }

            nCurCount++;

            if (nCurCount == nlevelCount)
            {
                nlevel++;
            }
        }
	}
}
