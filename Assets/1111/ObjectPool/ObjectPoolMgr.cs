using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트풀 매니저에서 프리팹 등록
// 오브젝트풀 에서 Create로 오브젝트 생성
// 자식 오브젝트에서 생성과 해제
public class ObjectPoolMgr : MonoSingleton<ObjectPoolMgr>
{
    //[Header("Item ObjectPool")]
    //[Tooltip("아이템 오브젝트 풀")]
    //// 아이템 오브젝트 풀
    //public PoolableObject[] bowPrefabs;

    //public ObjectPool<PoolableObject> bowPool = new ObjectPool<PoolableObject>();

    public PoolableObject[] heroSlot;

    public ObjectPools<PoolableObject> heroSlotPool = new ObjectPools<PoolableObject>();

    void Start()
    {
        CreateHeroSlotPool();
    }

    void CreateHeroSlotPool()
    {
        int cnt = 0;

        heroSlotPool = new ObjectPools<PoolableObject>(2, () =>
        {
            heroSlot[cnt].Create(heroSlotPool);
            return heroSlot[cnt++];
        });
        heroSlotPool.Allocate();
    }

    void Test()
    {

    }
     
    //void CreateItemPool()
    //{
    //    int cnt = 0;
    //    bowPool = new ObjectPool<PoolableObject>(bowPrefabs.Length, () =>
    //    {
    //        bowPrefabs[cnt].Create(bowPool);
    //        return bowPrefabs[cnt++];
    //    });
    //    bowPool.Allocate();
      
    //}

    
}
