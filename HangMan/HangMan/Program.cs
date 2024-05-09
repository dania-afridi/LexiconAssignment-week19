// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Welcome to GamePlay, Dear hangman player!\n");

//Array of words
string[] words = { "chair", "television", "orange", "broccoli", "sweden", "netflix" };

static void PlayGame(string[] words)
{
    //------------------ Getting Random word from array of words ------------------//
    int maxValue = words.Length;
    Random randomNum = new Random();
    int randomIndex = randomNum.Next(0, maxValue);
    string selectedWord = words[randomIndex];
    //Console.WriteLine(selectedWord);

    //------------------- Empty array for Guessed Letters ------------------//
    char[] guessedLetters = new char[selectedWord.Length];
    for (int i = 0; i < guessedLetters.Length; i++)
    {
        guessedLetters[i] = '_';
    }
    StringBuilder incorrectGuesses = new StringBuilder();
    //------------------- Allowed chances for wrong guess input --------------------------//
    int wrongGuessCount = 10;
    for (int i = 0; i < guessedLetters.Length; i++)
    {
        Console.Write(guessedLetters[i]);
    }
    Console.WriteLine("\n");

    //------------------- take guess input --------------------------//
    while (wrongGuessCount > 0)
    {
        Console.Write("\n Enter your Guess: ");
        string input = Console.ReadLine().ToLower();
        Console.WriteLine("\n");

        //------------ checking if input is other than alphabets ------------//
        while (!(input.All(Char.IsLetter)))
        {
            Console.WriteLine("kindly Choose Word or alphabet only !\n");
            input = Console.ReadLine().ToLower();
        }
        // ---------------- Checking word length for single alphabet------------------//
        if (input.Length == 1)
        {
            // ------------ if selected word cotain char -----------------//
            if (selectedWord.Contains(input))
            {
                char alphabet = char.Parse(input);
                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    if (selectedWord[i] == alphabet)
                    { guessedLetters[i] = alphabet; }
                }
                Console.WriteLine();
                //-------- if correct guessedLetters filled ---------//
                if (!(guessedLetters.Contains('_')))
                {
                    Console.WriteLine("\nCongragulations! \nyou guessed the right word and Saved yourself from hanging!");
                    wrongGuessCount = 0;
                }
            }
            // ------------ if selected word not have char -----------------//
            else
            {
                if (!((incorrectGuesses.ToString()).Contains(input)))
                {
                    incorrectGuesses.Append(input + ", ");
                    wrongGuessCount--;
                }
                Console.WriteLine("Incorrect guess!");

            }
        }
        // ---------------- Checking word length for whole word ------------------//
        else if (input.Length == selectedWord.Length)
        {
            //---------- if correct guess word ----------//
            if (selectedWord == input)
            {
                Console.WriteLine("Congragulations! \nyou guessed the right word and Saved yourself from hanging!");
                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    guessedLetters[i] = input[i];
                }
                wrongGuessCount = 0;
            }
            //---------- if wrong guess word ----------//
            else
            {
                if (!((incorrectGuesses.ToString()).Contains(input)))
                {
                    incorrectGuesses.Append(input + ", ");
                    wrongGuessCount--;
                }
                Console.WriteLine("\nIncorrect guess word!");
            }
        }
        // ---------------- other cases like substring ------------------//
        else
        {
            if (!((incorrectGuesses.ToString()).Contains(input)))
            {
                incorrectGuesses.Append(input + ", ");
                wrongGuessCount--;
            }
            Console.WriteLine("\nIncorrect Guess!");
        }
        // ---------------- if guess count is zero and guessedLetters have blank ------------------//
        if (wrongGuessCount == 0 && guessedLetters.Contains('_'))
        {
            Console.WriteLine("\nSorry! You Lose");
            Console.Write($"\nThe Secrete Word was: {selectedWord} \n\n");
        }

        // ****************** Displaying correct and incorrect Guesses ************************//
        string guessWord = new string(guessedLetters);
        Console.Write($"\n       Guess Word: {guessWord}");
        Console.WriteLine($"       Incorrect Guesses: {incorrectGuesses} \n");

        //--- Display hanging the man if any blank left to fill and wrong choice made
        if (guessedLetters.Contains('_')) hangMan(wrongGuessCount);

    }
}
//********************* Hanging man ***************************
static void hangMan(int count)
{
    Console.WriteLine("Hang the Man: \n");
    switch (count)
    {
        case 1:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|     O ");
                Console.WriteLine("|    // ");
                Console.WriteLine("|     |");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 2:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|    // ");
                Console.WriteLine("|     |");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 3:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|    / ");
                Console.WriteLine("|     |");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 4:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     |");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 5:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 6:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|    / ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 7:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
        case 8:
            {
                Console.WriteLine("|      ");
                Console.WriteLine("|      ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|     ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------");
                Console.WriteLine("\n");
                break;
            }
        case 9:
            {
                Console.WriteLine("-------");
                Console.WriteLine("\n");
                break;
            }
        case 0:
            {
                Console.WriteLine("_______");
                Console.WriteLine("|     | ");
                Console.WriteLine("|     O ");
                Console.WriteLine("|    // ");
                Console.WriteLine("|     |");
                Console.WriteLine("|    // ");
                Console.WriteLine("|      ");
                Console.WriteLine("-------   ");
                Console.WriteLine("\n");
                break;
            }
    }
}

//----------------- Start Playing Game until Player want to play ----------------//
bool gameOn = true;
while (gameOn)
{
    PlayGame(words);
    Console.Write("\n Do you want to play again press 'y' for yes and 'n' for no :  ");
    char option = Console.ReadKey().KeyChar;
    while (!(option == 'y' || option == 'n' || option == 'Y' || option == 'N'))
    {
        Console.Write("\n wrong option slected! \nPlease! enter 'y' for Yes or 'n' for No : ");
        option = Console.ReadKey().KeyChar;
    }
    Console.WriteLine("\n");
    if (option == 'n' || option == 'N')
    {
        gameOn = false;
    }
}
