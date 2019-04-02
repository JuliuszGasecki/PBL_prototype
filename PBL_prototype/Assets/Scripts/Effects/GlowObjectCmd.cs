using UnityEngine;
using System.Collections.Generic;

public class GlowObjectCmd : MonoBehaviour
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

	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
        GlowColor = new Color(150,150,150);
        distanceFromPlayer = 3;
        girl = GameObject.Find("Girl").transform;
        boi = GameObject.Find("Boi").transform;
        Renderers = GetComponentsInChildren<Renderer>();
		GlowController.RegisterObject(this);
    }

    private void checkOutline()
    {
        if (calculateDistanceBetweenPalyerAndObject(boi, this.transform) < distanceFromPlayer || calculateDistanceBetweenPalyerAndObject(girl, this.transform) < distanceFromPlayer)
        {
            Debug.Log("Jest");
            onPlayerIsClose();
        }
        else
        {
            Debug.Log("Nie jest");
            onPlayerIsFar();
        }
    }

    private void onPlayerIsClose()
    {
        _targetColor = GlowColor;
        enabled = true;
    }

    private void onPlayerIsFar()
    {
        _targetColor = Color.black;
        enabled = true;
    }
    private float calculateDistanceBetweenPalyerAndObject(Transform player, Transform obj)
    {
        return Mathf.Sqrt(Mathf.Pow(player.position.x - obj.position.x, 2) + Mathf.Pow(player.position.y - obj.position.y, 2));
    }
    /// <summary>
    /// Update color, disable self if we reach our target color.
    /// </summary>
    private void Update()
	{
        Debug.Log("Lolek wywolanie update");
        checkOutline();
        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		//if (_currentColor.Equals(_targetColor))
		//{
		//	enabled = false;
		//}
	}

    private void OnDestroy()
    {
        GlowController.DegisterObject(this);
    }
}
