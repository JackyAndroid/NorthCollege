
using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
public class MoveController : MonoBehaviour {
	
	void OnEnable()
	{
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
	}
	
	
	//移动摇杆结束
	void OnJoystickMoveEnd(MovingJoystick move)
	{
		//停止时，角色恢复idle
		if (move.joystickName == "MoveJoystick")
		{
			animation.CrossFade("idle");
		}
	}
	
	
	//移动摇杆中
	void OnJoystickMove(MovingJoystick move)
	{
		if (move.joystickName != "MoveJoystick")
		{
			return;
		}
		
		//获取摇杆中心偏移的坐标
		float joyPositionX = move.joystickAxis.x;
		float joyPositionY = move.joystickAxis.y;
		
		
		if (joyPositionY != 0 || joyPositionX != 0)
		{
			//设置角色的朝向（朝向当前坐标+摇杆偏移量）
			transform.LookAt(new Vector3(transform.position.x - joyPositionX,transform.position.y,transform.position.z -joyPositionY));
			//移动玩家的位置（按朝向位置移动）
		//	transform.Translate(Vector3.forward * Time.deltaTime * 5);

			Vector3 dir = new Vector3(joyPositionX,0,joyPositionY);
			CharacterController c = (CharacterController)this.transform.GetComponent<CharacterController>();

			c.Move(dir* Time.deltaTime * -5);
			//播放奔跑动画
			animation.CrossFade("walk");
		}

	}
}