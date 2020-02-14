using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	public static ResourceManager resourceManager;
	public UnityEngine.UI.Text[] amountText = new UnityEngine.UI.Text[CharacterData.ResourceTypeLength];

	private void Awake()
	{
		resourceManager = this;
		for(int idi = 0; idi < CharacterData.ResourceTypeLength; idi++)
		{
			UpdateResourceAmount((CharacterData.ResourceType)idi);
		}
	}

	public void UpdateResourceAmount(CharacterData.ResourceType thisType)
	{
		amountText[(int)thisType].text = "";
		int TempWhole = CharacterData.Resource[(int)thisType];
		int TempLast = CharacterData.Resource[(int)thisType] % 10;
		amountText[(int)thisType].text = "." + TempLast + "0";
		TempWhole = (TempWhole - TempLast) / 10;
		if (TempWhole < 1)
			amountText[(int)thisType].text = "0" + amountText[(int)thisType].text;
		else
		{
			TempLast = TempWhole % 1000;
			amountText[(int)thisType].text = TempLast + amountText[(int)thisType].text;
			TempWhole = (TempWhole - TempLast) / 1000;

			while (TempWhole > 0)
			{
				TempLast = TempWhole % 1000;
				amountText[(int)thisType].text = TempLast + "," + amountText[(int)thisType].text;
				TempWhole = (TempWhole - TempLast) / 1000;
			}
		}
	}
}
