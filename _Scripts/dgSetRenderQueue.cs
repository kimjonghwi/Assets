using UnityEngine;
using System.Collections;

public class dgSetRenderQueue : MonoBehaviour {

    public bool ReSet = false;
    public int nRenderQueue = 0; 
	// Use this for initialization
	void Start ()
    {
        ReSet = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (ReSet == true)
        {
            ReSet = false;
            Renderer[] Objects = GetComponentsInChildren<Renderer>();
            foreach (Renderer smr in Objects)
            {
                smr.sharedMaterial.renderQueue = nRenderQueue;
            }
        }	
	}
}
