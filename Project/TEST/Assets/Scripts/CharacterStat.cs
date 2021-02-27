using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{

    // Stat : 
    public int MaxPdv = 100;
    public int Pdv;
    public HealthBar healthBar; // on recupere la barre de vie de l'UI
    public bool isInvincible = false;   // savoir si le joueur est encore dans sa frame d'invulnérabilité
    public bool isDead = false;     // savoir si le joueur est mort
    Animation animations; // on recupere les animations 
    CharacterStat characterStat;


    public void ApplyDamage(int dammage) // applique des dégat au player
    {
        if (!isInvincible)
        {
            Pdv = Pdv - dammage;
            healthBar.SetHealth(Pdv); // mise a jour de la barre de vie 
            isInvincible = true;
            StartCoroutine(FrameInvicible());
        }
        if (Pdv <= 0 && isDead == false)
        {
            Dead();
        }
    }
    public IEnumerator FrameInvicible() // function pour la frame d'invulnérabilité
    {
        yield return new WaitForSeconds(0.5f); // met la durée de is_incible a 0.5 seconde (valeur mis au hasard )
        isInvincible = false;
    }

    public void Dead() // fonction appellé quand le joueur est mort 
    {
        characterStat.isDead = true;
        animations.Play("die");
        GameOver.instance.OnPlayerDeath(); // appelle la fonction qui va activer l'interface du gameover
    }

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        Pdv = MaxPdv;
        healthBar.SetMaxHealth(MaxPdv);
        characterStat = gameObject.GetComponent<CharacterStat>();

    }

}
