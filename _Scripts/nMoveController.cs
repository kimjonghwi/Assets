using UnityEngine;
using System.Collections;

public class nMoveController : MonoBehaviour {

    public bool bMove = false;
    public bool bRot = false;
    public float MoveSpeed;
    public Vector3 MoveValue;

    public Vector3 RotValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( bMove )
            transform.localPosition += MoveValue * Time.deltaTime * MoveSpeed;

        if (bRot)
        {
            Vector3 curRot = Quaternion.ToEulerAngles(transform.localRotation);
            Vector3 tempRot = curRot + RotValue * Time.deltaTime;
            transform.localRotation = Quaternion.EulerAngles(tempRot);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (gameObject.name == collision.gameObject.name)
            return;

        DestroyScale dc = gameObject.GetComponent<DestroyScale>();
        if( dc != null)
        {
            dc.enabled = true;
            //Destroy(gameObject);

            GameObject go = SETools.AddChild(gameObject, "Prefab/FxHit");
            go.transform.position = gameObject.transform.position;
        }
        else
            Destroy(gameObject);

        bRot = false;
        bMove = false;

    }

}
