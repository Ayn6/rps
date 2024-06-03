using DefultNamespace;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    private int tiltCount = 0; // Счетчик наклонов
    private float tiltThreshold = 0.5f; // Порог, при котором считается, что телефон наклонился
    private float lastTiltTime = 0f; // Время последнего наклона
    private float tiltCooldown = 0.5f; // Время, в течение которого учитывается только один наклон
    private Vector3 lastAcceleration; // Предыдущее значение ускорения
    private Vector3 lowPassValue = Vector3.zero; // Значение для фильтрации шума
    private float lowPassFilterFactor = 0.2f; // Коэффициент фильтрации

    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI name;

    public List<RPS> items = new List<RPS>();

    void Start()
    {
        lastAcceleration = Input.acceleration;
        lowPassValue = Input.acceleration;
    }

    void Update()
    {
        Vector3 rawAcceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, rawAcceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = rawAcceleration - lowPassValue;

        // Проверяем, превышает ли изменение ускорения пороговое значение
        if (Mathf.Abs(deltaAcceleration.x) > tiltThreshold || Mathf.Abs(deltaAcceleration.y) > tiltThreshold || Mathf.Abs(deltaAcceleration.z) > tiltThreshold)
        {
            // Проверяем, прошло ли достаточно времени с последнего наклона
            if (Time.time - lastTiltTime > tiltCooldown)
            {
                tiltCount++;
                lastTiltTime = Time.time;

                // Если телефон наклонили три раза, вызываем действие
                if (tiltCount >= 3)
                {
                    int index = Random.Range(0, 3);
                    OnThreeTilts(index);
                    tiltCount = 0; // Сбрасываем счетчик
                }
            }
        }

        lastAcceleration = rawAcceleration;
    }

    private void OnThreeTilts(int index)
    {
        sprite.sprite = items[index].sprite;
        name.text = items[index].name;
    }
}
