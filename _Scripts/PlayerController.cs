using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float fMoveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("a"))
        {
            transform.localPosition -= new Vector3(fMoveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey("d"))
        {
            transform.localPosition += new Vector3(fMoveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

	}
}
