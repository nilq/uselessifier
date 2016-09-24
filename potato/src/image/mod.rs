extern crate image;

use self::image::{ImageBuffer};

pub struct Procedure;

impl Procedure {
    pub fn do_stuff(data: &Vec<u8>, name: &str) {

        let (width, height) = (300, 300);

        let mut new_image = ImageBuffer::new(width, height);

        let mut i: usize = 0;

        for x in 0 .. width {
            for y in 0 .. height {

                if i >= data.len() - 4 {
                    break;
                }

                let r = data[i];
                let g = data[i + 1];
                let b = data[i + 2];
                let a = data[i + 3] * 2;

                let px = image::Rgba {
                    data: [r, g, b, a],
                };

                new_image.put_pixel(x, y, px);
                i += 4;
            }
        }

        new_image.save("output.png").unwrap();
        println!("Wrote useless image to: {}", name);
    }
}
