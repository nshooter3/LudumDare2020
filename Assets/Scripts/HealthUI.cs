using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthBar;
    public Image healthBackground;
    public Image healthDamage;
    public RectTransform healthUI;
    private float healthMaxLength;
    private Color healthBackgroundColorInit, healthBackgroundColorFlash;
    private float healthFlashTimer, healthFlashTimerMax = 0.15f;
    Vector3 InitHealthSize, BigHealthSize;
    Vector3 InitPos, MovedPos;
    float movedDistance = 10f;

    private float healthDamageTimer, healthDamageTimerMax = 1f;
    private float healthDamageShrinkSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        healthMaxLength = healthBar.rectTransform.sizeDelta.x;
        healthBackgroundColorInit = healthBackground.color;
        healthBackgroundColorFlash = Color.Lerp(healthBackgroundColorInit, Color.white, 0.25f);
        InitHealthSize = healthUI.localScale;
        BigHealthSize = InitHealthSize * 1.05f;
        InitPos = healthUI.position;
        MovedPos = healthUI.position;
        MovedPos.y += movedDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthFlashTimer > 0)
        {
            healthFlashTimer = Mathf.Max(0, healthFlashTimer - Time.deltaTime);
            healthBackground.color = Color.Lerp(healthBackgroundColorInit, healthBackgroundColorFlash, healthFlashTimer / healthFlashTimerMax);
            healthUI.localScale = Vector3.Lerp(InitHealthSize, BigHealthSize, healthFlashTimer / healthFlashTimerMax);
            healthUI.position = Vector3.Lerp(InitPos, MovedPos, healthFlashTimer / healthFlashTimerMax);
        }
        if (healthDamageTimer > 0)
        {
            healthDamageTimer = Mathf.Max(0, healthDamageTimer - Time.deltaTime);
        }
        else if (healthDamage.rectTransform.sizeDelta.x > healthBar.rectTransform.sizeDelta.x)
        {
            healthDamage.rectTransform.sizeDelta = new Vector2(Mathf.Max(healthBar.rectTransform.sizeDelta.x, healthDamage.rectTransform.sizeDelta.x - healthDamageShrinkSpeed),
                healthDamage.rectTransform.sizeDelta.y);
        }
    }

    public void TakeDamage(int health, int maxHealth)
    {
        healthBar.rectTransform.sizeDelta = new Vector2(((float)health / maxHealth) * healthMaxLength, healthBar.rectTransform.sizeDelta.y);
        healthFlashTimer = healthFlashTimerMax;
        if (healthDamageTimer == 0)
        {
            healthDamageTimer = healthDamageTimerMax;
        }
    }
}
