using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitCaster : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_click;
    [SerializeField] private TextMeshProUGUI text_hit;
    [SerializeField] private TextMeshProUGUI text_invalid;
    [SerializeField] private TextMeshProUGUI text_hitRate;

    public int click = 0;
    public int hit = 0;
    public int invalid = 0;
    public float hitRate = 1;

    public Action OnClicked;

    private void Awake()
    {
        OnClicked += OnClick;
    }

    private void OnClick()
    {
        hitRate = (float)hit / (float)click * 100f;

        text_click.text = $"Total Click : {click}";
        text_hit.text = $"Hit : {hit}";
        text_invalid.text = $"Invalid : {invalid}";
        text_hitRate.text = $"HitRate : {hitRate}";
    }


    private void OnDestroy()
    {
        OnClicked -= OnClicked;
    }

    public void ClickEvent(bool is_valid)
    {
        click++;
        if (is_valid) hit++;
        else invalid++;

        OnClicked?.Invoke();
    }

}
