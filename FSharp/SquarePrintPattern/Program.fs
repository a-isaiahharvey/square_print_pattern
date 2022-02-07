open System

let print_error_message () =
    printf ("\n")
    printf ("Number must NOT contain spaces.\n")
    printf ("Number must NOT contain letters.\n")
    printf ("Number must NOT contain symbols.\n")
    printf ("Number must NOT be a decimal number.\n")
    printf ("Number must NOT be a negative integer.\n")
    printf ("Number must NOT be an even integer.\n")
    printf ("Number must NOT be blank.\n")
    printf ("\n")



let validateInput (input: string, inputNum: byref<int>) : bool =
    let mutable numDigits = 0
    let trimmedInput = input.Trim()
    let mutable result = true

    match trimmedInput.StartsWith('-') with
    | true ->
        print_error_message ()
        result <- false
    | false ->
        let mutable i = 0

        while i < trimmedInput.Length do
            if System.Char.IsDigit(trimmedInput.[i]) then
                numDigits <- numDigits + 1
            else
                print_error_message ()
                result <- false

            match result with
            | true ->
                if
                    trimmedInput.EndsWith('1')
                    || trimmedInput.EndsWith('3')
                    || trimmedInput.EndsWith('5')
                    || trimmedInput.EndsWith('7')
                    || trimmedInput.EndsWith('9')
                then
                    inputNum <- System.Int32.Parse(trimmedInput)
                    result <- true
                else
                    result <- false
            | false -> result <- false

            i <- i + 1

    result

let rec getUserInput () : int =
    printf ("Enter a number: ")
    let input = Console.ReadLine()
    let mutable inputNum = 0
    let flag = validateInput (input, &inputNum)

    if flag then
        inputNum
    else
        getUserInput ()

let initialSquareArray (squareArray: byref<array<array<char>>>, oddInt: int, input: char) =
    for i in 0 .. oddInt do
        for j in 0 .. oddInt do
            squareArray.[i].[j] <- input

let fillSquareArray (squareArray: byref<array<array<char>>>, oddInt: int, index: int, input: char) =
    for i in 0 .. 2 .. oddInt / 2 do
        for j in i .. oddInt - 1 - i do
            squareArray.[i].[j] <- input
            squareArray.[oddInt - 1].[j] <- input
            squareArray.[j].[i] <- input
            squareArray.[j].[oddInt - 1] <- input

let printSquareArray (squareArray: byref<array<array<char>>>, oddInt: int) =
    for i in 0 .. oddInt do
        for j in 0 .. oddInt do
            printf "%c " squareArray.[i].[j]

        printf ("\n")

let printPattern (squareArray: byref<array<array<char>>>, oddInt: int) =
    if oddInt % 4 = 1 then
        initialSquareArray (&squareArray, oddInt, ' ')
        fillSquareArray (&squareArray, oddInt, 0, 'X')

    else
        initialSquareArray (&squareArray, oddInt, 'X')
        fillSquareArray (&squareArray, oddInt, 1, ' ')

    printSquareArray (&squareArray, oddInt)

[<EntryPoint>]
let main (args) =
    let mutable oddInt = getUserInput ()

    let mutable squareArray: array<array<char>> =
        [| for i in 0 .. oddInt -> [| for i in 0 .. oddInt -> ' ' |] |]

    printPattern (&squareArray, oddInt)

    0
