
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // script qui va gerer la barre de vie 

    public Slider slider; // recupere le slider de la barre de vie == barre déroulante 

    public Gradient gradient; // gradient == nuance de la couleur de vie selon son état

    public Image fill; // recupere == ce qui rempli la barre de vie == en gros sa couleur

    public void SetMaxHealth(int health) // on met la barre de vie au max 
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f); // le gradient est au max 
    }
    public void SetHealth(int health) // mise a jour de la barre d vie 
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue); // normalized value pour avoir un gradient normalisé cad avec des valeur corrects
    }
}
