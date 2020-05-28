using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Physik : Collision
{
    [SerializeField]
    private GameObject roket_coll;
    [SerializeField]
    private GameObject roket_script;
    [SerializeField]
    private GameObject plattform;
    [SerializeField]
    private GameObject world;

    private LeverCreator script_levelCreator;
    private MyRoket script_roket;

    private List<GameObject> borders = new List<GameObject>();
    private List<GameObject> roket_colls = new List<GameObject>();
    private List<GameObject> tagged_roket_colls = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in roket_coll.transform) //Get ALL the Collider from the Obj
        {
            roket_colls.Add(child.gameObject);
        }

        foreach (Transform child in roket_coll.transform) //Get ALL the isTrigger == true Collider from the Obj
        {
            if (child.GetComponent<MyCollider>().isTrigger)
            {
                tagged_roket_colls.Add(child.gameObject);
            }
        }

        foreach (Transform child in world.transform.Find("Border").transform) //Get the Border
        {
            borders.Add(child.gameObject);
        }
        if (borders.Count == 0)
        {
            throw new Exception("Keine Borders gefunden");
        }

        script_levelCreator = world.GetComponent<LeverCreator>();

        script_roket = roket_script.GetComponent<MyRoket>();
        if (script_levelCreator.asteoriden.Count == 0)
        {
            Debug.Log("Es wurden keine Cuboids in der List gefunden");
        }
    }

    private void Update()
    {
        //Check all the possible Collisions with the rocket
        CheckForRoketAsteroiden();
        CheckForRoketPlatform();
        CheckForRoketBorder();
    }

    private void CheckForRoketBorder() //Check all the Rocketcollider with all Bordercollider
    {
        foreach (GameObject roket_coll in roket_colls)
        {
            foreach (GameObject border in borders)
            {
                if(OnCollision(roket_coll, border) != null)
                {
                    Lose();
                }
            }
        }
    }

    private void CheckForRoketPlatform() //Check all the Rocketcollider with the Platform
    {
        foreach (GameObject tagged_roket_coll in tagged_roket_colls) //Check the isTrigger-Collider with the Platform
        {
            if (OnCollision(tagged_roket_coll, plattform) != null)
            {
                if (script_roket.CurrSpeed >= 1.0f)
                    Lose();
                else
                {
                    Win();
                }
            }
        }
        foreach (GameObject roket_coll in roket_colls) //Check all Rocketcollider with the Platform
        {
            if (roket_coll.GetComponent<MyCollider>().isTrigger) //Skip the isTrigger-Collider
            {
                continue;
            }
            if (OnCollision(roket_coll, plattform) != null)
            {
                Lose();
            }
        }
    }

    private void CheckForRoketAsteroiden() //Check all Rocketcollider with all asteoroids
    {
        foreach (GameObject roket_coll in roket_colls)
        {
            foreach (GameObject obj in script_levelCreator.asteoriden)
            {
                if (OnCollision(roket_coll, obj) != null)
                {
                    Lose();
                }
            }
        }
    }

    public void Win()
    {
        script_roket.moveable = false;
        SceneManager.LoadScene("WinScreen");
    }

    public void Lose()
    {
        roket_coll.SetActive(false);
        SceneManager.LoadScene("LoseScreen");
    }
}
