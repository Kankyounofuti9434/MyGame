using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    CharacterMover CharacterMover;
    InputController inputController;
    Animator animator;

    GameObject tama;
    GameObject tamaPlefab;

    // Start is called before the first frame update
    void Start()
    {
        this.CharacterMover = GetComponent<CharacterMover>();
        this.inputController = GetComponent<InputController>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.CharacterMover.Move(this.inputController.Move());
        this.CharacterMover.Steering(this.inputController.Steering());

        //アニメーターのパラメータにを設定
        this.animator.SetFloat("Speed", Mathf.Abs(this.CharacterMover.Speed()));
        //アニメーション速度を変更
        this.animator.speed = Mathf.Abs(this.CharacterMover.Speed() * 0.5f);
        //アイドル時のアニメーション速度対応が必要

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            animator.SetTrigger("JYouka");
        }

        
    }
}
