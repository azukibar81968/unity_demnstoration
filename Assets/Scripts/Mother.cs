﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
	// 弾の移動スピード
	public float speed = 10;
	
	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 1000;
	
	// 攻撃力
	public int power = 1;
	
	void Start ()
	{
		// ローカル座標のY軸方向に移動する
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed * -1;
		
		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
}