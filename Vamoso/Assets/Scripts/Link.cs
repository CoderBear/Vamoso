﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

	public float borderWidth = 0.02f;

	public float lineThickness = 0.5f;

	public float scaleTime = 0.25f;

	public float delay = 0.1f;

	public iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

	void Start()
	{
		DrawLink (new Vector3(4f, 0f, 4f), new Vector3(4f, 0f, 2f));
	}

	public void DrawLink(Vector3 startPos, Vector3 endPos)
	{
		transform.localScale = new Vector3 (lineThickness, 1f, 0f);

		Vector3 dirVector = endPos - startPos;

		float zScale = dirVector.magnitude - borderWidth * 2f;

		Vector3 newScale = new Vector3 (lineThickness, 1f, zScale);

		transform.rotation = Quaternion.LookRotation (dirVector);

		transform.position = startPos + (transform.forward * borderWidth);

		iTween.ScaleTo (gameObject, iTween.Hash (
			"time", scaleTime,
			"scale", newScale,
			"easeType", easeType,
			"delay", delay
		));
	}
}
