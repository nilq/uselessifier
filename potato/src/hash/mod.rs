use std::hash::{Hash, SipHasher, Hasher};
use std::string::ToString;

pub struct Procedure;

impl Procedure {
    pub fn do_stuff(data: &str) {
        let temp = HashType { s: data.to_string()};
        println!("{}", hash(&temp));
    }
}

#[derive(Hash)]
struct HashType {
    s: String,
}

fn hash<T: Hash>(t: &T) -> u64 {
    let mut s = SipHasher::new();
    t.hash(&mut s);
    s.finish()
}
