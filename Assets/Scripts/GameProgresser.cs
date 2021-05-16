using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgresser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waves;
    public GameObject enemyCreater;
    public GameObject mother;
    public GameObject motherInstance;
    public int phase = 0;
    public float phaseTime = 10.0f;
    IEnumerator Start()
    {   

        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield return new WaitForSeconds(phaseTime);

        Destroy(enemyCreater);
        phase++;
        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield return new WaitForSeconds(phaseTime);

        Destroy(enemyCreater);
        phase++;
        enemyCreater = Instantiate(waves[phase], transform.position, transform.rotation);
        yield return new WaitForSeconds(phaseTime);

        Destroy(enemyCreater);
        motherInstance = Instantiate(mother, new Vector3(0,35,0), Quaternion.Euler(0.0f, 0.0f,0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy() {
        Destroy(enemyCreater);
    }
}
