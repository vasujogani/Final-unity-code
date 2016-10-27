using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeGun 
{
	[MenuItem("Assets/Create/Gun")]
	public static void Create()
	{
		Gun asset = ScriptableObject.CreateInstance<Gun> ();
		AssetDatabase.CreateAsset (asset, "Assets/NewGun.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

}