using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject target; //カメラの注視点

    float angleUp = 30f;
    float angleDown = -30f;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //マウスの移動量を取得
        float vertical = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Mouse X");

        //特定のオブジェクトの周りを回らせる
        transform.RotateAround(this.target.transform.position, Vector3.up, -horizontal);
        transform.RotateAround(this.target.transform.position, Vector3.right, -vertical);

        //カメラの位置調整 ターゲットからカメラの方向に５ｍ離れた位置
        transform.position = this.target.transform.position - transform.forward * 5f;

        //ターゲットの方にカメラを向ける
        transform.LookAt(this.target.transform);

        float angleX = transform.eulerAngles.x;
        if(angleX>=180)
        {
            angleX = angleX - 360;
        }

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
    }
}
