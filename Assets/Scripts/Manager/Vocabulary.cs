using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Level {
    public string name;
    public List<Word> words;

    public Level(string p_name, List<Word> p_words)
    {
        name = p_name;
        words = p_words;
    }
}

[System.Serializable]
public struct Word {
    public string english;
    public string german;
    public Sprite image;

    public Word(string p_english, string p_german)
    {
        english = p_english;
        german = p_german;
        image = new Object() as Sprite;
    }

    public Word(string p_english, string p_german, Sprite p_image)
    {
        english = p_english;
        german = p_german;
        image = p_image;
    }
}



public class Vocabulary : MonoBehaviour
{
    [SerializeField]
    //public Dictionary<string, Word[]> words = new Dictionary<string, Word[]>();
    public List<Level> levels = new List<Level>();

    public List<Word> Get(string levelName)
    {
        foreach(Level level in levels) {
            if (level.name == levelName) {
                return level.words;
            }
        }
        return new List<Word>();
    }

    public string Translate(string x) {
        // Nouns
        foreach(var level in levels)
        {
            foreach(Word word in level.words)
            {
                if (x.ToLower() == word.english.ToLower()) {
                    return word.german;
                }
                else if (x.ToLower() == word.german.ToLower()) {
                    return word.english;
                }
            }
        }
        
        return "???";
    }
}