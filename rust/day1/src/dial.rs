pub enum DialDirection
{
    Left,
    Right
}

pub struct Dial
{
    pub dial_position: i32,
    pub dial_max_position: i32
}

impl Dial
{
    pub fn move_dial(&mut self, direction: &DialDirection)
    {
        let mut new_dial_position = self.dial_position;

        if matches!(direction, DialDirection::Left) { new_dial_position -= 1; }
        else { new_dial_position += 1; }
        
        if new_dial_position > self.dial_max_position { new_dial_position = 0; }
        else if new_dial_position < 0 { new_dial_position = self.dial_max_position; }

        self.dial_position = new_dial_position;
    }
}