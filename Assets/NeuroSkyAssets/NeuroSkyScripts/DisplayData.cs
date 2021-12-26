using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

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

	public GameObject player;
	public GameObject[] targets;
	public GameObject target;

	public int ad = 20;
	public int md = 80;

    void Start()
    {
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdateBlinkEvent += OnUpdateBlink;

		controller.UpdateDeltaEvent += OnUpdateDelta;
		controller.Disconnect();
		indexSignalIcons = 1;
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
			if(attention1 >= ad && meditation1 < md)
			{
				target.SendMessage("attention", 1000);
			} else if(attention1 >= ad && meditation1 >= md)
			{
				target.SendMessage("attention", 1001);
			}
        }
		
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
		if (target != null)
		{
			if (attention1 < ad && meditation1 >= md)
			{
				target.SendMessage("meditation", 1002);
			}
			else if (attention1 < ad && meditation1 < md)
			{
				target.SendMessage("meditation", 1003);
			}
		}
	}
	void OnUpdateDelta(float value){
		delta = value;
	}
	void OnUpdateBlink(int value)
    {
		blink = value;
		//플레이어에게 가까이 있는 오브젝트 선택
		if(blink > 60)
        {
			target = GetNearestGameObject(player, targets);
        }
		
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

		if (Input.GetKeyDown(KeyCode.Z))
		{
			controller.Connect();
		}
		if (Input.GetKeyUp(KeyCode.Z))
		{
			controller.Disconnect();
			indexSignalIcons = 1;
		}

		GUILayout.Space(Screen.width - 250);
		GUILayout.Label(signalIcons[indexSignalIcons]);

		GUILayout.EndHorizontal();


		GUILayout.Label("PoorSignal1:" + poorSignal1);
		GUILayout.Label("Attention1:" + attention1);
		GUILayout.Label("Meditation1:" + meditation1);
		GUILayout.Label("Delta:" + delta);
		GUILayout.Label("Blink: " + blink);

	}

	GameObject GetNearestGameObject(GameObject Source, GameObject[] DestObjects)
    {
		GameObject Nearest = DestObjects[0];

		float ShortestDistance = Vector3.Distance(Source.transform.position, DestObjects[0].transform.position);
		int i = 0;
		foreach(GameObject obj in DestObjects)
        {
			float Distance = Vector3.Distance(Source.transform.position, obj.transform.position);
			Debug.Log ("obj["+i+"]"+Distance);
			if(Distance < ShortestDistance)
            {
				Nearest = obj;
				ShortestDistance = Distance;
            }
			i++;
		}
		return Nearest;
    }
}
