using UnityEngine;
using System.Collections;

public class AmbientLight : MonoBehaviour {

	public Color[] colors = {new Color32(0xFC, 0xD8, 0x84, 0xFF), new Color32(0x00, 0x40, 0x58, 0xFF)};
	public float transition;

	void Update () {

//		float transistion = Mathf.PingPong(Time.time * 0.01f, 1.2f); // 120 seconds!
		transition = Mathf.PingPong(Time.time * 0.02f, 1.2f); // 60 seconds!

		//transition == 0.6 at sunrise
		//transition == 0.0 at noon
		//transition == 0.6 at sunset
		//transition == 1.2 at midnight

		RenderSettings.ambientLight = Color.Lerp(colors[0], colors[0 + 1], transition);
	}
}