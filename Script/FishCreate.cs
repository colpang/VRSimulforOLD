using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishCreate : MonoBehaviour
{
    public GameObject enemyObj;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine("Fish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Fish()
    {
        for(;;)
        {
            Instantiate(enemyObj, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
        //yield return new WaitForSeconds(5.0f);
    }
}
