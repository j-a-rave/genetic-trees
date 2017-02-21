using UnityEngine;
using System.Collections.Generic;

public class AcornStartPopulator : MonoBehaviour {

    GameObject[] acornObjs;
    List<Acorn> acorns;

	// Use this for initialization
	void Start () {
        acornObjs = GameObject.FindGameObjectsWithTag("Acorn");
        acorns = new List<Acorn>();
        for(int i = 0; i < acornObjs.Length; i++)
        {
            acorns.Add(acornObjs[i].GetComponent<Acorn>());
        }
        foreach(Acorn a in acorns)
        {
            a.Generate();
        }
	}
}
