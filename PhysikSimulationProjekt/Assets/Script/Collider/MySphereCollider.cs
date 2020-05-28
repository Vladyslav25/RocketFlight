using UnityEngine;
using VektorenFormativ;

public class MySphereCollider : MyCollider
{
    public float size;

    private Sphere sphere;

    private void Start()
    {
        CreateColl();
    }

    private void Update()
    {
        if (PhysicOn)
        {
            Gravity();
        }
        UpdateColl();
    }

    private void Gravity()
    {
        Vector oldPos = transform.position;
        Vector newPos = new Vector();
        newPos = Matrix.Translate(Physics.gravity * Time.deltaTime) * oldPos;
        transform.position = newPos;
    }

    public override Shape Get() { return sphere; }

    public void LogSphere()
    {
        Debug.Log("Center: " + sphere.m_Center);
        Debug.Log("Radius: " + sphere.m_Radius);
    }

    public override void CreateColl()
    {
        Vector center = (Vector)transform.position + offset;
        float newSize = transform.lossyScale.x * 0.5f + size;

        sphere = new Sphere(center, newSize);
    }

    public override void UpdateColl()
    {
        sphere.m_Center = (Vector)transform.position + offset;
        sphere.m_Radius = transform.lossyScale.x * 0.5f + size;
    }

    private void OnDrawGizmos()
    {
        if (this == null || sphere == null)
        {
            return;
        }
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(sphere.m_Center, sphere.m_Radius);
    }

    private void OnDrawGizmosSelected()
    {
        if (this == null || sphere == null)
        {
            return;
        }
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(sphere.m_Center, sphere.m_Radius);
    }

}
