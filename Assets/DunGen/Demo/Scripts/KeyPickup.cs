using DunGen;
using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour, IKeyLock
{
	public Key Key { get { return keyManager.GetKeyByID(keyID); } }

	[HideInInspector]
	[SerializeField]
	private int keyID;

	[HideInInspector]
	[SerializeField]
	private KeyManager keyManager;


	public void OnKeyAssigned(Key key, KeyManager keyManager)
	{
		keyID = key.ID;
		this.keyManager = keyManager;
	}

	private void OnTriggerEnter(Collider c)
	{
		//origin
//		var inventory = c.GetComponent<PlayerInventory>();
//
//		if(inventory == null)
//			return;
//
//		ScreenText.Log("Picked up {0} key", Key.Name);
//		inventory.AddKey(keyID);
//		UnityUtil.Destroy(gameObject);

		//new
		Pathea.MainPlayerCmpt playerCmpt = c.GetComponentInParent<Pathea.MainPlayerCmpt>();
		
		// Ignore overlaps with anything other than the player
		if (playerCmpt == null)
			return;
		RandomDungenMgr.Instance.PickUpKey(keyID);
		ScreenText.Log("Picked up {0} key", Key.Name);
		UnityUtil.Destroy(gameObject);
	}
}
