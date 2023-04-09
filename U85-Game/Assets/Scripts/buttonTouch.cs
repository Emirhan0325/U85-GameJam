using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation _anim;
    void Start()
    {
        _anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    public void button_touch()
    {
        _anim.Play("New_Animation");
    }
}
