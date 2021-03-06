﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildOnTile : MonoBehaviour
{
	public Tilemap Map;
	public GameEvent SelectBuildTileEvent;
	public GameEvent UpdateUIEvent;

	private Camera _mainCamera;
	private static Plane _zPlane = new Plane(Vector3.forward, 0);

	public TileBase SelectedTile { get; private set; }

	private void Start()
	{
		_mainCamera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && SelectedTile)
		{
			Ray mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
			if (!_zPlane.Raycast(mouseRay, out float distance))
			{
				Debug.LogError("Failed to raycast onto Z plane.");
				return;
			}

			Vector3Int tilePosition = Map.WorldToCell(mouseRay.GetPoint(distance));
			// TODO Implement better placement logic
			if (Map.HasTile(tilePosition))
			{
				Map.SetTile(tilePosition, SelectedTile);
				UpdateUIEvent.Raise();
			}
		}
	}

	public void SelectBuildTile(TileBase tile)
	{
		SelectedTile = tile;
		SelectBuildTileEvent.Raise();
	}
}