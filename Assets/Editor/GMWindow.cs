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
		GUILayout.Label("Adding Item to inventory", EditorStyles.boldLabel);
		itemInstance = (InventoryItem)EditorGUILayout.ObjectField("Item Instance", itemInstance, typeof(InventoryItem), false);
		if(GUILayout.Button("Create Item by Item Instance")) {
			CreateItem();
		}
	}

	private void CreateItem() {
		InventoryData.getSingleton().AddItemToInventory(new InventoryItem[] { itemInstance });
	}
}
