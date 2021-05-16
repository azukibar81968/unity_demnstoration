using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject ending;
    // Start is called before the first frame update
    void Start ()
    {
    }

    // Update is called once per frame
	void Update ()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");
		
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// 移動の制限
		Move (direction);
		
	}
	
	// 機体の移動
	void Move (Vector2 direction)
	{
        float slowRate = 1.0f;
        if(Input.GetKey(KeyCode.LeftShift)){
            slowRate = 2.5f;
        }else{
            slowRate = 1.0f;
        }
		// 画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		// プレイヤーの座標を取得
		Vector2 pos = transform.position;
		
		// 移動量を加える
		pos += direction  * speed * Time.deltaTime / slowRate;
		
		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}
	
	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		// レイヤー名がEnemyの場合は爆発
		if( layerName == "Enemy")
		{
			// プレイヤーを削除
			Destroy (gameObject);
		}
        if( layerName == "Mother"){
            DeleteEnemys bomb = GameObject.FindObjectOfType<DeleteEnemys> ();
            bomb.shotBomb();
            Instantiate(ending,transform.position, transform.rotation);
        }
	}

    private void OnDestroy() {
        DeleteEnemys bomb = GameObject.FindObjectOfType<DeleteEnemys> ();
        bomb.shotBomb();
    }
}
