using UnityEngine;
using System.Collections;

public class DestroyScale : MonoBehaviour
{

    public float m_fLifeTime = 0.3f;


    // read only
    protected float m_fStartTime = 0;
    protected float m_fStartDestroyTime;


	// Use this for initialization
	void Start () {

        m_fStartTime = GetEngineTime();
	}

    void OnEnable()
    {
        m_fStartTime = GetEngineTime();
    }

	// Update is called once per frame
	void Update () {

        if (m_fStartTime + m_fLifeTime < GetEngineTime())
        {
            Destroy(gameObject);
        }
        else
        {
            float we = 1.0f - (GetEngineTime() - m_fStartTime) / m_fLifeTime;
            transform.localScale = new Vector3(we, we, we);           
        }
	}

    public static float GetEngineTime()
    {
        if (Time.time == 0)
            return 0.000001f;
        return Time.time;
    }
}
