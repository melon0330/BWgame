using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private int indexSignalIcons = 1;
	
    TGCConnectionController controller;

    private int poorSignal1;
    private int attention1;
    private int meditation1;
	private int blink;
	
	private float delta;

	private GameObject target;

    void Start()
    {
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdateBlinkEvent += OnUpdateBlink;

		controller.UpdateDeltaEvent += OnUpdateDelta;
		
    }
	
	void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
      		indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
      		indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
      		indexSignalIcons = 2;
		}else if(value >= 107){
      		indexSignalIcons = 1;
		}
	}
	void OnUpdateAttention(int value){
		attention1 = value;
        if (target != null)
        {
			if(attention1 >= 50 && meditation1 < 50)
			{
				target.SendMessage("attention", 1000);
			} else if(attention1 >= 50 && meditation1 >= 50)
			{
				target.SendMessage("attention", 1001);
			}
        }
		
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
		if (target != null)
		{
			if (attention1 < 50 && meditation1 >= 50)
			{
				target.SendMessage("meditation", 1002);
			}
			else if (attention1 < 50 && meditation1 < 50)
			{
				target.SendMessage("meditation", 1003);
			}
		}
	}
	void OnUpdateDelta(float value){
		delta = value;
		//플레이어에게 가까이 있는 오브젝트 선택
	}
	void OnUpdateBlink(int value)
    {
		blink = value;
    }


    void OnGUI()
    {
		GUILayout.BeginHorizontal();
		
		
        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("DisConnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();

		
        GUILayout.Label("PoorSignal1:" + poorSignal1);
        GUILayout.Label("Attention1:" + attention1);
        GUILayout.Label("Meditation1:" + meditation1);
		GUILayout.Label("Delta:" + delta);
		GUILayout.Label("Blink: " + blink);

    }
}
