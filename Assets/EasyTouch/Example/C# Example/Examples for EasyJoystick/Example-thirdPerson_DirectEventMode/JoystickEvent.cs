using UnityEngine;
using System.Collections;

/// <summary>
/// Joystick event
/// </summary>
public class JoystickEvent : MonoBehaviour {

    private Animation m_Animation;

    void Start ( ) {
        m_Animation = GetComponent<Animation>( );
    }

	void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove	;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
		
	void OnDestroy(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
	
	
	void On_JoystickMoveEnd(MovingJoystick move){
		if (move.joystickName == "Move_Turn_Joystick"){
			GetComponent<Animation>().CrossFade("idle");
		}
	}
	void On_JoystickMove( MovingJoystick move){
		if ("Move_Turn_Joystick" == move.joystickName == ){			
			//
			if (Mathf.Abs(move.joystickAxis.y)>0 && Mathf.Abs(move.joystickAxis.y)<0.5){
                m_Animation.CrossFade("walk");				
			}	
			else if (Mathf.Abs(move.joystickAxis.y)>=0.5){
                m_Animation.CrossFade("run");	
			}
		}
	}

}
