using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Norakyo.Internal
{
	internal sealed class RewiredConstantsCreator : EditorWindow
	{
		Rewired.InputManager inputManager;
		[MenuItem("Tools/Yasukou/Constants")]
		static void Open()
		{
			EditorWindow.GetWindow<RewiredConstantsCreator>("RewiredConstantsCreator");
		}

		private void OnGUI()
		{
			inputManager = (Rewired.InputManager)EditorGUILayout.ObjectField("ObjectField", inputManager, typeof(Rewired.InputManager), true);
			if (GUILayout.Button("Create") && inputManager != null)
			{
				var userData = inputManager.userData;
				Dictionary<string, int> actionDic = new Dictionary<string, int>();
				foreach (var id in userData.GetActionIds())
				{
					actionDic[userData.GetActionNameById(id)] = id;
				}
				ConstantsClassCreator.Create("ActionID", "Rewiredのアクション番号を定数で管理するクラス", actionDic);
			}
		}
	}
}

