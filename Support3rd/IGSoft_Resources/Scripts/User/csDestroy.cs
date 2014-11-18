using UnityEngine;
using System.Collections;

public class csDestroy : MonoBehaviour {
	
	public float	 RemoveTime;
	float			 nowTime;
	// Use this for initialization
	void Start () {
		nowTime = Time.time + RemoveTime;
	}
	public void SetInfo(float removeTime)
	{
		RemoveTime = removeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nowTime)
			Destroy(gameObject);
	}
}
