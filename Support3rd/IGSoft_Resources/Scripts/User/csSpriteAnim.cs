using UnityEngine;
using System.Collections;

public enum animType
{
	Once,
	Loop,
	PingPong
	
};
public class csSpriteAnim : MonoBehaviour {
	
	public animType				spriteType;
	public string[]				spriteName;
	public float				WaitTime;
	public bool					AutoDestruct;
	public float				DestructTime;
	
	UISprite					sprite;
	
	int							spriteCount;
	
	int							nCount = 0;
	float						nTime;
	float						dTime;
	
	bool						nStop;
	bool						nPingPong;
	
	void Start()
	{
		sprite 			= gameObject.GetComponent<UISprite>();
		spriteCount		= spriteName.Length;
		
		nTime			= Time.time;
		dTime			= Time.time;
		
		DrawSprite();
//		Debug.Log (WaitTime);
	}

    void OnEnable()
    {
        nCount = 0;
        nStop = false;
    }

	void Update()
	{
		if(!nStop)
			SpriteAnim();
		
		if(Time.time - dTime > DestructTime && AutoDestruct)
			Destroy (gameObject);
	}
	
	void SpriteAnim()
	{
		if(Time.time - nTime > WaitTime)
		{
			if(nPingPong && nCount > 0)		nCount--;
			else if(spriteCount > nCount)	nCount++;
			
			if(nPingPong && nCount == 0)
				AnimCheck();
			
			if(nCount == spriteCount)
			{
				AnimCheck();
				
				if(nStop)
				{
					return ;
				}
			}
			
			nTime = Time.time;
			DrawSprite();
			
		}
	}
	
	void DrawSprite()
	{
		sprite.spriteName = spriteName[nCount];
	}
						
	void AnimCheck()
	{
		if(spriteType == animType.Once)
			nStop = true;
		else if(spriteType == animType.Loop)
			nCount = 0;
		else if(spriteType == animType.PingPong)
		{
			if(nPingPong) 
				nPingPong = false;
			else 
			{
				nPingPong 	= true;
				nCount		-= 2;
			}
		}
	}
	
}
