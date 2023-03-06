using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Word {
    public Word(string p_english, string p_german)
    {
        english = p_english;
        german = p_german;
    }

    public string english;
    public string german;
}

public class Vocabulary : MonoBehaviour
{
    public Dictionary<string, Word[]> nouns = new Dictionary<string, Word[]>();
    public Dictionary<string, Word[]> verbs = new Dictionary<string, Word[]>();
    
    void Awake()
    {
        // Level 1
        nouns.Add("Level_1", new Word[] {
            new Word("Key",         "Schlüssel"),
            new Word("Gate",        "Tor"),
            new Word("Sand",        "Sand"),
            new Word("Stick",       "Stock"),
            new Word("Cross",       "Kreuz"),
            new Word("Grave",       "Grab"),
            new Word("Cementery",   "Friedhof"),
            new Word("Tower",       "Turm"),
            new Word("Tree",        "Baum"),
            new Word("Forest",      "Wald"),
            new Word("Path",        "Weg"),
            new Word("Stone",       "Stein"),
            new Word("Lock",        "Schloss"),
            new Word("House",       "Haus"),
        });
        // Level 2
        nouns.Add("Level_2", new Word[] {
            new Word("Key",         "Schlüssel"),
            new Word("Gate",        "Tor"),
            new Word("Sand",        "Sand"),
            new Word("Stick",       "Stock"),
            new Word("Cross",       "Kreuz"),
            new Word("Grave",       "Grab"),
            new Word("Cementery",   "Friedhof"),
            new Word("Tower",       "Turm"),
            new Word("Tree",        "Baum"),
            new Word("Forest",      "Wald"),
            new Word("Path",        "Weg"),
            new Word("Stone",       "Stein"),
        });
        // Level 3
        nouns.Add("Level_3", new Word[] {
            new Word("Key",         "Schlüssel"),
            new Word("Gate",        "Tor"),
            new Word("Sand",        "Sand"),
            new Word("Stick",       "Stock"),
            new Word("Cross",       "Kreuz"),
            new Word("Grave",       "Grab"),
            new Word("Cementery",   "Friedhof"),
            new Word("Tower",       "Turm"),
            new Word("Tree",        "Baum"),
            new Word("Forest",      "Wald"),
            new Word("Path",        "Weg"),
            new Word("Stone",       "Stein"),
        });
    }

    public string Translate(string word) {
        // Nouns
        foreach(var level in nouns)
        {
            foreach(Word noun in level.Value)
            {
                if (word.ToLower() == noun.english.ToLower()) {
                    return noun.german;
                }
                else if (word.ToLower() == noun.german.ToLower()) {
                    return noun.english;
                }
            }
        }
        
        // Verbs
        foreach(var level in verbs)
        {
            foreach(Word verb in level.Value)
            {
                if (word.ToLower() == verb.english.ToLower()) {
                    return verb.german;
                }
                else if (word.ToLower() == verb.german.ToLower()) {
                    return verb.english;
                }
            }
        }
        return "???";
    }
}