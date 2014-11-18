using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    float fTime = 0.0f;
    public float fCreateDelay;
    public float fWeaponSpeed;

    public PlayerController PC; 

	// Use this for initialization
	void Start () {

	}
	
	void Update () 
    {
        if (fTime < Time.time)
        {
            fTime = Time.time + fCreateDelay;
            //SETools.Instantiate("Prefab/Weapon");
            GameObject go = SETools.AddChild(gameObject, "Prefab/Weapon");

            go.transform.localPosition = new Vector3(PC.transform.localPosition.x, 0.0f, 0.0f);

            if (fWeaponSpeed != 0)
            {
                nMoveController mc = go.GetComponent<nMoveController>();
                mc.MoveSpeed = fWeaponSpeed;
            }
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit Obj name :" + collision.gameObject.name);
    }
}
