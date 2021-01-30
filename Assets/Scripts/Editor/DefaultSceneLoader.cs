#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
/// Source: https://stackoverflow.com/questions/35586103/unity3d-load-a-specific-scene-on-play-mode
public static class DefaultSceneLoader {
	static DefaultSceneLoader() {
		EditorApplication.playModeStateChanged += LoadDefaultScene;
	}

	static void LoadDefaultScene(PlayModeStateChange state) {
		if (state == PlayModeStateChange.ExitingEditMode) {
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}

		if (state == PlayModeStateChange.EnteredPlayMode) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}
}
#endif