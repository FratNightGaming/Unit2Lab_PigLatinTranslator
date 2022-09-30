namespace Pig_Latin_Translator
{
    internal class Program
    {
        public static string userInput = string.Empty;
        
        static void Main(string[] args)
        {
            Introduction();
        }

        public static void Introduction()
        {
            Console.WriteLine("Welcome to PIG LATIN TRANSLATOR! \"Oinkway!\"");
            Console.WriteLine("Please enter a word or a sentence:");
            
            userInput = Console.ReadLine().ToLower();

            while (userInput == string.Empty)
            {
                Console.WriteLine("You must enter a word or a sentence. Try again.");
                userInput = Console.ReadLine();
                continue;
            }
            
            AnalyzeSentence();
        }

        public static void AnalyzeSentence()
        {
            char[] evilCharacters = new char[] { ' ', '.', '!', '?'};
            
            //split user input into array of words
            string[] words = userInput.Split(evilCharacters);

            string finalWord = string.Empty;
            
            foreach (string word in words)
            {
                int count = 0;
                
                Console.WriteLine(word);//test
                string beginningWord = string.Empty;
                string endWord = string.Empty;

                if (word == String.Empty)
                {
                    continue;
                }

                if (WordWithNoVowel(word))
                {
                    finalWord += word + "way" + " ";
                    continue;
                }

                if (WordsWithNumbersOrSymbols(word))
                {
                    finalWord += word + " ";
                    continue;
                }

                if (LetterIsVowel(word[0]))
                {
                    finalWord += word + "way" + " ";
                }

                else
                {
                    foreach (char letter in word)
                    {
                        if (LetterIsVowel(letter))
                        {
                            beginningWord = word.Substring(0, count);
                            endWord = word.Substring(count);
                            finalWord += endWord + beginningWord + "ay" + " ";
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine($"{finalWord}\t");

            TryAgain();
        }

        //asks user to continue or exit program
        public static void TryAgain()
        {
            Console.WriteLine("Would you like to try again? Enter (Y/N)");
            string userResponse = Console.ReadLine().ToUpper();

            if (userResponse == "Y" || userResponse == "YES")
            {
                Introduction();
            }

            else
            {
                Console.WriteLine("Exiting Program. Goodbye!");
            }
        }

        //method to determine if letter IS a vowel
        public static bool LetterIsVowel(char letter)
        {
            if (letter =='a' || letter == 'e' || letter == 'i' || letter =='o' || letter == 'u')//this isn't clean; is there a way to combine contains with multiple parameters?
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //method to determine if word contains vowels
        public static bool WordWithNoVowel(string word)
        {
            if (!word.Contains('a') && !word.Contains('e') && !word.Contains('i') && !word.Contains('o') && !word.Contains('u'))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //method to determine if word contains vowels
        public static bool WordsWithNumbersOrSymbols(string word)
        {
            int count = 0;

            foreach (char letter in word)
            {
                
                if (letter.Equals('1') || letter.Equals('2') || letter.Equals('3') || letter.Equals('4') || letter.Equals('5') || letter.Equals('6') || letter.Equals('7') || letter.Equals('8') || letter.Equals('9') || letter.Equals('@'))
                {
                    return true;
                }

                else
                {
                    count++;

                    if (count == word.Length)
                    {
                        return false;
                    }

                    else
                    {
                        continue;
                    }
                }

            }

            return true;
        }
    }




/*Intro: Pig Latin is a children’s word game in English where starting consonants are flipped to the ends of words and -ay is added to each word.  Hello World would be elloyhay orldway in Pig Latin, for instance.

What will the application do?
1 Point: The application prompts the user for a word.
1 Point: The application translates the text to Pig Latin and displays it on the console.
1 Point: The application asks the user if he or she wants to translate another word.

Build Specifications:
1 Point: Convert each word to a lowercase before translating.
1 Point: If a word starts with a vowel, just add “way” onto the ending.
2 Point: if a word starts with a consonant, move all of the consonants that appear before the first vowel to the end of the word, then add “ay” to the end of the word. 

Extended Exercises(2 points maximum):
1 Point: Keep the case of the word, whether its uppercase (WORD), title case (Word), or lowercase(word).
1 Point: Allow punctuation in the input string.
1 Point: Translate words with contractions. Ex: can’t become an’tcay
1 Point: Don’t translate words that have numbers or symbols. Ex: 189 should be left as 189 and hello@grandcircus.co should be left as hello@grandcircus.co.
1 Point: Check that the user has actually entered text before translating.
1 Point: Make the application take a line instead of a single word, and then find the Pig Latin for each word in the line.
*/

}