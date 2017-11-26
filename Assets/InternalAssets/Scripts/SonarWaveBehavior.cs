using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarWaveBehavior : MonoBehaviour
{
    [SerializeField] private Color castColor;
    [SerializeField] private float castTtl; // TimeToLive
    [SerializeField] private float castSpeed;

    private Renderer rend;
    private float ttl;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale += new Vector3(1, 1, 0) * Time.deltaTime * castSpeed;

        ttl -= Time.deltaTime;
        if(ttl <= 0)
            Destroy(gameObject);
	}

    public void SetCastColor(Color castColor_)
    {
        castColor = castColor_;
        if (rend == null)
            rend = GetComponent<Renderer>();
        rend.material.color = castColor;
    }

    public void SetCastTtl(float castTtl_)
    {
        castTtl = castTtl_;
        ttl = castTtl;
    }

    public void SetcastSpeed(float castSpeed_)
    {
        castSpeed = castSpeed_;
    }
}
