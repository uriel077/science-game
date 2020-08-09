using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRY : MonoBehaviour {

    public Vector3 beginPos = new Vector3(-1.0f, -1.0f, 0);
    public Vector3 endPos = new Vector3(1.0f, 1.0f, 0);

    Vector3 beginPosOffset;
    Vector3 endPosOffset;

    LineRenderer diagLine;

    void Start()
    {
        diagLine = gameObject.AddComponent<LineRenderer>();
        //diagLine.material = new Material(Shader.Find("Sprites/Default"));
        diagLine.startColor = diagLine.endColor = Color.green;
        diagLine.startWidth = diagLine.endWidth = 0.15f;

        diagLine.SetPosition(0, beginPos);
        diagLine.SetPosition(1, endPos);
    }

    void Update()
    {
        //Calculate new postion 
        Vector3 newBeginPos = transform.localToWorldMatrix * new Vector4(beginPos.x, beginPos.y, beginPos.z, 1);
        Vector3 newEndPos = transform.localToWorldMatrix * new Vector4(endPos.x, endPos.y, endPos.z, 1);

        //Apply new position
        diagLine.SetPosition(0, newBeginPos);
        diagLine.SetPosition(1, newEndPos);
    }
}
