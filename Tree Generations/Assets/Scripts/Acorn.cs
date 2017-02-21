using UnityEngine;

public class Acorn : MonoBehaviour
{

    public Dom aGamete1, aGamete2, bGamete1, bGamete2, cGamete1, cGamete2, dGamete1, dGamete2;

    public GeneTree gt;
    GameObject treePrefab;
    bool isGen;

    public Acorn()
    {

    }

    void Awake()
    {
        //GetComponent<MeshRenderer>().enabled = false; //make it invisible.
        isGen = false;
    }

    void LateUpdate()
    {
        if (!isGen)
        {
            Generate();
            isGen = true;
        }
    }

    public void Generate()
    {
        //create chromosomes, add genes
        //chromosome 1    chromosome 2    chromosome 3
        // ___________     ___________     ___________
        //(___A___B___)   (_____C_____)   (_____D_____)

        gt = new GeneTree();
        gt.AddChromosome();
        gt.PushGene(aGamete1, aGamete2, false);
        gt.PushGene(bGamete1, bGamete2, false);

        gt.AddChromosome();
        gt.PushGene(cGamete1, cGamete2, false);

        gt.AddChromosome();
        gt.PushGene(dGamete1, dGamete2, true);


        treePrefab = (GameObject)Instantiate(Resources.Load("Tree Prefabs/Tree" + gt.GetPhenotypeReadout()),this.transform.position,Quaternion.Euler(0,Random.Range(0,360),0),this.transform);
    }

    public void SetGametes(Dom a1, Dom a2, Dom b1, Dom b2, Dom c1, Dom c2, Dom d1, Dom d2)
    {
        this.aGamete1 = a1;
        this.aGamete2 = a2;
        this.bGamete1 = b1;
        this.bGamete2 = b2;
        this.cGamete1 = c1;
        this.cGamete2 = c2;
        this.dGamete1 = d1;
        this.dGamete2 = d2;
    }
}
