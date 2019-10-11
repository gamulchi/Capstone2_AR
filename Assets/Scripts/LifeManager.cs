using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject Canvas;
    private List<GameObject> AllLifes = new List<GameObject>();
    public List<GameObject> Lifes = new List<GameObject>();
    public int CurrentLifeCount;
    public GameObject PauseButton;
    public bool IsTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!Canvas)
        {
            Canvas = transform.parent.gameObject;
        }
        if (Lifes.Count == 0)
        {
            AllLifes.Clear();
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Lifes")
                {
                    AllLifes.Add(child.gameObject);
                }
            }
            CurrentLifeCount = AllLifes.Count;
            Lifes.Add(AllLifes[0].gameObject);
            Lifes.Add(AllLifes[0].gameObject);
            Lifes.Add(AllLifes[0].gameObject);
            Lifes.Add(AllLifes[0].gameObject);
            //이 부분 없으면 Life 들 Hierachy 순서 뒤바뀌었으면 인덱스 에러남 

            for (int i = 0; i < AllLifes.Count; i++)
            {
                if (AllLifes[i].name == "Life1")
                {
                    Lifes.RemoveAt(0);
                    Lifes.Insert(0, AllLifes[i].gameObject);
                }
                else if (AllLifes[i].name == "Life2")
                {
                    Lifes.RemoveAt(1);
                    Lifes.Insert(1, AllLifes[i].gameObject);
                }
                else if (AllLifes[i].name == "Life3")
                {
                    Lifes.RemoveAt(2);
                    Lifes.Insert(2, AllLifes[i].gameObject);
                }
                else
                {
                    Lifes.RemoveAt(3);
                    Lifes.Insert(3, AllLifes[i].gameObject);
                }
            }
        }
        else
        {
            CurrentLifeCount = Lifes.Count;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouched == true)
        {
            CurrentLifeCount--;
            IsTouched = false;
        }
        ManagineLifes();
    }
    void ManagineLifes()
    {
        for (int i = Lifes.Count; i > CurrentLifeCount; i--)
        {
            if (Lifes[i - 1].activeInHierarchy == true)
            {
                print((i - 1) + "번째 목숨 비활성화");
                Lifes[i - 1].SetActive(false);
            }
            
           
        if (CurrentLifeCount <= 0)
            {
                if (Lifes[0].activeInHierarchy == true)
                {
                    Lifes[0].SetActive(false);
                }
                if (Lifes[1].activeInHierarchy == true)
                {
                    Lifes[1].SetActive(false);

                }
                if (Lifes[2].activeInHierarchy == true)
                {
                    Lifes[2].SetActive(false);

                }
                if (Lifes[3].activeInHierarchy == true)
                {
                    Lifes[3].SetActive(false);
                }
                if (Canvas.GetComponent<EndingManager>().CurrentEndingState == EndingManager.EndingState.GameNotFinished)
                {
                    Canvas.GetComponent<EndingManager>().CurrentEndingState = EndingManager.EndingState.BadEnding;

                }
            }
        }
    }
}
