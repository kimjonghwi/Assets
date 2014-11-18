using UnityEngine;
using System.Collections;

public class WeaponScale : MonoBehaviour {

    public float fEndDis;
    public float fEndScale;

    //float fEndDis;
    static float fScale;

	// Use this for initialization
	void Start () {

        fScale = 1 - fEndScale;
	}
	
	// Update is called once per frame
	void Update () {

        float perDis = 1 - (transform.localPosition.y / fEndDis);

        float fAddScale = fScale * perDis + fEndScale;




        transform.localScale = new Vector3(fAddScale, fAddScale, fAddScale);

        if (transform.localPosition.y > 600)
            DestroyObject(gameObject);

	}
}
