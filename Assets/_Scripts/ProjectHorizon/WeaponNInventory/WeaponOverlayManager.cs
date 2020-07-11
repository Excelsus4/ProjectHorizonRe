using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.ObserverPattern;

namespace com.meiguofandian.ProjectHorizon.WeaponNInventory {
	public class WeaponOverlayManager : MonoBehaviour, IModIconButtonCallback, IDataUpdateCallback {
		private List<ModIconRenderer> listOfIconRenderers = new List<ModIconRenderer>();
		private UserHandWeaponData GlobalWeaponManager;
		public WeaponInstance WeaponToRender;
		public GameObject m_IconObject;
		public Transform m_IconParent;
		public float m_IconSize;
		public float m_IconGap;
		public StatDisplay[] statDisplays;

		private void Start() {
			GlobalWeaponManager = UserHandWeaponData.getSingleton();
			GlobalWeaponManager.RegisterObserver(this);
		}

		public void Render() {
			UInt32 unlockFlag = (UInt32)WeaponToRender.GetStatus(WeaponMod.Status.Unlocked);
			UInt32 lockFlag = (UInt32)WeaponToRender.GetStatus(WeaponMod.Status.Locked);

			int idx_partFlag = 0;
			int idx_renderer = 0;
			WeaponMod.Status flag_status;

			while (unlockFlag > 0) {
				if (( unlockFlag & 0x1 ) == 0x1) {
					if (( lockFlag & 0x1 ) == 0x1)
						flag_status = WeaponMod.Status.Locked;
					else
						flag_status = WeaponMod.Status.Unlocked;
					if(listOfIconRenderers.Count > idx_renderer) {
						// IconRenderer is left, use whats exist
						AssignIconRenderer(listOfIconRenderers[idx_renderer], 
							flag_status, 
							WeaponToRender.GetModInstance((WeaponMod.ModPart)(0x1 << idx_partFlag)), 
							(WeaponMod.ModPart)( 0x1 << idx_partFlag ));
					} else {
						// Not enough Iconrenderer, create more and assign new
						AssignIconRenderer(CreateNewIcon(idx_renderer), 
							flag_status,
							WeaponToRender.GetModInstance((WeaponMod.ModPart)( 0x1 << idx_partFlag )), 
							(WeaponMod.ModPart)(0x1 << idx_partFlag));
					}
					idx_renderer++;
				}
				idx_partFlag++;
				unlockFlag >>= 1;
				lockFlag >>= 1;
			}

			for (; idx_renderer < listOfIconRenderers.Count;idx_renderer++) {
				// Renderer is left after assigning all unlocks, so disenable renderers
				listOfIconRenderers[idx_renderer].IconAble(false);
				//AssignIconRenderer(listOfIconRenderers[idx_renderer], WeaponMod.Status.Unused, null, 0x0);
			}

			WeaponToRender.weaponStats.DisplayStat(statDisplays);
		}

		private ModIconRenderer CreateNewIcon(int index) {
			Vector3 IconOffset = m_IconParent.position;
			if(index > 0) {
				IconOffset.y = listOfIconRenderers[0].transform.position.y;
			}
			IconOffset.x += index * m_IconGap + m_IconSize;

			ModIconRenderer newRenderer = Instantiate(m_IconObject,IconOffset, Quaternion.identity, m_IconParent).GetComponent<ModIconRenderer>();
			newRenderer.callbackIndex = index;
			listOfIconRenderers.Add(newRenderer);
			return newRenderer;
		}

		private void AssignIconRenderer(ModIconRenderer iconRenderer, WeaponMod.Status status, ModInstance weaponMod, WeaponMod.ModPart part) {
			iconRenderer.IconAble(true);
			iconRenderer.callbackManager = this;
			iconRenderer.target = weaponMod;
			iconRenderer.UpdateImage();
		}

		public void ModIconCallback(int IDX, InventoryItem part) {
			if(part is ModInstance mod) {
				GlobalWeaponManager.RemoveModFromWeapon(mod.m_Reference.m_Mainly);
			} else {
				throw new Exception("Part bound to the icon is not mod");
			}
		}

		public void OnDataUpdate(string data) {
			string[] tokens = data.Split(' ');
			switch (tokens[0]) {
			case "UserHandWeaponData":
				WeaponToRender = GlobalWeaponManager.weapon;
				Render();
				break;
			}
		}
	}
}