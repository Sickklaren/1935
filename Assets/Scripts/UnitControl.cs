﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnitControl : NetworkBehaviour
{
	[Command]
	public void CmdPinPlaced(GameObject unit, Vector2 pinPos)
	{
		Debug.Log(unit);
		//Unit thisUnit = unit.GetComponent<Unit>();	//Reference to the Unit.cs script attached to the passed in GameObject.
		Debug.Log("Pin has been placed!");
		//thisUnit.isMoving = true;
		//thisUnit.destination = pinPos;
	}

	[Command]
	public void CmdSpawnUnit(string type, Vector2 pos, GameManager.Nation parentNation)
	{
		RpcSpawnUnit(type, pos, parentNation);
	}

	[ClientRpc]
	void RpcSpawnUnit(string type, Vector2 pos, GameManager.Nation parentNation)
	{
		GameObject go = Instantiate(Resources.Load(type, typeof(GameObject)), pos, Quaternion.identity) as GameObject;
		go.GetComponent<Unit>().parentNation = parentNation;
		
		NetworkServer.Spawn(go);
	}
}
