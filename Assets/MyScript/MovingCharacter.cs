using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{
    private CharacterController m_CharacterController;
    private QuerySDMecanimController m_MecanimController;
    private float walkSpeed = 0.2f;
 
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_MecanimController = GetComponent<QuerySDMecanimController>();
    }

    void Update()
    {
        //キャラクターの前方を移動方向とする
        Vector3 moveDirection = transform.forward * walkSpeed * Time.deltaTime;

        //移動した先を basePoint として平面があるか判定する
        Vector3 basePoint = m_CharacterController.center + moveDirection;

        //Ratcast を行う距離
        RaycastHit hitInfo;
        float distance = m_CharacterController.height;

        //キャラクターの下方向に Raycast を行い、平面があるかを確認する
        if (Physics.Raycast (basePoint, -transform.up, out hitInfo, distance))
        {
            //平面があれば、前方への移動+等速落下
            moveDirection += -transform.up * 0.98f * Time.deltaTime;
            m_CharacterController.Move(moveDirection);
            //歩行モーションに変更
            m_MecanimController.ChangeAnimation(
                QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_WALK
                );
        }
        else
        {
            //平面がなければ、等速落下のみ
            moveDirection = -transform.up * 0.98f * Time.deltaTime;
            m_CharacterController.Move(moveDirection);
            //待機モーションに変更
            m_MecanimController.ChangeAnimation(
                QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_IDLE
                );
            //方向転換
            transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        }
    }
}
