using UnityEngine;
using VektorenFormativ;

public abstract class Collision : MonoBehaviour
{
    /// <summary>
    /// Collision zwischen 2 GameObjects
    /// </summary>
    /// <param name="_obj1">Dieses Objekt wird bei Kollision zurück gegeben</param>
    /// <param name="_obj2">Dieses Objekt wird bei Kollision <b>nicht</b> zurück gegeben</param>
    /// <returns>Das GameObjekt vom 1.Parameter</returns>
    public virtual GameObject OnCollision(GameObject _obj1, GameObject _obj2)
    {
        MyCollider[] coll_obj1 = _obj1.GetComponents<MyCollider>();
        MyCollider[] coll_obj2 = _obj2.GetComponents<MyCollider>();

        foreach (MyCollider coll_1 in coll_obj1)
        {
            foreach (MyCollider coll_2 in coll_obj2)
            {
                if (coll_1 is MyBoxCollider && coll_2 is MyBoxCollider)
                {
                    if (CheckForCub_Cub((MyBoxCollider)coll_1, (MyBoxCollider)coll_2))
                        return _obj1;
                    else
                        return null;
                }
                if (coll_1 is MySphereCollider && coll_2 is MySphereCollider)
                {
                    if (CheckForSph_Sph((MySphereCollider)coll_1, (MySphereCollider)coll_2))
                        return _obj1;
                    else
                        return null;
                }
                if (coll_1 is MyBoxCollider && coll_2 is MySphereCollider ||
                    coll_1 is MySphereCollider && coll_2 is MyBoxCollider)
                {
                    if (CheckForCub_Sph(coll_1, coll_2))
                        return _obj1;
                    else
                        return null;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Check for Cuboid and Cuboid
    /// </summary>
    /// <param name="_coll1"></param>
    /// <param name="_coll2"></param>
    /// <returns></returns>
    private MyBoxCollider CheckForCub_Cub(MyBoxCollider _coll1, MyBoxCollider _coll2)
    {
        if (Collisions.CuboidInCuboid((Cuboid)_coll1.Get(), (Cuboid)_coll2.Get()))
        {
            return _coll1;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Check for Sphere and Sphere
    /// </summary>
    /// <param name="_coll1"></param>
    /// <param name="_coll2"></param>
    /// <returns></returns>
    private MySphereCollider CheckForSph_Sph(MySphereCollider _coll1, MySphereCollider _coll2)
    {
        if (Collisions.SphereInSphere((Sphere)_coll1.Get(), (Sphere)_coll2.Get()))
        {
            return _coll1;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Check for Cuboid and Sphere
    /// </summary>
    /// <param name="_coll1"></param>
    /// <param name="_coll2"></param>
    /// <returns></returns>
    private MyCollider CheckForCub_Sph(MyCollider _coll1, MyCollider _coll2)
    {
        if (_coll1 is MyBoxCollider && _coll2 is MySphereCollider)
        {
            if (Collisions.CuboidInSphere((Cuboid)_coll1.Get(), (Sphere)_coll2.Get()))
            {
                return _coll1;
            }
            else
            {
                return null;
            }
        }
        else
        if (_coll1 is MySphereCollider && _coll2 is MyBoxCollider)
        {
            if (Collisions.CuboidInSphere((Cuboid)_coll2.Get(), (Sphere)_coll1.Get()))
            {
                return _coll1;
            }
            else
            {
                return null;
            }
        }
        else
        {
            throw new System.Exception("Es müssen zwei verschiedene MyCollider in <CheckForCub_Sph> angewendet werden");
        }
    }
}
