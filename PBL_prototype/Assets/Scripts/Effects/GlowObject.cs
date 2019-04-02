using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;
    public float distanceFromPlayer;

    Transform girl;
    Transform boi;

	public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private List<Material> _materials = new List<Material>();
	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
        girl = GameObject.Find("Girl").transform;
        boi = GameObject.Find("Boi").transform;

		Renderers = GetComponentsInChildren<Renderer>();

		foreach (var renderer in Renderers)
		{	
			_materials.AddRange(renderer.materials);
		}
	}

	private void onPlayerIsClose()
	{
        if(calculateDistanceBetweenPalyerAndObject(boi, this.transform) < 25 || calculateDistanceBetweenPalyerAndObject(girl, this.transform) < 25)
        {
		    _targetColor = GlowColor;
		    enabled = true;
        }

	}

	private void onPlayerIsFar()
	{
        if (calculateDistanceBetweenPalyerAndObject(boi, this.transform) >= 25 && calculateDistanceBetweenPalyerAndObject(girl, this.transform) >= 25)
        {
            _targetColor = Color.black;
		    enabled = true;
        }

	}

    private float calculateDistanceBetweenPalyerAndObject(Transform player, Transform obj)
    {
        return Mathf.Pow(player.position.x - obj.position.x, 2) + Mathf.Pow(player.position.y - obj.position.y, 2);
    }

	/// <summary>
	/// Loop over all cached materials and update their color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
        onPlayerIsClose();
        onPlayerIsFar();
        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		for (int i = 0; i < _materials.Count; i++)
		{
			_materials[i].SetColor("_GlowColor", _currentColor);
		}

		if (_currentColor.Equals(_targetColor))
		{
			enabled = false;
		}
	}
}
