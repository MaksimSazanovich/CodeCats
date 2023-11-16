using UnityEngine;
using UnityEditor;

public enum OrientationType
{
    Portrait,
    Landscape,
    Fullscreen
}

[ExecuteAlways]
public class ScreenOrientation : MonoBehaviour
{
    [SerializeField] private OrientationType orientationType;
    [SerializeField] private Color backgroundColor = new Color(34f / 255f, 40f / 255f, 73f / 255f);
    [SerializeField] private bool showDebugLog = false;

    private float targetAspectRatioWidth;
    private float targetAspectRatioHeight;

    private int previousScreenWidth;
    private int previousScreenHeight;

    private Camera mainCamera;
    private Camera backgroundCamera;

    private Color previousBackgroundColor;

    private void Awake()
    {
        mainCamera = Camera.main;

        UpdateAspectRatio();
        CreateBackgroundCamera();
    }

    private void OnEnable()
    {
        Connect.OnDesctopDevice += SetPortrait;
        Connect.OnPhoneDevice += SetFullscreen;
    }

    private void OnDisable()
    {
        Connect.OnDesctopDevice -= SetPortrait;
        Connect.OnPhoneDevice -= SetFullscreen;
    }

    private void CreateBackgroundCamera()
    {
        if (backgroundCamera != null)
        {
            return;
        }

        backgroundCamera = mainCamera.transform.Find("BackgroundCamera")?.GetComponent<Camera>();

        if (showDebugLog)
        {
            Debug.Log("Поиск дополнительной камеры");
        }

        if (backgroundCamera == null)
        {
            GameObject createdBackgroundCamera = new GameObject("BackgroundCamera");
            backgroundCamera = createdBackgroundCamera.AddComponent<Camera>();
            createdBackgroundCamera.transform.SetParent(mainCamera.transform);

            backgroundCamera.clearFlags = CameraClearFlags.SolidColor;
            backgroundCamera.renderingPath = RenderingPath.Forward;
            backgroundCamera.cullingMask = 0;
            backgroundCamera.depth = -2;
            backgroundCamera.allowHDR = false;
            backgroundCamera.allowMSAA = false;

            if (showDebugLog)
            {
                Debug.Log("Создание дополнительной камеры");
            }
        }
    }

    private void UpdateBackgroundCamera()
    {
        if (backgroundCamera != null && backgroundColor != previousBackgroundColor)
        {
            backgroundCamera.backgroundColor = backgroundColor;
            previousBackgroundColor = backgroundColor;

            if (showDebugLog)
            {
                Debug.Log("Изменение цвета");
            }
        }
    }

    private void Update()
    {
        if (ScreenChanged())
        {
            UpdateAspectRatio();
            UpdateBackgroundCamera();
            if (showDebugLog)
            {
                Debug.Log("Деформация окна");
            }
        }
    }

    private bool ScreenChanged()
    {
        return Screen.width != previousScreenWidth || Screen.height != previousScreenHeight;
    }

    private void UpdateAspectRatio()
    {
        if (mainCamera == null)
            return;

        if (orientationType == OrientationType.Portrait)
        {
            targetAspectRatioWidth = 9f;
            targetAspectRatioHeight = 16f;
        }
        else if (orientationType == OrientationType.Landscape)
        {
            targetAspectRatioWidth = 16f;
            targetAspectRatioHeight = 9f;
        }
        else if (orientationType == OrientationType.Fullscreen)
        {
            targetAspectRatioWidth = (float)Screen.width;
            targetAspectRatioHeight = (float)Screen.height;
        }

        previousScreenWidth = Screen.width;
        previousScreenHeight = Screen.height;

        float currentAspectRatio = (float)Screen.width / Screen.height;
        float targetWidth;
        float targetHeight;

        if (currentAspectRatio > (targetAspectRatioWidth / targetAspectRatioHeight))
        {
            targetWidth = (targetAspectRatioWidth / targetAspectRatioHeight) * Screen.height;
            targetHeight = Screen.height;
        }
        else
        {
            targetWidth = Screen.width;
            targetHeight = Screen.width / (targetAspectRatioWidth / targetAspectRatioHeight);
        }

        float widthDiff = Screen.width - targetWidth;
        float heightDiff = Screen.height - targetHeight;
        float leftOffset = widthDiff / 2f;
        float bottomOffset = heightDiff / 2f;

        mainCamera.rect = new Rect(leftOffset / Screen.width, bottomOffset / Screen.height, targetWidth / Screen.width, targetHeight / Screen.height);
    }

    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            UpdateAspectRatio();
            UpdateBackgroundCamera();
        }
    }

    public void SetPortrait()
    {
        orientationType = OrientationType.Portrait;
        UpdateAspectRatio();
    }
    public void SetLandscape()
    {
        orientationType = OrientationType.Landscape;
        UpdateAspectRatio();
    }

    public void SetFullscreen()
    {
        orientationType = OrientationType.Fullscreen;
        UpdateAspectRatio();
    }
}