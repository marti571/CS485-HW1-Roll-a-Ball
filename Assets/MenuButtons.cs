using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public int buttonWidth;
	public int buttonHeight;
	private int origin_x;
	private int origin_y;
	public string scene;

	// Use this for initialization
	void Start () {
		
		buttonWidth = 200;
		buttonHeight = 50;
		origin_x = Screen.width / 2 - buttonWidth / 2;
		origin_y = Screen.height / 2 - buttonHeight * 2;
	}
	
	void OnGUI() {
		if(GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Level 1")) {
			scene = "minigame";
			SceneManager.LoadScene (scene+"");
		}
		if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight + 10, buttonWidth, buttonHeight), "Level 2 TBA")) {
			scene = "minigame";
			SceneManager.LoadScene (scene+"");
		}
		if(GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 2 + 20, buttonWidth, buttonHeight), "Exit")) {
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}
}