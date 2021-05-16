using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgresser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waves;
    public GameObject enemyCreater;
    public int phase = 0;
    IEnumerator Start()
    {   

        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield return new WaitForSeconds(50f);

        Destroy(enemyCreater);
        phase++;
        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield return new WaitForSeconds(50f);

        Destroy(enemyCreater);
        phase++;
        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy() {
        Destroy(enemyCreater);
    }
}
