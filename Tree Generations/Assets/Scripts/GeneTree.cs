using UnityEngine;
using System.Collections.Generic;

public class GeneTree{

    public List<List<Gene>> chromosomes;

    public GeneTree()
    {
        chromosomes = new List<List<Gene>>();
    }

    public void AddChromosome() //creates new chromosome at the end of list
    {
        chromosomes.Add(new List<Gene>());
    }

    public void PushGene(Dom g1, Dom g2, bool isCodominant) //creates new gene & pushes it onto the end of the most recently added chromosome
    {
        chromosomes[chromosomes.Count - 1].Add(new Gene(g1, g2, isCodominant));
    }

    public List<Dom> GetChromatid()
    {
        List<Dom> chromatid = new List<Dom>();

        foreach(List<Gene> chromosome in chromosomes)
        {
            //int id = Random.Range(0, 2);
            foreach (Gene gene in chromosome)
            {
                chromatid.Add(gene.alleles[Random.Range(0, 2)]);
            }
        }

        return chromatid;
    }

    public string GetPhenotypeReadout()
    {
        string hash = "";

        foreach(List<Gene> chromosome in chromosomes)
        {
            foreach(Gene gene in chromosome)
            {
                byte val = 0;
                foreach(Dom gamete in gene.alleles)
                {
                    if (gene.isCodominant)
                    {
                        switch (gamete)
                        {
                            case Dom.Dominant:
                                val++;
                                break;
                            default:
                                break;
                        }
                    } //if the gene is codominant, can result in a 0, 1, or 2 (representing gg, Gg, GG)

                    else if (val == 0)
                    {
                        switch (gamete)
                        {
                            case Dom.Dominant:
                                val++;
                                break;
                            default:
                                break;
                        }
                    } //if it isn't, can result in either 0 or 1 (dominant or recessive phenotype)
                }
                hash += val.ToString(); //append it to the end of the string
            }
        }

        return hash;
    }

}

public class Gene
{
    public List<Dom> alleles;
    public bool isCodominant;

    public Gene(Dom g1, Dom g2, bool isCodominant)
    {
        alleles = new List<Dom>();
        alleles.Add(g1); //first gamete
        alleles.Add(g2); //second gamete
        this.isCodominant = isCodominant; //if the gene is codominant
    }
}

public enum Dom { Dominant, Recessive } //Dom represents the gamete's recessive or dominant traits