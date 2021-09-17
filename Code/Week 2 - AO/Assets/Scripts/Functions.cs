using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Public Variables
    public bool canPrintOne = false;
    public bool canPrintTwo = false;
    public string functionTwoString;
    public bool canPrintThree = false;

    // Initialization
    Dictionary<string, int> letters = new Dictionary<string, int>();
    public List<string> words = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");

        if (canPrintOne == true)
        {
            functionOne();
        }
        if (canPrintTwo == true)
        {
            functionTwo();
        }
        if (canPrintThree == true)
        {
            functionThree();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Write a function that outputs all numbers from 0 to 1000 that have both a 3 and a 7 in them.
    void functionOne()
    {
        // Variables
        int numbers = 1000;
        string number;

        // Loop to step through 0 to 1000
        for (int i = 0; i <= numbers; i++)
        {
            // Converts the indexed int to a string
            number = i.ToString();
            
            // Checks if the string contains a 3 or a 7
            if (number.Contains("3") && number.Contains("7"))
            {
                // Outputs the number if it passes the check
                Debug.Log(i);
            }
        }
    }

    // Write a function to determine the most common letter in a string.
    // SIDENOTE: I geneuinely couldn't figure out how to compare different values to each other to determine the most common
    void functionTwo()
    {

        // For Loop to step through the string elements and increment keys and values, and remove whitespace
        for (int counter = 0; counter < functionTwoString.Length; counter++)
        {
            // If the Dictionary contains that element already or doesn't
            if (letters.ContainsKey(functionTwoString[counter].ToString()))
            {
                letters[functionTwoString[counter].ToString()]++;
            }
            else
            {
                letters.Add(functionTwoString[counter].ToString(), 1);
            }

            // Remove any spacing/clearing up clutter for the main string elements to display
            if (letters.ContainsKey(functionTwoString[counter].ToString()))
            {
                letters.Remove(" ");
            }
        }

        // Display each key next to it's total value
        foreach (KeyValuePair<string, int> kvp in letters)
        {
            Debug.Log(kvp.Key + " | " + kvp.Value);
        }
    }

    // Write a function that returns a string containing all letters in a list of words passed into it. Each letter should appear only once.
    void functionThree()
    {
        char[] letters = {'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D',
                          'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H',
                          'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L',
                          'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P',
                          'q', 'Q', 'r', 'R', 's', 'S', 't', 'T',
                          'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X',
                          'y', 'Y', 'z', 'Z'};

        // Convert List to string
        string combinedWords = string.Join("", words.ToArray());
        
        // Convert string to array
        char[] wordsArr = combinedWords.ToCharArray();

        // Loop to step through words array
        for (int i = 0; i <= wordsArr.Length; i++)
        {
            // Loop to step through letters array
            for (int j = 0; j < letters.Length; j++)
            {
                // Compare words array to letters array
                if (wordsArr[i] == letters[j])
                {
                    wordsArr[i]--;
                }
            }
            Debug.Log(wordsArr[i]);
        }
    }
}
