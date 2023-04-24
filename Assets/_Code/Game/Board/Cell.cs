using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Game.Block;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private BlockItem _blockItem;
    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    public void PrepareCell(Vector2 pos)
    {
        transform.position = pos;
        UpdateCordText(pos);
    }

    private void UpdateCordText(Vector2 pos)
    {
        _textMeshPro.text = pos.x+ "," + pos.y;
    }
}