using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public Enemy enemy;
    public float shotDelay;
    IEnumerator Start()
    {   
        Debug.Log("enemy: start");
		while (true) {
			Debug.Log("shooting");
				// ShotPositionの位置/角度で弾を撃つ
            Shot (enemy);
			
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
        Instantiate (enemy, transform.position, transform.rotation);
    }
}
