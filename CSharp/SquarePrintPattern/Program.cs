static void PrintErrorMesssage()
{
    Console.WriteLine();
    Console.WriteLine("Number must NOT contain spaces.\n");
    Console.WriteLine("Number must NOT contain letters.\n");
    Console.WriteLine("Number must NOT contain symbols.\n");
    Console.WriteLine("Number must NOT be a decimal number.\n");
    Console.WriteLine("Number must NOT be a negative integer.\n");
    Console.WriteLine("Number must NOT be an even integer.\n");
    Console.WriteLine("Number must NOT be blank.\n");
    Console.WriteLine();
}

static bool ValidateInput(in string input, ref int inputNum)
{
    int numDigits = 0;
    string trimmedInput = input.Trim();

    if (trimmedInput.StartsWith('-') || trimmedInput.StartsWith('\0'))
    {
        PrintErrorMesssage();
        return false;
    }
    else
    {
        for (int i = 0; i < trimmedInput.Length; i++)
        {
            if (char.IsDigit(trimmedInput[i]))
            {
                numDigits++;
            }
            else
            {
                PrintErrorMesssage();
                return false;
            }
        }
    }

    if (trimmedInput.EndsWith('1') || trimmedInput.EndsWith('3') || trimmedInput.EndsWith('5') || trimmedInput.EndsWith('7') || trimmedInput.EndsWith('9'))
    {
        inputNum = int.Parse(trimmedInput);
        return true;
    }
    else
    {
        return false;
    }

}

static int GetUserNumber()
{
    while (true)
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine() ?? "";
        int inputNum = 0;

        bool flag = ValidateInput(input, ref inputNum);

        if (flag)
        {
            return inputNum;
        }
    }
}

static void InitialSquareArray(ref char[,] squareArray, int oddInt, in char input)
{
    for (int i = 0; i < oddInt; i++)
    {
        for (int j = 0; j < oddInt; j++)
        {
            squareArray[i, j] = input;
        }
    }
}

static void FillSquareArray(ref char[,] squareArray, int oddInt, int index, in char input)
{
    for (int i = index; i < (oddInt / 2); i += 2)
    {
        for (int j = i; j < oddInt - i; j++)
        {
            squareArray[i, j] = input;
            squareArray[oddInt - 1 - i, j] = input;
            squareArray[j, i] = input;
            squareArray[j, oddInt - 1 - i] = input;
        }
    }
}

static void PrintSquareArray(in char[,] squareArray, int oddInt)
{
    for (int i = 0; i < oddInt; i++)
    {
        for (int j = 0; j < oddInt; j++)
        {
            Console.Write(squareArray[i, j]);
        }
        Console.WriteLine();
    }
}

static void PrintPattern(ref char[,] squareArray, int oddInt)
{
    if (oddInt % 4 == 1)
    {
        InitialSquareArray(ref squareArray, oddInt, ' ');
        FillSquareArray(ref squareArray, oddInt, 0, 'X');
    }
    else
    {
        InitialSquareArray(ref squareArray, oddInt, 'X');
        FillSquareArray(ref squareArray, oddInt, 1, ' ');
    }
    PrintSquareArray(squareArray, oddInt);
}


int oddInt = GetUserNumber();
char[,] squareArray = new char[oddInt, oddInt];
Console.WriteLine();
PrintPattern(ref squareArray, oddInt);
return 0;
