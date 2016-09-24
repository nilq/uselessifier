extern crate num;
extern crate image;

use std::fs::File;
use std::path::Path;

use self::num::complex::Complex;

pub struct Procedure;

impl Procedure {
    pub fn do_stuff(data: &Vec<u8>, name: &str) {
        let (width, height) = (800, 800);

        let scale_x = 4.0 / width as f32;
        let scale_y = 4.0 / height as f32;

        let mut new_image = image::ImageBuffer::new(width, height);

        let mut j: usize = 0;

        for (x, y, px) in new_image.enumerate_pixels_mut() {
            let cx = x as f32 * scale_x - 2.0;
            let cy = y as f32 * scale_y - 2.0;

            let mut z = Complex::new(cx, cy);

            if j >= data.len() - 5 {
                break;
            }

            let complex = Complex::new(-0.4 * 0.75f32 * (data[j] as f32).log(10f32), 0.6 * 0.8f32 * (data[j + 1] as f32).log(10f32));

            let mut i = 0;

            for n in 0 .. 255 {
                if z.norm() > 2.0 {
                    break;
                }

                z = z * z + complex;
                i = n;
            }

            *px = image::Luma([i as u8]);

            j += 5;
        }

        let ref mut fout = File::create(&Path::new(name)).unwrap();
        let _ = image::ImageLuma8(new_image).save(fout, image::PNG);
    }
}
