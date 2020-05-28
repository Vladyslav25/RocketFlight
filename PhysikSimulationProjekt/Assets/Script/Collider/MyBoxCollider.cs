using UnityEngine;
using VektorenFormativ;

public class MyBoxCollider : MyCollider
{
    public Vector size = new Vector(0, 0, 0);

    private Cuboid cub;
    private MeshFilter meshF;

    private void Start()
    {
        meshF = GetComponent<MeshFilter>();
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

    public override Shape Get() { return cub; }

    public void LogVerticies()
    {
        for (int i = 0; i < cub.m_Vertices.Length; i++)
        {
            Debug.Log(GetVerticis()[i]);
        }
    }

    public override void CreateColl()
    {
        Vector[] tmp = new Vector[8];
        tmp = MeshVerticisToCubeVerticies(meshF.mesh.vertices);
        for (int i = 0; i < 8; i++)
        {
            tmp[i] = Matrix.TRS((Vector)transform.position + offset, transform.eulerAngles, (Vector)transform.lossyScale + size) * tmp[i];
        }
        cub = new Cuboid(tmp);
    }

    public override void UpdateColl()
    {
        Vector[] tmp = new Vector[8];
        tmp = MeshVerticisToCubeVerticies(meshF.mesh.vertices);
        for (int i = 0; i < 8; i++)
        {
            tmp[i] = Matrix.TRS((Vector)transform.position + offset, transform.eulerAngles, (Vector)transform.lossyScale + size) * tmp[i];
        }
        cub.m_Vertices = tmp;
    }

    public Vector[] GetVerticis()
    {
        return cub.m_Vertices;
    }

    private void Gravity()
    {
        Vector oldPos = transform.position;
        Vector newPos = new Vector();
        newPos = Matrix.Translate(Physics.gravity * Time.deltaTime) * oldPos;
        transform.position = newPos;
    }

    private Vector[] MeshVerticisToCubeVerticies(Vector3[] _vertices)
    {
        return new Vector[] { _vertices[7], _vertices[6], _vertices[0], _vertices[1], _vertices[5], _vertices[4], _vertices[2], _vertices[3] };
    }

    private void OnDrawGizmos()
    {
        if (this == null || cub == null)
        {
            return;
        }
        Gizmos.color = Color.red;

        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[1]);
        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[3]);
        Gizmos.DrawLine(cub.m_Vertices[1], cub.m_Vertices[2]);
        Gizmos.DrawLine(cub.m_Vertices[2], cub.m_Vertices[3]);

        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[4]);
        Gizmos.DrawLine(cub.m_Vertices[1], cub.m_Vertices[5]);
        Gizmos.DrawLine(cub.m_Vertices[2], cub.m_Vertices[6]);
        Gizmos.DrawLine(cub.m_Vertices[3], cub.m_Vertices[7]);

        Gizmos.DrawLine(cub.m_Vertices[4], cub.m_Vertices[5]);
        Gizmos.DrawLine(cub.m_Vertices[5], cub.m_Vertices[6]);
        Gizmos.DrawLine(cub.m_Vertices[6], cub.m_Vertices[7]);
        Gizmos.DrawLine(cub.m_Vertices[7], cub.m_Vertices[4]);
    }

    private void OnDrawGizmosSelected()
    {
        if (this == null || cub == null)
        {
            return;
        }
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[1]);
        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[3]);
        Gizmos.DrawLine(cub.m_Vertices[1], cub.m_Vertices[2]);
        Gizmos.DrawLine(cub.m_Vertices[2], cub.m_Vertices[3]);

        Gizmos.DrawLine(cub.m_Vertices[0], cub.m_Vertices[4]);
        Gizmos.DrawLine(cub.m_Vertices[1], cub.m_Vertices[5]);
        Gizmos.DrawLine(cub.m_Vertices[2], cub.m_Vertices[6]);
        Gizmos.DrawLine(cub.m_Vertices[3], cub.m_Vertices[7]);

        Gizmos.DrawLine(cub.m_Vertices[4], cub.m_Vertices[5]);
        Gizmos.DrawLine(cub.m_Vertices[5], cub.m_Vertices[6]);
        Gizmos.DrawLine(cub.m_Vertices[6], cub.m_Vertices[7]);
        Gizmos.DrawLine(cub.m_Vertices[7], cub.m_Vertices[4]);
    }

}
