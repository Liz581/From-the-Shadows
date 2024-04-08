using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class HealthandMana : MonoBehaviour
{
    public UnityEngine.UI.Text healthText; // Reference to the Text component for displaying health
    public UnityEngine.UI.Text manaText; // Reference to the Text component for displaying mana
    private int currentHealth = 100; // Starting health value
    private int currentMana = 100; // Starting mana value

    void Start()
    {
        UpdateStatusUI(); // Update the status UI when the script starts
    }

    // Method to update the health and mana values and UI display
    public void UpdateStatus(int newHealth, int newMana)
    {
        currentHealth = newHealth;
        currentMana = newMana;
        UpdateStatusUI();
    }

    // Method to update the health and mana UI text
    private void UpdateStatusUI()
    {
        healthText.text = "Health: " + currentHealth + "/100";
        manaText.text = "Mana:    " + currentMana + "/100";
    }
}
