pub struct Procedure;

use std::error::Error;
use std::io::prelude::*;
use std::fs::File;

use std::path::Path;

fn process_file(name: &str) -> String {
    let path = Path::new(name);
    let display = path.display();

    let mut file = match File::open(&path) {
        Err(what) => panic!("Fucked up {}: {}", display, Error::description(&what)),
        Ok(file) => file,
    };

    let mut s = String::new();
    match file.read_to_string(&mut s) {
        Err(what) => panic!("Fucked up {}: {}", display, Error::description(&what)),
        Ok(_) => s,
    }
}

impl Procedure {

    pub fn do_stuff(data: &Vec<u8>, name: &str, src: &str) {

        let content = process_file(src);
        let words: Vec<&str> = content.split_whitespace().collect();

        let mut res = String::new();

        let mut i: usize = 0;

        for _ in 0 .. data.len() / 2 {
            let a = data[i];
            let b = data[i + 1];

            res.push_str(words[a as usize + b as usize]);
            res.push_str(" ");

            i += 2;
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
