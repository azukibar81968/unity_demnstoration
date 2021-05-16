using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer m_SpriteRenderer;
    float transparency;
    public float duration;
    public int sustain_max;
    int sustain = 0;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        transparency = 255;
    }

    // Update is called once per frame
    void Update()
    {
        sustain++;
        if(sustain_max < sustain){
            // フェードアウト
            var color = m_SpriteRenderer.color;
            color.a -= duration;
            m_SpriteRenderer.color = color;    
            if(color.a < duration && !audio.isPlaying){
                Destroy(gameObject);
            }
        }
    }

}
