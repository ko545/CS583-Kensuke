using UnityEngine;
using UnityEngine.UIElements;

/* TODO:
 * Tutorial link: https://learn.unity.com/tutorial/make-health-bar-with-UItoolkit
 * - pull other branches for player controller
 * - replace tutorial variables with actual variables
 */

public class GameUIHandler : MonoBehaviour
{
    public PlayerControl PlayerControl;
    public UIDocument UIDoc;

    private Label m_HealthLabel;

    private void Start()
    {
        PlayerControl.OnHealthChange += HealthChanged;
        m_HealthLabel = UIDoc.rootVisualElement.Q<Label>("HealthLabel");
        m_HealthBarMask = UIDoc.rootVisualElement.Q<VisualElement>("HealthBarMask");

        HealthChanged();
    }


    void HealthChanged()
    {
        m_HealthLabel.text = $"{PlayerControl.CurrentHealth}/{PlayerControl.MaxHealth}";
        float healthRatio = (float)PlayerControl.CurrentHealth / PlayerControl.MaxHealth;
        float healthPercent = Mathf.Lerp(8, 88, healthRatio);
        m_HealthBarMask.style.width = Length.Percent(healthPercent);
    }
}