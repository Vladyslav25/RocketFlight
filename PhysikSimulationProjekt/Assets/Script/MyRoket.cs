using UnityEngine;
using VektorenFormativ;

public class MyRoket : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float RotSpeed;
    [SerializeField]
    private Vector camOffset;
    [SerializeField]
    private GameObject LookAt;

    public float Speedoffset;
    public bool moveable = true;

    private ParticleSystem particle;
    private Vector lastDir = new Vector();
    private Vector currDir = new Vector();
    private float currSpeed;
    private float rot = 0;
    private float lastCurrSpeed;
    private Camera cam;

    public float CurrSpeed
    {
        set
        {
            currSpeed = Mathf.Clamp(value, 0, 3);
        }
        get
        {
            return currSpeed;
        }
    }

    private void Start()
    {
        particle = transform.Find("Trail").GetComponent<ParticleSystem>();
        cam = Camera.main;
        transform.rotation = Quaternion.Euler(new Vector(0, 0, 180));
    }

    private void Update()
    {
        if (moveable)
        {
            Movement();
        }
        cam.transform.position = LookAt.transform.position + (Vector3)camOffset * (CurrSpeed * Speedoffset + 1); //Pos der Cam
        SetTrail();
        Debug.Log(CurrSpeed + " | " + currDir);
    }

    private void SetTrail() //Passt die Partikel der Geschwindigkeit der Rakete an
    {
        var emission = particle.emission;

        if (Input.GetKey(KeyCode.W))
        {
            emission.rateOverTime = Mathf.Lerp(0, 100, CurrSpeed * 0.333333f);
        }
        else
        {
            emission.rateOverTime = 0;
        }
    }

    private void Movement() //Grundlegende Movemnt der Rakete
    {
        Vector dir = new Vector(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) //Vorwärts
        {
            if (lastDir == -(Vector)transform.up) { CurrSpeed = 0; }
            CurrSpeed += Time.deltaTime;
            dir = transform.up * CurrSpeed;
            lastDir = transform.up;
            if (currDir != (Vector)transform.up)
            {
                currDir = transform.up;
            }
        }
        if (Input.GetKey(KeyCode.S)) //Rückwärts
        {
            if (lastDir == (Vector)transform.up) { CurrSpeed = 0; }
            CurrSpeed += Time.deltaTime;
            dir = -transform.up * CurrSpeed;
            lastDir = -transform.up;
            if (currDir != -(Vector)transform.up)
            {
                currDir = -transform.up;
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && CurrSpeed > 0.0f) //Simuliert Trägheit
        {
            CurrSpeed -= Time.deltaTime * 1.2f;
            dir = lastDir * CurrSpeed;
        }

        if (Input.GetKey(KeyCode.D)) //Rechts
        {
            rot -= RotSpeed;
        }
        else
        if (Input.GetKey(KeyCode.A)) //Links
        {
            rot += RotSpeed;
        }

        dir *= Speed; //Speed Multiplikator
        dir += (Vector)Physics.gravity; //Gravitation

        transform.position = Matrix.Translate(dir * Time.deltaTime) * transform.position; //Translate
        transform.rotation = Quaternion.Euler(new Vector(0, 0, rot)); //Rotiert
    }
}
