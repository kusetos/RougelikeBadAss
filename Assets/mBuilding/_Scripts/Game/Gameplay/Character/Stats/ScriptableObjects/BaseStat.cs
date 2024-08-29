using System;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[System.Serializable]
public class BaseStat : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;
    [SerializeField] private string _name;
    [SerializeField] private float _value;
    [SerializeField] private int _costToUpgrade;
    [SerializeField] private int _index;

    public bool IsPercent = false;
    public int Index => _index;
    public virtual float Value => _value;
    public string Description => _description;
    public string Name => _name;
    public Sprite Icon => _icon;
    public int CostToUpgrade => _costToUpgrade;

    private void OnValidate()
    {

        if(Description != "") return;
        if(Name == "") _name = name; //file name
        GenerateDescription();
    }

    private void GenerateDescription()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{Name} increases up-to {Value}");
        _description = sb.ToString();
    }
}