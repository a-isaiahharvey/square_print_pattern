use std::io::{self, Write};

fn print_error_message() {
    print!("\n");
    print!("Number must NOT contain spaces.\n");
    print!("Number must NOT contain letters.\n");
    print!("Number must NOT contain symbols.\n");
    print!("Number must NOT be a decimal number.\n");
    print!("Number must NOT be a negative integer.\n");
    print!("Number must NOT be an even integer.\n");
    print!("Number must NOT be blank.\n");
    print!("\n");
}

unsafe fn validate_input(input: String, input_num: *mut usize) -> bool {
    let mut num_digits = 0;
    let trimmed_input = input.trim();
    if trimmed_input.starts_with('-') || trimmed_input.starts_with('\0') {
        print_error_message();
        return false;
    } else {
        for i in 0..trimmed_input.len() {
            if trimmed_input.chars().nth(i).unwrap().is_numeric() {
                num_digits = num_digits + 1
            } else {
                print_error_message();
                return false;
            }
        }
    }
    if trimmed_input.ends_with('1')
        || trimmed_input.ends_with('3')
        || trimmed_input.ends_with('5')
        || trimmed_input.ends_with('7')
        || trimmed_input.ends_with('9')
    {
        *input_num = trimmed_input.parse::<usize>().unwrap();
        return true;
    } else {
        return false;
    }
}

fn get_user_number() -> usize {
    loop {
        print!("Enter a number: ");
        io::stdout().flush().unwrap();
        let mut input_num: usize = 0;
        let mut input = String::new();
        io::stdin()
            .read_line(&mut input)
            .ok()
            .expect("Failed to read line");
        unsafe {
            let flag = validate_input(input, &mut input_num);
            if flag {
                return input_num;
            }
        }
    }
}

fn initial_square_array(ary: &mut Vec<Vec<char>>, odd_int: usize, input: &char) {
    for i in 0..odd_int {
        for j in 0..odd_int {
            ary[i][j] = *input;
        }
    }
}

fn fill_square_array(ary: &mut Vec<Vec<char>>, odd_int: usize, index: u32, input: &char) {
    for i in (index as usize..=(odd_int / 2)).step_by(2) {
        for j in i..=(odd_int - 1) - i {
            ary[i][j] = *input;
            ary[(odd_int - 1) - i][j] = *input;
            ary[j][i] = *input;
            ary[j][(odd_int - 1) - i] = *input;
        }
    }
}

fn print_square_array(ary: &mut Vec<Vec<char>>, odd_int: usize) {
    for i in 0..odd_int {
        for j in 0..odd_int {
            print!("{}", ary[i][j]);
            print!(" ");
        }
        print!("\n");
    }
}

fn print_pattern(ary: &mut Vec<Vec<char>>, odd_int: usize) {
    if odd_int % 4 == 1 {
        initial_square_array(ary, odd_int, &' ');
        fill_square_array(ary, odd_int, 0, &'X');
    } else {
        initial_square_array(ary, odd_int, &'X');
        fill_square_array(ary, odd_int, 1, &' ');
    }
    print_square_array(ary, odd_int)
}

fn main() {
    let odd_int = get_user_number();
    let ary = &mut vec![vec![' '; odd_int]; odd_int];
    print!("\n");
    print_pattern(ary, odd_int);
}
