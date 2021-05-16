using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <---- 追加1


public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    float transparency;
    public float duration;
    public int sustain_max;
    int sustain = 0;
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        text = GetComponent<Text>();
        transparency = 255;
    }

    // Update is called once per frame
    void Update()
    {
        sustain++;
        if(sustain_max < sustain){
            // フェードイン
            var color = text.color;
            color.a += duration;
            text.color = color;    
            // if(Input.GetKeyDown(KeyCode.Z)){
            //     Destroy(gameObject);
            // }
        }
    }

}
