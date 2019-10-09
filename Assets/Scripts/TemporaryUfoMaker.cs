using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryUfoMaker : MonoBehaviour
{
    public float StartHeight;
    public List<Vector3> UfoSpawnList=new List<Vector3>();
    public GameObject UFOprefab;
    public float SpawnTime = 1;
    public bool CanUfoMake=true;
    public int UfoAngleX=0;
    public int UfoAngleY=0;
    public int UfoAngleZ=0;
    public Quaternion UfoAngle;
    // Start is called before the first frame update
    void Start()
    {
        UfoAngle = Quaternion.Euler(UfoAngleX, UfoAngleY, UfoAngleZ);
        UfoSpawnList.Clear();
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("UfoSpawnSpot").Length; i++)
        {
                int x = (int)GameObject.FindGameObjectsWithTag("UfoSpawnSpot")[i].transform.position.x;
                int y = (int)GameObject.FindGameObjectsWithTag("UfoSpawnSpot")[i].transform.position.y;
                int z = (int)GameObject.FindGameObjectsWithTag("UfoSpawnSpot")[i].transform.position.z;
                Vector3 Vec = new Vector3(x,y,z);
                UfoSpawnList.Add(Vec);
        }
        
        if (!UFOprefab)
        {
            UFOprefab = Resources.Load("TemporaryUfo") as GameObject;
        }
        StartCoroutine(MakeUFO());
    }
    IEnumerator MakeUFO()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (CanUfoMake == true)
            {
               {
                    for (int i = 0; i < UfoSpawnList.Count; i++)
                    {
                        Instantiate(UFOprefab, new Vector3(UfoSpawnList[i].x, UfoSpawnList[i].y, UfoSpawnList[i].z), UfoAngle);
                        
                    }
                }

                yield return new WaitForSeconds(SpawnTime);
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
