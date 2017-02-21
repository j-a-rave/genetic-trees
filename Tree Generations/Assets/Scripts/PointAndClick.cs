using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PointAndClick : MonoBehaviour {

    List<GeneTree> gt;
    static Ray ray = new Ray();
    static RaycastHit hit = new RaycastHit();
    static GameObject acornObj;

    public Text counter;
    string counteroutput;

    void Start()
    {
        gt = new List<GeneTree>();
        counteroutput = "";
    }

    void Update () {

        if (gt.Count < 2) //not enough parents in list to breed
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f)) //cast to tree layer
                {
                    if (hit.transform.gameObject.layer == 8)
                    {
                        gt.Add(hit.collider.gameObject.transform.parent.GetComponent<Acorn>().gt); //add parent genes
                        GUIUpdate();
                    }
                }
            }
        }

        else //two parents in list
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f)) //cast to ground layer
                {
                    if (hit.transform.gameObject.layer == 9)
                    {
                        acornObj = (GameObject)Instantiate(new GameObject(),hit.point,Quaternion.identity);
                        Acorn acorn = acornObj.AddComponent<Acorn>();

                        List<Dom> chromatid1 = gt[0].GetChromatid();
                        List<Dom> chromatid2 = gt[1].GetChromatid();
                        acorn.SetGametes(
                            chromatid1[0],
                            chromatid2[0],
                            chromatid1[1],
                            chromatid2[1],
                            chromatid1[2],
                            chromatid2[2],
                            chromatid1[3],
                            chromatid2[3]
                            );
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            gt.Clear();
            GUIUpdate();
        }
	}

    void GUIUpdate()
    {
        counteroutput = "";
        foreach(GeneTree genetree in gt)
        {
            counteroutput += ".";
        }
        counter.text = counteroutput;

    }
}
