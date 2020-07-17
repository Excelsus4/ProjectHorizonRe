using UnityEngine;
using UnityEditor;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;

public class GMWindow : EditorWindow {
	private InventoryItem itemInstance;

	[MenuItem("Tools/ProjectHorizon/GM Debug")]
	public static void ShowWindow() {
		GetWindow<GMWindow>("GM Debug Panel");
	}

	private void OnGUI() {
		// Window Code
		GUILayout.Label("Add Item to inventory", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		itemInstance = (InventoryItem)EditorGUILayout.ObjectField("Item Instance", itemInstance, typeof(InventoryItem), false);
		if(GUILayout.Button("Create")) {
			CreateItemByInstance();
		}
		GUILayout.EndHorizontal();
	}

	private void CreateItemByInstance() {
		InventoryData.getSingleton().AddItemToInventory(new InventoryItem[] { itemInstance });
	}
}
