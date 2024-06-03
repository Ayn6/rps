using DefultNamespace;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    private int tiltCount = 0; // ������� ��������
    private float tiltThreshold = 0.5f; // �����, ��� ������� ���������, ��� ������� ����������
    private float lastTiltTime = 0f; // ����� ���������� �������
    private float tiltCooldown = 0.5f; // �����, � ������� �������� ����������� ������ ���� ������
    private Vector3 lastAcceleration; // ���������� �������� ���������
    private Vector3 lowPassValue = Vector3.zero; // �������� ��� ���������� ����
    private float lowPassFilterFactor = 0.2f; // ����������� ����������

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

        // ���������, ��������� �� ��������� ��������� ��������� ��������
        if (Mathf.Abs(deltaAcceleration.x) > tiltThreshold || Mathf.Abs(deltaAcceleration.y) > tiltThreshold || Mathf.Abs(deltaAcceleration.z) > tiltThreshold)
        {
            // ���������, ������ �� ���������� ������� � ���������� �������
            if (Time.time - lastTiltTime > tiltCooldown)
            {
                tiltCount++;
                lastTiltTime = Time.time;

                // ���� ������� ��������� ��� ����, �������� ��������
                if (tiltCount >= 3)
                {
                    int index = Random.Range(0, 3);
                    OnThreeTilts(index);
                    tiltCount = 0; // ���������� �������
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
