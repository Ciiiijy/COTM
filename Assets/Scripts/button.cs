using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// 全局 Button 点击覆盖层效果管理器
/// </summary>
public class ButtonClickOverlayEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Header("覆盖层设置")]
    [SerializeField] private Color overlayColor = new Color(1f, 1f, 1f, 0.5f); // 白色半透明
    [SerializeField] private float fadeInDuration = 0.4f;    // 淡入时间
    [SerializeField] private float fadeOutDuration = 0.3f;   // 淡出时间
    [SerializeField] private Ease fadeInEase = Ease.OutSine;
    [SerializeField] private Ease fadeOutEase = Ease.OutSine;

    [Header("缩放效果（可选）")]
    [SerializeField] private bool enableScaleEffect = true;
    [SerializeField] private float clickScale = 0.95f;      // 点击时缩放
    [SerializeField] private float scaleDuration = 0.1f;

    // 组件引用
    private Button button;
    private Image overlayImage;
    private GameObject overlayObject;
    private Vector3 originalScale;

    // 状态跟踪
    private bool isPointerDown = false;
    private bool isPointerOver = false;

    void Start()
    {
        InitializeComponents();
        CreateOverlayImage();
    }

    private void InitializeComponents()
    {
        // 获取 Button 组件
        button = GetComponent<Button>();
        originalScale = transform.localScale;
    }

    private void CreateOverlayImage()
    {
        // 创建覆盖层 GameObject
        overlayObject = new GameObject("ButtonOverlay");
        overlayObject.transform.SetParent(transform, false);
        overlayObject.transform.SetAsLastSibling(); // 确保在最上层

        // 设置 RectTransform
        RectTransform overlayRect = overlayObject.AddComponent<RectTransform>();
        overlayRect.anchorMin = Vector2.zero;
        overlayRect.anchorMax = Vector2.one;
        overlayRect.sizeDelta = Vector2.zero;
        overlayRect.anchoredPosition = Vector2.zero;

        // 添加 Image 组件
        overlayImage = overlayObject.AddComponent<Image>();
        overlayImage.color = new Color(overlayColor.r, overlayColor.g, overlayColor.b, 0f); // 初始透明
        overlayImage.raycastTarget = false; // 防止阻挡点击

        // 使用 Button 的 sprite（如果有）
        if (button.image != null)
        {
            overlayImage.sprite = button.image.sprite;
            overlayImage.type = button.image.type;
            overlayImage.preserveAspect = button.image.preserveAspect;
        }

        // 隐藏初始状态
        overlayObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button != null && !button.interactable) return;

        isPointerDown = true;

        // 显示覆盖层
        ShowOverlay();

        // 可选缩放效果
        if (enableScaleEffect)
        {
            transform.DOKill();
            transform.DOScale(originalScale * clickScale, scaleDuration)
                .SetEase(fadeInEase);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (button != null && !button.interactable) return;

        isPointerDown = false;

        // 隐藏覆盖层（如果不是悬停状态）
        if (!isPointerOver)
        {
            HideOverlay();
        }

        // 恢复缩放
        if (enableScaleEffect)
        {
            transform.DOKill();
            transform.DOScale(originalScale, scaleDuration)
                .SetEase(fadeOutEase);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        // 如果已经松开鼠标，立即隐藏覆盖层
        if (!isPointerDown)
        {
            HideOverlay();
        }
    }

    // 鼠标进入（通过 EventTrigger 添加）
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    private void ShowOverlay()
    {
        if (overlayObject == null || overlayImage == null) return;

        overlayObject.SetActive(true);
        overlayImage.DOKill();
        overlayImage.DOColor(overlayColor, fadeInDuration)
            .SetEase(fadeInEase);
    }

    private void HideOverlay()
    {
        if (overlayObject == null || overlayImage == null) return;

        overlayImage.DOKill();
        overlayImage.DOColor(new Color(overlayColor.r, overlayColor.g, overlayColor.b, 0f), fadeOutDuration)
            .SetEase(fadeOutEase)
            .OnComplete(() => {
                if (overlayObject != null)
                    overlayObject.SetActive(false);
            });
    }

    // 动态更新覆盖层颜色
    public void SetOverlayColor(Color newColor)
    {
        overlayColor = newColor;
        if (isPointerDown && overlayImage != null)
        {
            overlayImage.color = overlayColor;
        }
    }

    // 清理资源
    void OnDestroy()
    {
        if (overlayObject != null)
            Destroy(overlayObject);

        transform.DOKill();
        if (overlayImage != null)
            overlayImage.DOKill();
    }
}
