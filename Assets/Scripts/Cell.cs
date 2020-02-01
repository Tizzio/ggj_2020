﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour {
	private float temperature;
	private float waterLevel;

	private CellEvent currentEvent;

	public float Temperature {
		get { return this.temperature; }
		set { this.temperature = Mathf.Min(0, Mathf.Max(this.temperature + value, 100)); }
	}

	public float WaterLevel {
		get { return this.waterLevel; }
		set { this.waterLevel = Mathf.Min(0, Mathf.Max(this.waterLevel + value, 100)); }
	}

	void Start() {
		GameObject coll = new GameObject("coll");
		coll.transform.position = transform.position;
		CapsuleCollider c = coll.AddComponent<CapsuleCollider>();
		c.radius = 3;
		c.height = 15;
		c.isTrigger = true;
		MAIN.Orient(coll.transform);
		coll.transform.SetParent(transform);
	}

	void Update() {
		if (this.currentEvent != null) {
			this.currentEvent.Update();

			if (this.currentEvent.isOver()) {
				this.currentEvent = null;
			}
		}
	}

	public void SetCellEvent(CellEvent cellEvent) {
		this.currentEvent = cellEvent;
		this.currentEvent.Start();
	}

	public void Hit(string weaponName)
	{

	}

}
