use std::path::Path;

use std::fs::File;
use std::error::Error;
use std::io::Read;

use std::env;

// Add modules here!
mod morse;
<<<<<<< HEAD
mod hash;
=======
mod reverse;
>>>>>>> 8ec04e6e8aafcce45577043505ed234919a1ec74

fn main() {
    let args: Vec<_> = env::args().collect();

    assert!(args.len() > 3, "Provide more arguments!");
    uselessify(&args[2], &args[1], &args[3]);
}

fn uselessify(name: &str, method: &str, new_name: &str) {
    // All of the file processing stuff;
    let s = process_file(&name);
    // Done doing file stuff, proceeding to uselessifying;
    // NOTE: This is where you add things!

    match method {
<<<<<<< HEAD
        "morse" => morse::Procedure::do_stuff(&s),
        "hash" => hash::Procedure::do_stuff(&s),
=======
        "morse" => morse::Procedure::do_stuff(&s, new_name),
        "reverse" => reverse::Procedure::do_stuff(&s, new_name),
>>>>>>> 8ec04e6e8aafcce45577043505ed234919a1ec74
        _ => panic!("Useless useless method!"),
    };
}

// Utilities here:
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
