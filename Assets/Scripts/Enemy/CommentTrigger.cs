using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentTrigger : MonoBehaviour
{
    [Header("Réglages de l'effet")]
    public int commentAmount = 15; // Nombre de commentaires qui vont poper

    private void OnTriggerEnter(Collider other)
    {
        // On vérifie si c'est le joueur qui touche l'objet
        if (other.CompareTag("Player"))
        {
            CommentManager cm = Object.FindAnyObjectByType<CommentManager>();

            if (cm != null)
            {
                Debug.Log("Manager trouvé, lancement du splash !");

                cm.TriggerCommentSplash(commentAmount);
            }
            else
            {
                Debug.LogError("ERREUR : Aucun CommentManager trouvé dans la scène !");
            }

            Destroy(gameObject);
        }
    }
}
