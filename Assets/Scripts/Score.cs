using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Configuration des Points")]
    public int pointsParPV = 1000;
    public int pointsParBallon = 500;
    public int malusParSeconde = 10;
    public int scoreBaseTemps = 5000;

    [Header("Scripts de Données")]
    public PlayerHealtth playerHealth; // Ton script de vie
    public Timer gameTimer;             // Ton script de temps
    public ScoreManager inventory;      // Ton script d'inventaire (celui qui a les ballons)

    [Header("Affichage TextMeshPro")]
    public TextMeshProUGUI txtDetailVie;
    public TextMeshProUGUI txtDetailBallons;
    public TextMeshProUGUI txtDetailTemps;
    public TextMeshProUGUI txtTotalFinal;

    public void AfficherResultatsFinaux()
    {
        // 1. Récupération sécurisée des données
        // Vérifie bien que ces noms de variables (currentHealth, etc.) correspondent aux tiens
        int hp = playerHealth != null ? playerHealth.currentHealth : 0;
        int ballons = inventory != null ? inventory.score : 0;
        float tempsEcoule = gameTimer != null ? gameTimer.elapsedTime : 0;

        // 2. Calculs
        int scoreHP = hp * pointsParPV;
        int scoreBallons = ballons * pointsParBallon;

        // Calcul du bonus temps (on ne descend pas en dessous de 0)
        int scoreTemps = Mathf.Max(0, scoreBaseTemps - (int)(tempsEcoule * malusParSeconde));

        int totalScore = scoreHP + scoreBallons + scoreTemps;

        // 3. Mise à jour de l'UI
        if (txtDetailVie)
            txtDetailVie.text = $"SURVIE : {hp} PV x {pointsParPV} = {scoreHP:N0} pts";

        if (txtDetailBallons)
            txtDetailBallons.text = $"RECOLTE : {ballons} Ballons x {pointsParBallon} = {scoreBallons:N0} pts";

        if (txtDetailTemps)
            txtDetailTemps.text = $"RAPIDITE : Bonus de {scoreTemps:N0} pts";

        if (txtTotalFinal)
            txtTotalFinal.text = $"SCORE FINAL : {totalScore:N0}";

        Debug.Log("Tableau des scores mis à jour !");
    }
}
