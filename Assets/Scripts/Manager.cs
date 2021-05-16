using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Playerプレハブ
    public GameObject player;
    public GameObject progresserAssets;
    public GameObject progresser;

    // タイトル
    private GameObject title;
    private bool isInGame = false;

    void Start ()
    {
        // Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find ("Title");
    }

    void Update ()
    {
        // ゲーム中ではなく、Xキーが押されたらtrueを返す。
        if (IsPlaying () == false && Input.GetKeyDown (KeyCode.Z)) {
            GameStart ();
            isInGame = true;
        }

        if(isInGame){
            if (GameObject.FindGameObjectsWithTag ("player").Length == 0){
                GameOver();
                isInGame = false;
            }
        }
    }

    void GameStart ()
    {
        // ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
        title.SetActive (false);
        Instantiate (player, player.transform.position, player.transform.rotation);
        progresser = Instantiate (progresserAssets, transform.position, transform.rotation);
    }

    public void GameOver ()
    {
        // ゲームオーバー時に、タイトルを表示する
        title.SetActive (true);
        // GameObject型の配列cubesに、"enemy"タグのついたオブジェクトをすべて格納
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
        // foreachは配列の要素の数だけループします。
        foreach (GameObject cube in enemys) {
            // 消す！
            Destroy(cube);
        }
        Destroy(progresser);
    }

    public bool IsPlaying ()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        return title.activeSelf == false;
    }
}