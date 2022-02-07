// #include "square_print_pattern.h"
#include <iostream>
#include <sstream>
#include <string>
#include <vector>

void print_error_message(void) {
  std::cout << "\n"
            << "Number must NOT contain spaces.\n"
            << "Number must NOT contain letters.\n"
            << "Number must NOT contain symbols.\n"
            << "Number must NOT be a decimal number.\n"
            << "Number must NOT be a negative integer.\n"
            << "Number must NOT be an even integer.\n"
            << "Number must NOT be blank.\n"
            << std::endl;
}

bool validate_user_input(std::string &input, unsigned int &user_input) {
  int num_digits = 0;

  if (input[0] == '-' || input[0] == '\0') {
    print_error_message();
    return false;
  } else {
    input = input.substr(0, input.size()); // Remove leading spaces.

    for (uint i = 0; i < input.size(); i++) {
      if (isdigit(input[i])) {
        num_digits++;
      } else {
        print_error_message();
        return false;
      }
    }
  }

  if ((input[input.size() - 1] == '1') || (input[input.size() - 1] == '3') ||
      (input[input.size() - 1] == '5') || (input[input.size() - 1] == '7') ||
      (input[input.size() - 1] == '9')) {
    std::stringstream str_stream_object(input);
    str_stream_object >> user_input;
    return true;
  } else {
    print_error_message();
    return false;
  }
}

uint get_user_input() {
  while (true) {
    std::string input;
    std::cout << "Enter an odd integer: ";
    std::getline(std::cin, input);

    if (input.size() == 0) {
      print_error_message();
      continue;
    }

    unsigned int user_input;
    if (validate_user_input(input, user_input)) {
      if (user_input % 2 == 0) {
        print_error_message();
        continue;
      } else {
        return user_input;
      }
    }
  }
}

void initial_square_array(std::vector<std::vector<char> > &square_array,
                          uint odd_int, char &input) {
  for (uint i = 0; i < odd_int; i++) {
    for (uint j = 0; j < odd_int; j++) {
      square_array[i][j] = input;
    }
  }
}

void fill_square_array(std::vector<std::vector<char> > &square_array,
                       uint odd_int, uint index, char &input) {
  for (uint i = index; i < odd_int / 2; i += 2) {
    for (uint j = i; j < odd_int - i; j++) {
      square_array[i][j] = input;
      square_array[odd_int - 1 - i][j] = input;
      square_array[j][i] = input;
      square_array[j][odd_int - 1 - i] = input;
    }
  }
}

void print_square_array(std::vector<std::vector<char> > &square_array,
                        uint odd_int) {
  for (uint i = 0; i < odd_int; i++) {
    for (uint j = 0; j < odd_int; j++) {
      std::cout << square_array[i][j];
      std::cout << " ";
    }
    std::cout << std::endl;
  }
}

void print_pattern(std::vector<std::vector<char> > &square_array, uint odd_int) {
  char X = 'X';
  char space = ' ';
  if (odd_int % 4 == 1) {
    initial_square_array(square_array, odd_int, space);
    fill_square_array(square_array, odd_int, 0, X);
  } else {
    initial_square_array(square_array, odd_int, X);
    fill_square_array(square_array, odd_int, 1, space);
  }
  print_square_array(square_array, odd_int);
}

int main() {
  uint odd_int = get_user_input();
  std::vector<std::vector<char> > square_array(odd_int,
                                              std::vector<char>(odd_int));
  std::cout << "\n";
  print_pattern(square_array, odd_int);

  return 0;
}