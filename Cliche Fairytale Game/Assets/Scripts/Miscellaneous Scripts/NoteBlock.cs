using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock : MonoBehaviour
{
    [SerializeField] private Sprite notePlayedSprite;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private int notePuzzleValue;
    private AudioSource note;

    private SpriteRenderer sprite;

    private void Start()
    {
        note = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayNote());
        }
    }

    private IEnumerator PlayNote()
    {
        note.Play();
        sprite.sprite = notePlayedSprite;
        NotePuzzle.currentNoteValue = notePuzzleValue;
        NotePuzzle.noteCount++;
        yield return new WaitForSeconds(1f);
        note.Stop();
        sprite.sprite = defaultSprite;
    }
}
