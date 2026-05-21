using UnityEngine;
using UnityEngine.UIElements;

public class MapSelection_UIController : MonoBehaviour
{
    private VisualElement fadeLayer;

    private Button back;
    private Button mars;
    private Button earth;
    private Button jupiter;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        fadeLayer = root.Q<VisualElement>("FadeLayer");

        back = root.Q<Button>("Back");

        mars = root.Q<Button>("MarsButton");
        earth = root.Q<Button>("EarthButton");
        jupiter = root.Q<Button>("JupiterButton");

        fadeLayer.style.display = DisplayStyle.None;
        fadeLayer.RemoveFromClassList("AfterFading");

        back.RegisterCallback<ClickEvent>(BackToMenu);

        mars.RegisterCallback<ClickEvent>(PlayMars);
        earth.RegisterCallback<ClickEvent>(PlayEarth);
        jupiter.RegisterCallback<ClickEvent>(PlayJupiter);
    }

    private void BackToMenu(ClickEvent evt)
    {
        Debug.Log("aaa");
    }

    private void PlayMars(ClickEvent evt)
    {
        Fade();
    }

    private void PlayEarth(ClickEvent evt)
    {
        Fade();
    }

    private void PlayJupiter(ClickEvent evt)
    {
        Fade();
    }

    private void Fade()
    {
        fadeLayer.style.display = DisplayStyle.Flex;
        fadeLayer.AddToClassList("AfterFading");
    }
}
