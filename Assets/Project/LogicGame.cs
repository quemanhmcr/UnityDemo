using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LogicGame : MonoBehaviour
{
    public List<Vector3> Colors;
    public GameObject enemy;
    public GameObject player;

    public float timeRandom = 3f;
    private bool isTimeRandom = false;
    private float scopeIns = 10f;

    private int k = 0;

    // Start is called before the first frame update
    void Start()
    {
        Colors = MakeColor(3);
    }

    List<Vector3> MakeColor(int count)
    {
        List<Vector3> ColorsInFun = new List<Vector3>();

        for (int i = 0; i < count; i++)
        {
            Vector3 colorRandom = new Vector3(Random.Range(0,255), Random.Range(0, 255), Random.Range(0, 255));
            ColorsInFun.Add(colorRandom);
     
        }
        return ColorsInFun;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeRandom == false && k < 3)
        {
            StartCoroutine(InsEnemy());
        }
    }

    IEnumerator InsEnemy()
    {
        isTimeRandom = true;
        float xPlayer = player.transform.position.x;
        float yPlayer = player.transform.position.y;
        float zPlayer = player.transform.position.z;


        float xMin = xPlayer - scopeIns;
        float xMax = xPlayer + scopeIns;

        float yMin = yPlayer - scopeIns;
        float yMax = yPlayer + scopeIns;

        Instantiate(enemy, new Vector3(Random.Range(xMin,xMax),Random.Range(yMin,yMax),zPlayer), transform.localRotation);

        yield return new WaitForSeconds(timeRandom);

        isTimeRandom = false;


    }
}
