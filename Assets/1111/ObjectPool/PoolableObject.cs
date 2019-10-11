using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{

    protected ObjectPools<PoolableObject> pPool;

    public virtual void Create(ObjectPools<PoolableObject> pool)
    {
        pPool = pool;

        gameObject.SetActive(false);
    }

    public virtual void Dispose()
    {
        if(pPool != null) pPool.PushObject(this);
    }

    public virtual void _OnEnableContents()
    {
        // to do ...
    }

    public virtual void _OnDisableContents()
    {
        // to do ...
    }
}
