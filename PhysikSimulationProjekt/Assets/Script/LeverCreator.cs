using System.Collections.Generic;
using UnityEngine;
using VektorenFormativ;

public class LeverCreator : MonoBehaviour
{
    [SerializeField]
    private int count;
    [SerializeField]
    private GameObject prefabCub;
    [SerializeField]
    private GameObject prefabSph;

    private Transform TopLeft;
    private Transform BotRight;

    public List<GameObject> asteoriden = new List<GameObject>();

    void Awake() //Create an asteoroidfield inside the two corners with random asteoroid positions
    {
        TopLeft = transform.Find("TopLeft");
        BotRight = transform.Find("BotRight");
        for (int i = 0; i < count; i++)
        {
            Vector pos = new Vector(Random.Range(TopLeft.position.x, BotRight.position.x), 
                Random.Range(TopLeft.position.y, BotRight.position.y), 0); //Random Pos
            GameObject a;
            if (Random.Range(0, 2) == 1) //Random Shape
            {
                a = Instantiate(prefabCub, pos, prefabCub.transform.rotation);
            }
            else
            {
                a = Instantiate(prefabSph, pos, prefabCub.transform.rotation);
            }

            float size = Random.Range(6, 10); //Get random Size
            a.transform.localScale = new Vector3(size, size, size); //Set random size

            asteoriden.Add(a); //Add to List
        }
    }
}
