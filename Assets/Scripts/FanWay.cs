using System.Collections.Generic;
using UnityEngine;

public class FanWay : MonoBehaviour
{
    public Transform center;
    
    private GameObject go;
    private List<GameObject> points;
    private float time;


    private void Start()
    {
        points = new List<GameObject>();

        go = transform.GetChild(0).gameObject;

        for (int i = 0; i < Random.Range(4,7); i++)
        {
            points.Add(Instantiate(go, transform));
            CardController.S.CreateCard();
            CardController.S.cardList[i].transform.position = center.position;            
        }

        Destroy(go);
        
        time = 0;
    }


    public void RemovePoint(int currentIndexCard)
    {
        Destroy(points[currentIndexCard]);
        points.Remove(points[currentIndexCard]);

        time = 0;
    }


    private void Update()
    {
        time =+ Time.deltaTime;

        for (int i = 0; i < points.Count; i++)
        {
            CardController.S.cardList[i].transform.up = (points[i].transform.position - center.position).normalized;

            Vector3 target = CardController.S.cardList[i].transform.up * Vector3.Distance(center.position, points[0].transform.position) + center.position;
            CardController.S.cardList[i].transform.position = Vector3.Lerp(CardController.S.cardList[i].transform.position, target, time * 5);
        }
    }
}
