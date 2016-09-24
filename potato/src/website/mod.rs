pub struct Procedure;

use std::error::Error;
use std::io::prelude::*;
use std::fs::File;

use std::char;

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

    pub fn do_stuff(data: &Vec<u8>, name: &str) {

        let content = process_file("src/html.txt");
        let words: Vec<&str> = content.split("\n").collect();

        let mut res = String::from("<style type=\"text/css\">body{background-color:#CCC}</style>");

        let mut i: usize = 0;

        for n in 0 .. data.len() / 2 {

            if i >= data.len() - 2 {
                break;
            }

            let a = data[i];
            let b = data[i + 1];

            let ptr = words.len() / (1 + (a as usize) % words.len() % 3 + (b as usize) % words.len() % 3) - 1;

            res.push_str("<");
            res.push_str(words[ptr]);
            res.push_str(">");

            for _ in n .. n + data.len() / 25 {

                if i >= data.len() - 2 {
                    break;
                }

                let ascii = match char::from_u32(data[i] as u32) {
                    Some(x) => x,
                    None => ' '
                };

                res.push(ascii);

                i += 1;
            }

            if words[ptr] != "br" && words[ptr] != "hr" {
                res.push_str("</");
                res.push_str(words[ptr]);
                res.push_str(">");
            }

            res.push_str("\n");

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
