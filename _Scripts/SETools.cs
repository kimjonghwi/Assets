using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

//static public class SETools
public class SETools : MonoBehaviour
{
    //--------------------------------------------------------------
    static public GameObject Instantiate(string str)
    {
        GameObject go = ResourcesLoad(str);

        if (go == null) return null;

        go = GameObject.Instantiate(go) as GameObject;

        if (go == null)
        {
            Debug.Log("<color=red> Instantiate fail : " + str + "</color>");
        }

        return go;
    }

    static public GameObject ResourcesLoad(string str)
    {
        GameObject go = Resources.Load(str, typeof(GameObject)) as GameObject;

        if (go == null)
        {
            Debug.Log("<color=red> ResourcesLoad fail : " + str + "</color>");
        }

        return go;
    }

    //--------------------------------------------------------------

    static public GameObject AddChild(GameObject parent, string prefabName)
    {
        return AddChild(parent, ResourcesLoad(prefabName));
    }

    static public GameObject AddChild(GameObject parent, GameObject prefab)
    {
        GameObject go = GameObject.Instantiate(prefab) as GameObject;

        if (go != null && parent != null)
        {
            Transform t = go.transform;
            t.parent = parent.transform;
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            go.layer = parent.layer;
        }
        return go;
    }
    //--------------------------------------------------------------

    static public void ReSet(Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    static public void ReSet(GameObject go)
    {
        ReSet(go.transform);
    }

    static public void ReSet(Component comp)
    {
        ReSet(comp.transform);
    }

    //--------------------------------------------------------------

    public static float GetEngineTime()
    {
        if (Time.time == 0)
            return 0.000001f;
        return Time.time;
    }

    public static float GetEngineDeltaTime()
    {
        return Time.deltaTime;
    }

    //--------------------------------------------------------------


    static public void AllChildDestroy(GameObject go)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            UnityEngine.Object.Destroy(go.transform.GetChild(i).gameObject);
        }
    }

    //--------------------------------------------------------------
}
