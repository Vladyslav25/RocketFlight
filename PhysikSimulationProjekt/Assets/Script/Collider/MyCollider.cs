using UnityEngine;
using VektorenFormativ;

public abstract class MyCollider : MonoBehaviour
{

    public Vector offset = new Vector(0, 0, 0);
    public bool PhysicOn;
    public bool isTrigger;

    public abstract void CreateColl();
    public abstract void UpdateColl();
    public abstract Shape Get();
}
