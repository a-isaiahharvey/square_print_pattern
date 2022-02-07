//
//  main.swift
//  SquarePrintPattternInSwift
//
//  Created by Allister Isaiah Harvey on 2/7/22.
//

import Cocoa

func getUserNumber() -> Int {
    while true {
        print("Enter a number: ")
        var inputNum = 0
        if let input = readLine() {
            let flag = validateInput(input, &inputNum);
            if flag {
                return inputNum
            }
            printErrorMessage()
        }
    }
}

func validateInput(_ input: String, _ inputNum: inout Int) -> Bool {
    var numDigits = 0
    let trimmedInput = input.trimmingCharacters(in: .whitespacesAndNewlines)
    if trimmedInput.starts(with: "-") || trimmedInput.starts(with: "\0") {
        return false
    } else {
        for i in 0..<trimmedInput.count {
            if trimmedInput[trimmedInput.index(trimmedInput.startIndex, offsetBy: i)].isNumber {
                numDigits = numDigits + 1
            } else {
                return false
            }
        }
    }
    if trimmedInput.reversed().starts(with: "1")
        || trimmedInput.reversed().starts(with: "3")
        || trimmedInput.reversed().starts(with: "5")
        || trimmedInput.reversed().starts(with: "7")
        || trimmedInput.reversed().starts(with: "9")
    {
        inputNum = Int(trimmedInput).unsafelyUnwrapped
        return true
    } else {
        return false
    }
}

func printErrorMessage() {
    print()
    print("Number must NOT contain spaces.")
    print("Number must NOT contain letters.")
    print("Number must NOT contain symbols.")
    print("Number must NOT be a decimal number.")
    print("Number must NOT be a negative integer.")
    print("Number must NOT be an even integer.")
    print("Number must NOT be blank.")
    print()
}

func printPattern(_ ary: inout [[Character]], _ oddInt: Int) {
    if oddInt % 4 == 1 {
        initialSquareArray(&ary, oddInt, " ")
        fillSquareArray(&ary, oddInt, 0, "X")
    } else {
        initialSquareArray(&ary, oddInt, "X")
        fillSquareArray(&ary, oddInt, 1, " ")
    }
    printSquareArray(ary, oddInt)
}

func initialSquareArray(_ ary: inout [[Character]], _ oddInt: Int, _ input: Character) {
    for i in 0..<oddInt {
        for j in 0..<oddInt {
            ary[i][j] = input
        }
    }
}

func fillSquareArray(_ ary: inout [[Character]], _ oddInt: Int, _ index: Int, _ input: Character) {
    for i in stride(from: index, to: (oddInt / 2), by: 2) {
        for j in i ... (oddInt - 1) - i {
            ary[i][j] = input
            ary[(oddInt - 1) - i][j] = input
            ary[j][i] = input
            ary[j][(oddInt - 1) - i] = input
        }
    }
}

func printSquareArray(_ ary: [[Character]], _ oddInt: Int) {
    for i in 0..<oddInt {
        for j in 0..<oddInt {
            print("\(ary[i][j]) ", terminator: "")
        }
        print()
    }
}

func main() {
    let oddInt = getUserNumber()
    var ary = Array(repeating: Array(repeating: Character.init(" "), count: oddInt), count: oddInt)
    printPattern(&ary, oddInt)
}

main()

