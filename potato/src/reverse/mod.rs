use std::error::Error;
use std::io::prelude::*;
use std::fs::File;
use std::path::Path;

pub struct Procedure;

impl Procedure {
    pub fn do_stuff(data: &str, name: &str) {
        let atad: String = data.chars().rev().collect::<String>();

        // Write file!
        let path = Path::new(name);
        let display = path.display();

        let mut file = match File::create(&path) {
            Err(what) => panic!("Fucked up {}: {}", display, what.description()),
            Ok(file) => file,
        };

        match file.write_all(atad.as_bytes()) {
            Err(what) => {
                panic!("Fucked up {}: {}", display, what.description())
            },
            Ok(_) => println!("Successfully wrote to {}!", display),
        }
    }
}
