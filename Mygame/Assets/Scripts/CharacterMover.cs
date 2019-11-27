using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField]
    float accel = 1f;        //加速度

    [SerializeField]
    float maxSpeed = 2f;   //最高速

    [SerializeField]
    float maxSteering = 90f;   //ハンドリング性能

    float speed = 0;        //現在の速度
    float steering = 0f;    //現在の回転角

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        transform.Translate(0, 0, this.speed * Time.deltaTime);

        //回転処理
        transform.Rotate(0, this.steering * Time.deltaTime, 0);

        //減速処理
        if (this.speed > 0)
        {
            this.speed -= this.accel * 0.5f * Time.deltaTime;
            if (this.speed < 0)
            {
                this.speed = 0;
            }
        }
        else if (this.speed < 0)
        {
            this.speed += this.accel * 0.5f * Time.deltaTime;
            if (this.speed > 0)
            {
                this.speed = 0;
            }
        }

    }

    /// <summary>
    /// 移動処理　valueには－１から１の値を渡すこと
    /// </summary>
    /// <param name="value"></param>
    public void Move(float value)
    {
        //valueの値の範囲がー１から１を超えないように、下限上限を設定
        value = Mathf.Clamp(value, -1, 1);

        this.speed += value * Time.deltaTime;
        //上限下限を設定　Mathf.Clamp(対象の値、最小値、最大値);
        this.speed = Mathf.Clamp(this.speed, -this.maxSpeed, this.maxSpeed);
    }

    /// <summary>
    /// 回転処理　valueには－１から１の値を渡すこと
    /// </summary>
    /// <param name="value"></param>
    public void Steering(float value)
    {
        //valueの値の範囲がー１から１を超えないように、下限上限を設定
        value = Mathf.Clamp(value, -1, 1);

        this.steering = value * this.maxSteering;
    }

    /// <summary>
    /// 現在の速度を取得
    /// </summary>
    /// <returns></returns>
    public float Speed()
    {
        return this.speed;
    }
}

