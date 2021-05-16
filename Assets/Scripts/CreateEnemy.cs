using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int shootFrequency;
    public Enemy enemy;
    public float shotDelay;
    IEnumerator Start()
    {   
		while (true) {
				// ShotPositionの位置/角度で弾を撃つ
            for(int i = 0; i < shootFrequency; i++){
                Shot (enemy);   
            }		
			// shotDelay秒待つ
			yield return new WaitForSeconds (shotDelay);
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 弾の作成
    public void Shot (Enemy enemy)
    {
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-30.0f, 30.0f);
        Vector3 randomPosition = new Vector3(x,10.0f,0);
        Vector3 randomRotation = new Vector3(0,0,z);

        Instantiate (enemy, randomPosition,  Quaternion.Euler(0.0f, 0.0f, Random.Range(-30.0f, 30.0f)));
    }
}
