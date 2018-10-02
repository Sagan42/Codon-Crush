using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour {
    public int xSize, ySize;
    private GameObject[] bases;
    public float basesEspace = 1;
    private Grid[,] item;

    void Start()
    {
        Getbases();
        FillGrid();
    }

    void FillGrid()
    {
        item = new Grid[xSize, ySize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                item [x, y] = Instance(x, y);
            }
        }
    }

    Grid Instance (int x, int y)
    {
        GameObject randombase = bases[Random.Range(0, bases.Length)];
        GameObject newbase = (GameObject) Instantiate(randombase, new Vector3(x * basesEspace, y), Quaternion.identity);
        newbase.GetComponent<Grid>().ChangePosition(x, y);
        return newbase.GetComponent<Grid>();
    }

    void Getbases()
    {
        bases = Resources.LoadAll <GameObject> ("Prefabs");
        for (int i = 0; i < bases.Length; i++)
        {
            bases[i].GetComponent<Grid>().id = i;
        }
    }
}
