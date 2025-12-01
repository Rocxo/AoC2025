mod dial;
use std::fs;

fn main()
{
    let mut test = dial::Dial { dial_position: 50, dial_max_position: 99 };
    let mut dial_pointer_on_zero_counter = 0;
    let mut dial_pointer_clicked_zero_counter = 0;

    let input_lines = fs::read_to_string("input.txt").expect("should have been able to read the file");
    for line in input_lines.split("\n")
    {
        let direction = if &line[0..1] == "L" { dial::DialDirection::Left } else { dial::DialDirection::Right };
        for _ in 0..line[1..].parse().expect("failed to parse string to integer")
        {
            test.move_dial(&direction);
            if test.dial_position == 0 { dial_pointer_clicked_zero_counter += 1; }
        }
        if test.dial_position == 0 { dial_pointer_on_zero_counter += 1; }
    }

    println!("Day1 Part1 result: {}", dial_pointer_on_zero_counter);
    println!("Day1 Part2 result: {}", dial_pointer_clicked_zero_counter);
}
