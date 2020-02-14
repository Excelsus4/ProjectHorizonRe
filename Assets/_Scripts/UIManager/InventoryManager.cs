using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public Text m_PageIdentifier;
	public List<WeaponPart> m_WeaponPartInventory;
	public int m_ItemsPerPage;
	public GameObject m_SimpleInventoryRendererPrefab;
	public ItemInfoManager m_InfoManager;

	private int currentPage;
	private int lastPage;
	private SimpleInventoryRenderer[] m_renderers;
	
	// Use this for initialization
	void Start () {
		m_WeaponPartInventory = new List<WeaponPart>();
		currentPage = 0;
		lastPage = 0;

		m_renderers = new SimpleInventoryRenderer[m_ItemsPerPage];
		for(int idi = 0; idi < m_ItemsPerPage; idi++)
		{
			m_renderers[idi] = Instantiate(m_SimpleInventoryRendererPrefab, transform).GetComponent<SimpleInventoryRenderer>();
			m_renderers[idi].Parent = this;
			m_renderers[idi].RendererCode = idi;
			m_renderers[idi].MovePosition(idi);
			m_renderers[idi].Enable = false;
		}

		UpdatePage();
	}
	
	void AddWeaponPart(WeaponPart thisPart)
	{
		m_WeaponPartInventory.Add(thisPart);
		lastPage = (m_WeaponPartInventory.Count-1) / m_ItemsPerPage;
		UpdatePage();
	}

	public void UpdatePage()
	{
		for(int idi = currentPage*m_ItemsPerPage; idi < (currentPage+1)*m_ItemsPerPage; idi++)
		{
			if(idi < m_WeaponPartInventory.Count)
			{
				m_renderers[idi - currentPage * m_ItemsPerPage].Enable = true;
				m_renderers[idi - currentPage * m_ItemsPerPage].ChangeState(
					m_WeaponPartInventory[idi].P_PartGrade,
					m_WeaponPartInventory[idi].P_PartType,
					m_WeaponPartInventory[idi].P_SpriteIndex,
					m_WeaponPartInventory[idi].P_Name);
			}
			else
			{
				m_renderers[idi - currentPage * m_ItemsPerPage].Enable = false;
			}
		}
		m_PageIdentifier.text = (currentPage+1).ToString() + " / " + (lastPage+1).ToString();
	}

	public void NextPage()
	{
		currentPage++;
		if (currentPage > lastPage)
			currentPage = lastPage;
		UpdatePage();
	}

	public void PrevPage()
	{
		currentPage--;
		if (currentPage < 0)
			currentPage = 0;
		UpdatePage();
	}

	public void CallbackInventory(int RendererCode)
	{
		m_InfoManager.DisplayThisItem(m_WeaponPartInventory[currentPage * m_ItemsPerPage + RendererCode]);
	}
}
