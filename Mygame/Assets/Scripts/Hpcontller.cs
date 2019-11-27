using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpcontller : MonoBehaviour
{
    public float hp = 100;
    public float MaxHP = 100;


    RectTransform HP;


    // Start is called before the first frame update
    void Start()
    {
        this.HP = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            hp = 0;
        }
        this.HP.localScale = new Vector3((hp / MaxHP), 1f, 1f);

    }
}
