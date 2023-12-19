
bool cont = true;
do
{
    Console.WriteLine("1. New game");
    Console.WriteLine("2. About the author");
    Console.WriteLine("3. Exit");
    Console.Write("> ");
    string selection = Console.ReadLine();
    Console.WriteLine();

    switch (selection)
    {
        case "1":

            int action = 0;
            char[] list = new char[9];
            drawTable(list);

            do
            {
                if (action != 9)
                {
                    char player = (action % 2 == 0) ? 'X' : 'O';
                    Console.Write($"{player}'s move > ");
                    string tempMove = Console.ReadLine();
                    int move = int.Parse(string.IsNullOrEmpty(tempMove) ? "10" : tempMove) - 1;
                    Console.WriteLine();
                    if (move < 0 || list.Length <= move || list[move] == 'X' || list[move] == 'O')
                    {
                        Console.WriteLine("Illegal move! Try again.\n");
                        continue;
                    }
                    list[move] = player;
                    action++;
                    drawTable(list);

                    if (checkWinner(list, 'X') || checkWinner(list, 'O'))
                    {
                        Console.WriteLine(checkWinner(list, 'X') ? "X won!" : "O won!");
                        Console.Write("[Press Enter to return to main menu...]");
                        Console.ReadLine();
                        Console.WriteLine();
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Game over!");
                    Console.Write("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    Console.WriteLine();
                    break;
                }
            } while (action < 10);

            break;
        case "2":
            Console.WriteLine("This application was made by Enes Alkus");
            Console.Write("[Press Enter to return to main menu...]");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "3":

            Console.WriteLine("Are you sure you want to quit? [y/n]");
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y") cont = false;
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("");
            break;
    }


} while (cont);


bool checkWinner(char[] list, char player)
{
    for (int i = 0; i < 3; i++)
    {
        if (list[i * 3] == player && list[i * 3 + 1] == player && list[i * 3 + 2] == player
            || list[i] == player && list[i + 3] == player && list[i + 6] == player)
            return true;
    }
    if (list[0] == player && list[4] == player && list[8] == player || list[2] == player && list[4] == player && list[6] == player)
        return true;
    return false;
}

void drawTable(char[] list)
{
    int tempStep = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 1; j <= 11; j++)
        {
            if (j % 4 == 0)
            {
                Console.Write("|");
            }
            else if (j % 2 == 0)
            {
                Console.Write((list[tempStep] == 'X' || list[tempStep] == 'O') ? list[tempStep] : ' ');
                tempStep++;
            }
            else
            {
                Console.Write(" ");
            }
        }
        if (i < 2) Console.WriteLine("\n---+---+---");
    }
    Console.WriteLine("\n");
}