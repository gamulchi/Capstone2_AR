using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryUfoMaker : MonoBehaviour
{
    public float StartHeight;
    public List<Vector2> UfoSpawnList=new List<Vector2>();
    public GameObject UFOprefab;
    public float SpawnTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartHeight = this.gameObject.transform.position.y;
        UfoSpawnList.Clear();
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("UfoSpawnSpot").Length; i++)
        {
            Vector2 Vec = new Vector2(GameObject.FindGameObjectsWithTag("UfoSpawnSpot")[i].transform.position.x, GameObject.FindGameObjectsWithTag("UfoSpawnSpot")[i].transform.position.z);
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
            for(int i = 0; i < UfoSpawnList.Count; i++)
            {
                Instantiate(UFOprefab, new Vector3(UfoSpawnList[i].x, StartHeight - 2, UfoSpawnList[i].y),Quaternion.Euler(0,0,0));
            }
            yield return new WaitForSeconds(SpawnTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
