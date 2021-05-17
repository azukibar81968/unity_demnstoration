using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnemys : MonoBehaviour
{
    public BombEffect bomb;
    public bool bombEnable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = GetComponent<Collider2D>();
        if(Input.GetKeyDown(KeyCode.Space) && bombEnable == true){
            Instantiate(bomb,transform.position,transform.rotation);
            bombEnable = false;
            DestroyEnemy();
        }
        else{
            col.offset = new Vector2(100,0);
        }

    }

    void OnTriggerStay2D(Collider2D other) {
        Destroy(other.gameObject);
    }   

    public void shotBomb(){
        Collider2D col = GetComponent<Collider2D>();

        Instantiate(bomb,transform.position,transform.rotation);
        for(int i = 0; i<20 ; i++){
            col.offset = new Vector2(0,0);
        }
    }

    void DestroyEnemy(){
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
        // foreachは配列の要素の数だけループします。
        foreach (GameObject cube in enemys) {
            // 消す！
            Destroy(cube);
        }
    }
}
