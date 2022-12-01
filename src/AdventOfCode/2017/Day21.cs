using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day21
    {
        private static readonly string[] StartingPixels = new[]
        {
            ".#.",
            "..#",
            "###"
        };

        public static int Task1(string[] rules, int iterations)
        {
            var image = new Image(StartingPixels);
            var kalle = rules
                .Select(ParseRule)
                .ToArray();

            for (int i = 0; i < iterations; i++)
            {
                var subImages = image.Split();
                var transformedImages = new List<Image>();

                foreach (var subImage in subImages)
                {
                    foreach (var anka in kalle)
                    {                      
                        if (anka.IsMatching(subImage))
                        {
                            transformedImages.Add(anka.Output);
                            break;
                        }
                    }
                }

                image = Image.Combine(transformedImages);
            }

            return image.NumberOfPixelsThatAreOn();
        }

        private static Rule ParseRule(string rule)
        {
            var images = rule.Split(" => ");
            var pattern = new Image(images[0].Split('/').ToArray());
            var output = new Image(images[1].Split('/').ToArray());
            return new Rule(pattern, output);
        }

        private class Rule
        {
            private readonly Image pattern;
            public Image Output { get; }

            public Rule(Image pattern, Image output)
            {
                this.pattern = pattern;
                Output = output;
            }

            public bool IsMatching(Image input)
            {
                return input.IsSame(pattern);
            }
        }

        private class Image
        {
            private readonly string[] pixels;

            public int Size => pixels.Length;

            public Image(string[] pixels)
            {
                this.pixels = pixels;
            }

            public IEnumerable<Image> Split()
            {
                var splitSize = Size % 2 == 0 ? 2 : 3;

                for (int i = 0; i < Size; i += splitSize)
                {
                    for (int j = 0; j < Size; j += splitSize)
                    {
                        yield return SubImage(j, i, splitSize);
                    }
                }
            }

            public static Image Combine(List<Image> subImages)
            {
                var subImageSize = subImages.First().Size;
                var n = (int)Math.Sqrt(subImages.Count);
                var rows = new StringBuilder[n * subImageSize];
                for (var i = 0; i < rows.Length; i++)
                {
                    rows[i] = new StringBuilder();
                }

                for (var i = 0; i < subImages.Count; i++)
                {
                    var row = (i / n) * subImageSize;
                    for (var j = 0; j < subImageSize; j++)
                    {
                        rows[row + j].Append(subImages[i].pixels[j]);
                    }
                }

                var combinedPixels = rows
                    .Select(row => row.ToString())
                    .ToArray();

                return new Image(combinedPixels);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 19;

                    foreach (var row in pixels)
                    {
                        hash = hash * 31 + row.GetHashCode();
                    }

                    return hash;
                }
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Image);
            }

            public bool Equals(Image other)
            {
                if (other == null)
                {
                    return false;
                }

                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        if (pixels[i][j] != other.pixels[i][j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            private Image SubImage(int x, int y, int size)
            {
                var subPixels = new string[size];

                for (int i = 0; i < size; i++)
                {
                    subPixels[i] = pixels[y + i].Substring(x, size);
                }

                return new Image(subPixels);
            }

            public int NumberOfPixelsThatAreOn() 
            {
                return pixels
                    .Select(row => row.Where(pixel => pixel == '#').Count())
                    .Sum();
            }

            private Image Flip()
            {
                var flippedPixels = pixels
                    .Select(x => string.Concat(x.Reverse()))
                    .ToArray();

                return new Image(flippedPixels);
            }

            private Image Rotate()
            {
                var rotatetedPixels = new string[Size];
                for (var i = 0; i < Size; i++)
                {
                    var temp = new StringBuilder();
                    for (var j = 0; j < Size; j++)
                    {
                        temp.Append(pixels[Size - 1 - j][i]);
                    }
                    rotatetedPixels[i] = temp.ToString();
                }

                return new Image(rotatetedPixels);
            }

            public bool IsSame(Image other)
            {
                if (Size != other.Size)
                {
                    return false;
                }

                if (Equals(other))
                {
                    return true;
                }
                var foo = other.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                foo = foo.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                foo = foo.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                foo = other.Flip();
                if (Equals(foo))
                {
                    return true;
                }
                foo = foo.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                foo = foo.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                foo = foo.Rotate();
                if (Equals(foo))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
