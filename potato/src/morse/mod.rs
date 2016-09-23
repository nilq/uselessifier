use std::collections::HashMap;

use std::error::Error;
use std::io::prelude::*;
use std::fs::File;
use std::path::Path;

pub struct Procedure;

impl Procedure {
    pub fn do_stuff(data: &str, name: &str) {
        let mut morse_map = HashMap::new();
        // alphabetic! - lowercase ...
        morse_map.insert("a", "*-");
        morse_map.insert("b", "-***");
        morse_map.insert("c", "-*-*");
        morse_map.insert("d", "-**");
        morse_map.insert("e", "*");
        morse_map.insert("f", "**-*");
        morse_map.insert("g", "--*");
        morse_map.insert("h", "****");
        morse_map.insert("i", "**");
        morse_map.insert("j", "*---");
        morse_map.insert("k", "-*-");
        morse_map.insert("l", "*-**");
        morse_map.insert("m", "--");
        morse_map.insert("n", "-*");
        morse_map.insert("o", "---");
        morse_map.insert("p", "*--*");
        morse_map.insert("q", "--*-");
        morse_map.insert("r", "*-*");
        morse_map.insert("s", "***");
        morse_map.insert("t", "-");
        morse_map.insert("u", "**-");
        morse_map.insert("v", "***-");
        morse_map.insert("w", "*--");
        morse_map.insert("x", "-**-");
        morse_map.insert("y", "-*--");
        morse_map.insert("z", "--**");
        // alphabetic! - uppercase ...
        morse_map.insert("A", "*-");
        morse_map.insert("B", "-***");
        morse_map.insert("C", "-*-*");
        morse_map.insert("D", "-**");
        morse_map.insert("E", "*");
        morse_map.insert("F", "**-*");
        morse_map.insert("G", "--*");
        morse_map.insert("H", "****");
        morse_map.insert("I", "**");
        morse_map.insert("J", "*---");
        morse_map.insert("K", "-*-");
        morse_map.insert("L", "*-**");
        morse_map.insert("M", "--");
        morse_map.insert("N", "-*");
        morse_map.insert("O", "---");
        morse_map.insert("P", "*--*");
        morse_map.insert("Q", "--*-");
        morse_map.insert("R", "*-*");
        morse_map.insert("S", "***");
        morse_map.insert("T", "-");
        morse_map.insert("U", "**-");
        morse_map.insert("V", "***-");
        morse_map.insert("W", "*--");
        morse_map.insert("X", "-**-");
        morse_map.insert("Y", "-*--");
        morse_map.insert("Z", "--**");
        // digits!
        morse_map.insert("1", "*----");
        morse_map.insert("2", "**---");
        morse_map.insert("3", "***--");
        morse_map.insert("4", "****-");
        morse_map.insert("5", "*****");
        morse_map.insert("6", "-****");
        morse_map.insert("7", "--***");
        morse_map.insert("8", "---**");
        morse_map.insert("9", "----*");
        morse_map.insert("0", "-----");
        // space
        morse_map.insert(" ", " ");

        let split = data.split("");

        let mut res = String::new();

        for e in split {
            match morse_map.get(e) {
                Some(m) => res.push_str(m),
                None => res.push_str(e),
            }
        }

        // Writing file stuff ...
        let path = Path::new(name);
        let display = path.display();

        let mut file = match File::create(&path) {
            Err(what) => panic!("Fucked up {}: {}", display, what.description()),
            Ok(file) => file,
        };

        match file.write_all(res.as_bytes()) {
            Err(what) => {
                panic!("Fucked up {}: {}", display, what.description())
            },
            Ok(_) => println!("Successfully wrote to {}!", display),
        }
    }
}
