using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Job
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code!");

            //var captha = "5255443714755555317777152441826784321918285999594221531636242944998363716119294845838579943562543247239969555791772392681567883449837982119239536325341263524415397123824358467891963762948723327774545715851542429832119179139914471523515332247317441719184556891362179267368325486642376685657759623876854958721636574219871249645773738597751429959437466876166273755524873351452951411628479352522367714269718514838933283861425982562854845471512652555633922878128558926123935941858532446378815929573452775348599693982834699757734714187831337546474515678577158721751921562145591166634279699299418269158557557996583881642468274618196335267342897498486869925262896125146867124596587989531495891646681528259624674792728146526849711139146268799436334618974547539561587581268886449291817335232859391493839167111246376493191985145848531829344198536568987996894226585837348372958959535969651573516542581144462536574953764413723147957237298324458181291167587791714172674717898567269547766636143732438694473231473258452166457194797819423528139157452148236943283374193561963393846385622218535952591588353565319432285579711881559343544515461962846879685879431767963975654347569385354482226341261768547328749947163864645168428953445396361398873536434931823635522467754782422557998262858297563862492652464526366171218276176258582444923497181776129436396397333976215976731542182878979389362297155819461685361676414725597335759976285597713332688275241271664658286868697167515329811831234324698345159949135474463624749624626518247831448143876183133814263977611564339865466321244399177464822649611969896344874381978986453566979762911155931362394192663943526834148596342268321563885255765614418141828934971927998994739769141789185165461976425151855846739959338649499379657223196885539386154935586794548365861759354865453211721551776997576289811595654171672259129335243531518228282393326395241242185795828261319215164262237957743232558971289145639852148197184265766291885259847236646615935963759631145338159257538114359781854685695429348428884248972177278361353814766653996675994784195827214295462389532422825696456457332417366426619555";
            //Console.WriteLine("Day 1:");
            //Console.WriteLine($"Task 1: {Day01.Task1(captha)}");
            //Console.WriteLine($"Task 2: {Day01.Task2(captha)}");
            //Console.WriteLine();

            //var speadsheet = File
            //    .ReadAllLines("Day02.txt")
            //    .ToList();
            //Console.WriteLine("Day 2:");
            //Console.WriteLine($"Task1: {Day02.Task1(speadsheet)}");
            //Console.WriteLine($"Task2: {Day02.Task2(speadsheet)}");
            //Console.WriteLine();

            //var square = 361527;
            //Console.WriteLine("Day 3:");
            //Console.WriteLine($"Task1: {Day03.Task1(square)}");
            //Console.WriteLine($"Task2: {Day03.Task2(square)}");
            //Console.WriteLine();

            //var passphrases = File
            //    .ReadAllLines("Day04.txt")
            //    .ToList();
            //Console.WriteLine("Day 4:");
            //Console.WriteLine($"Task1: {Day04.Task1(passphrases)}");
            //Console.WriteLine($"Task2: {Day04.Task2(passphrases)}");
            //Console.WriteLine();

            //var jumpOffsets = File
            //    .ReadAllLines("Day05.txt")
            //    .ToList();
            //Console.WriteLine("Day 5:");
            //Console.WriteLine($"Task1: {Day05.Task1(jumpOffsets)}");
            //Console.WriteLine($"Task2: {Day05.Task2(jumpOffsets)}");
            //Console.WriteLine();

            //var blockDistribution = "2	8	8	5	4	2	3	1	5	5	1	2	15	13	5	14";
            //Console.WriteLine("Day 6:");
            //Console.WriteLine($"Task1: {Day06.Task1(blockDistribution)}");
            //Console.WriteLine($"Task2: {Day06.Task2(blockDistribution)}");
            //Console.WriteLine();

            //var towers = File
            //    .ReadAllLines("Day07.txt")
            //    .ToList();
            //Console.WriteLine("Day 7:");
            //Console.WriteLine($"Task1: {Day07.Task1(towers)}");
            //Console.WriteLine($"Task2: {Day07.Task2(towers)}");
            //Console.WriteLine();

            //var instructions = File
            //   .ReadAllLines("Day08.txt")
            //   .ToList();
            //Console.WriteLine("Day 8:");
            //Console.WriteLine($"Task1: {Day08.Task1(instructions)}");
            //Console.WriteLine($"Task2: {Day08.Task2(instructions)}");
            //Console.WriteLine();

            //var stream = File
            //   .ReadAllText("Day09.txt");
            //Console.WriteLine("Day 9:");
            //Console.WriteLine($"Task1: {Day09.Task1(stream)}");
            //Console.WriteLine($"Task2: {Day09.Task2(stream)}");
            //Console.WriteLine();

            //var lengths = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12"
            //    .Split(',')
            //    .Select(x => int.Parse(x))
            //    .ToList();
            //var lengths2 = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12".ToCharArray();
            //Console.WriteLine("Day 10:");
            //Console.WriteLine($"Task1: {Day10.Task1(lengths, 256)}");
            //Console.WriteLine($"Task2: {Day10.Task2(lengths2, 256)}");
            //Console.WriteLine();

            //var path = "se,ne,se,ne,n,n,n,n,ne,nw,nw,n,nw,nw,sw,sw,sw,sw,sw,sw,sw,sw,s,sw,sw,sw,ne,sw,sw,s,n,s,s,s,s,nw,s,s,s,s,s,se,s,s,n,s,n,se,se,s,se,s,s,s,se,nw,se,se,se,se,se,ne,se,se,se,se,se,n,se,se,se,ne,se,se,se,se,se,se,n,se,se,ne,ne,ne,n,ne,ne,ne,nw,ne,ne,ne,ne,ne,nw,ne,ne,nw,ne,ne,ne,se,ne,ne,ne,sw,se,sw,ne,n,s,sw,ne,n,n,ne,ne,n,ne,ne,n,n,n,n,n,n,se,sw,ne,n,n,n,ne,n,nw,n,ne,ne,ne,n,n,n,n,n,ne,n,ne,sw,nw,ne,sw,nw,n,n,s,nw,n,n,n,n,n,n,n,nw,s,sw,nw,n,se,se,nw,s,nw,nw,nw,nw,nw,se,n,nw,n,s,sw,n,nw,sw,n,nw,se,nw,n,nw,n,nw,sw,n,nw,ne,se,n,nw,ne,nw,nw,se,n,n,nw,nw,se,n,nw,sw,nw,n,n,nw,nw,s,nw,ne,nw,nw,nw,ne,nw,se,n,nw,nw,sw,nw,sw,nw,nw,se,sw,sw,nw,s,nw,nw,nw,nw,sw,n,ne,nw,s,nw,nw,sw,nw,nw,sw,s,nw,nw,nw,se,nw,nw,sw,sw,nw,se,ne,nw,nw,sw,nw,sw,sw,nw,sw,s,sw,sw,sw,sw,nw,n,nw,nw,sw,sw,nw,nw,nw,nw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,sw,se,sw,sw,sw,nw,sw,sw,sw,sw,sw,sw,nw,sw,sw,s,sw,se,sw,sw,sw,ne,n,sw,sw,sw,sw,sw,sw,se,sw,sw,n,sw,sw,s,sw,n,se,s,sw,s,sw,sw,sw,nw,sw,n,s,sw,sw,s,sw,sw,sw,sw,sw,s,sw,sw,s,sw,sw,sw,ne,sw,s,sw,nw,sw,sw,s,s,s,nw,s,s,nw,sw,se,s,s,sw,sw,sw,s,n,s,n,sw,s,sw,s,s,sw,sw,s,s,sw,nw,nw,s,sw,s,sw,se,s,nw,s,se,se,s,sw,s,sw,s,s,sw,sw,s,sw,s,s,sw,s,ne,s,s,n,s,sw,s,s,s,s,s,ne,sw,s,s,s,s,sw,se,se,s,s,s,s,s,nw,s,sw,s,s,se,s,s,se,n,s,s,s,sw,s,s,s,ne,nw,se,ne,s,s,se,nw,s,s,sw,s,ne,s,se,s,sw,s,sw,s,s,s,s,s,se,s,nw,s,s,s,s,s,nw,sw,s,sw,s,se,ne,s,sw,nw,se,se,sw,s,se,se,s,s,s,se,s,s,sw,se,se,se,se,se,se,sw,s,s,sw,s,s,s,se,s,se,se,se,s,se,ne,se,s,s,se,se,se,ne,s,se,s,s,se,se,nw,s,s,se,s,s,s,nw,se,s,se,s,se,se,se,s,s,s,s,s,s,s,s,se,ne,s,s,nw,se,se,se,s,s,se,se,se,s,s,se,s,s,s,se,se,se,se,se,s,se,se,se,n,se,s,nw,se,s,se,n,se,nw,se,se,se,se,s,nw,se,se,se,nw,se,se,se,se,n,se,se,se,s,se,se,se,sw,se,se,se,n,se,se,se,n,n,se,n,se,se,se,se,n,se,se,se,se,sw,nw,se,sw,nw,sw,se,se,se,se,se,s,se,n,se,se,s,se,se,se,ne,se,se,se,se,se,se,ne,se,se,ne,s,se,se,se,se,se,se,se,se,ne,n,se,se,se,ne,nw,se,n,ne,se,nw,sw,s,se,ne,se,se,ne,se,se,se,ne,se,se,ne,se,sw,ne,s,se,se,se,se,se,se,se,ne,s,sw,nw,ne,se,se,ne,se,se,se,ne,ne,s,se,se,ne,n,ne,se,se,se,se,se,ne,se,se,s,se,se,ne,sw,se,se,se,se,se,se,se,se,se,se,se,s,ne,ne,ne,se,nw,ne,ne,se,se,s,se,se,ne,se,se,ne,se,se,se,se,se,ne,se,sw,se,ne,n,nw,nw,se,se,se,sw,n,ne,se,s,s,nw,ne,s,ne,se,ne,ne,ne,ne,ne,se,nw,ne,se,ne,se,ne,ne,ne,se,ne,se,se,ne,se,ne,ne,ne,se,se,ne,ne,se,se,se,ne,se,se,s,ne,se,ne,ne,nw,ne,ne,ne,se,ne,ne,se,ne,sw,ne,ne,nw,ne,sw,se,ne,ne,se,s,s,ne,ne,ne,se,sw,ne,nw,se,ne,se,ne,ne,ne,s,se,se,ne,ne,ne,ne,ne,s,ne,ne,sw,ne,ne,n,ne,nw,se,ne,ne,ne,se,se,se,ne,ne,ne,ne,s,ne,ne,se,se,ne,ne,ne,ne,n,ne,ne,s,ne,ne,ne,sw,ne,se,ne,ne,ne,nw,n,ne,ne,ne,nw,se,ne,n,ne,ne,n,s,ne,ne,ne,se,ne,ne,ne,ne,sw,ne,ne,ne,ne,ne,ne,ne,ne,s,ne,nw,ne,ne,ne,ne,s,ne,ne,ne,n,ne,ne,se,sw,se,ne,ne,ne,ne,se,n,ne,ne,sw,n,ne,n,ne,ne,ne,ne,ne,ne,ne,ne,se,ne,ne,ne,ne,n,ne,se,s,se,ne,nw,ne,ne,ne,ne,s,ne,ne,n,ne,n,ne,ne,ne,ne,ne,ne,ne,n,ne,ne,n,ne,ne,ne,nw,n,ne,n,ne,ne,ne,sw,ne,ne,ne,n,sw,nw,n,sw,ne,n,ne,se,ne,s,ne,nw,ne,nw,ne,ne,ne,ne,n,n,ne,nw,ne,nw,ne,s,n,ne,ne,se,n,s,ne,ne,n,ne,s,s,nw,s,s,ne,n,ne,ne,sw,ne,n,ne,n,n,ne,se,ne,ne,n,n,ne,n,sw,ne,nw,n,ne,n,ne,n,ne,n,n,s,ne,ne,se,nw,ne,ne,ne,ne,se,s,n,ne,ne,n,n,n,ne,ne,n,n,ne,se,n,ne,n,n,n,n,ne,ne,nw,ne,ne,n,ne,se,n,se,s,nw,n,n,n,s,n,n,n,ne,n,ne,ne,n,n,s,sw,ne,ne,ne,n,s,n,n,n,ne,se,ne,n,n,n,n,n,n,ne,ne,n,n,n,ne,ne,n,ne,n,n,s,ne,n,n,n,n,n,nw,n,n,nw,se,n,n,n,ne,n,ne,sw,n,ne,s,n,se,n,n,ne,se,n,nw,ne,ne,n,ne,n,n,n,n,n,ne,n,n,sw,s,n,ne,ne,n,n,n,n,ne,n,n,n,n,n,n,n,n,n,n,n,n,n,n,nw,n,n,ne,s,n,s,n,n,s,ne,n,sw,n,s,ne,ne,n,n,n,n,n,se,ne,n,n,n,n,n,n,n,s,s,n,s,nw,n,s,n,n,n,n,se,ne,se,n,se,n,n,n,s,n,n,n,n,n,n,n,ne,n,n,ne,n,n,ne,sw,nw,n,ne,n,n,n,nw,n,n,n,n,n,n,sw,nw,n,se,n,n,n,n,nw,n,s,nw,n,n,n,se,n,n,n,n,s,n,n,n,n,n,n,n,n,n,nw,n,n,nw,n,n,n,n,n,n,sw,s,n,sw,n,n,n,n,sw,se,ne,n,n,n,n,n,s,n,n,n,n,n,n,ne,n,ne,n,n,n,n,n,n,n,n,n,n,nw,s,n,n,n,nw,n,n,n,n,n,nw,se,n,n,se,n,n,n,s,n,nw,se,n,nw,se,n,n,n,n,n,nw,n,n,ne,n,sw,n,nw,n,n,n,n,n,n,n,n,ne,n,n,n,n,nw,n,n,s,n,n,n,n,n,n,n,nw,nw,ne,n,n,n,n,n,s,n,nw,n,n,nw,ne,n,nw,n,n,nw,n,nw,n,nw,n,sw,sw,n,nw,n,nw,se,sw,n,nw,nw,n,nw,n,n,n,ne,n,nw,n,nw,n,nw,se,n,nw,n,n,n,n,n,ne,n,n,n,s,n,nw,n,n,nw,nw,n,n,n,n,n,n,n,n,n,ne,n,n,n,sw,nw,n,n,n,n,n,nw,sw,s,n,nw,nw,n,n,n,n,se,n,n,n,ne,n,nw,n,n,n,n,n,n,n,n,nw,n,ne,n,nw,n,nw,ne,nw,s,n,nw,n,nw,n,nw,sw,nw,nw,n,n,sw,n,se,nw,ne,n,n,nw,nw,sw,nw,n,sw,se,n,sw,n,n,n,nw,n,se,sw,nw,n,nw,nw,n,nw,n,n,n,nw,nw,s,n,nw,s,sw,n,nw,nw,nw,ne,ne,nw,n,n,n,nw,n,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,n,n,nw,n,n,n,ne,sw,nw,nw,nw,n,nw,sw,nw,ne,n,nw,nw,n,n,ne,n,n,nw,nw,nw,n,nw,s,se,nw,n,n,n,nw,s,n,nw,ne,nw,n,n,n,nw,nw,se,n,nw,ne,n,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,n,n,nw,n,n,nw,se,s,n,se,se,nw,nw,nw,nw,se,nw,sw,ne,se,nw,s,nw,nw,nw,nw,n,se,nw,nw,nw,nw,nw,nw,nw,n,ne,nw,s,sw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,nw,n,nw,nw,sw,nw,nw,se,n,nw,nw,nw,s,nw,nw,nw,n,sw,nw,s,n,nw,nw,nw,nw,s,s,nw,nw,nw,nw,nw,ne,s,n,n,nw,nw,nw,n,nw,n,nw,nw,nw,nw,ne,ne,n,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,n,s,n,nw,nw,nw,nw,nw,nw,nw,ne,nw,nw,nw,nw,sw,nw,nw,nw,nw,ne,n,nw,n,se,nw,nw,n,nw,nw,nw,nw,nw,s,nw,n,nw,n,ne,nw,nw,nw,sw,nw,nw,sw,se,nw,nw,ne,nw,nw,nw,nw,se,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,n,nw,n,nw,sw,ne,nw,nw,sw,nw,nw,nw,nw,nw,nw,nw,se,s,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,sw,nw,nw,nw,s,nw,nw,se,sw,nw,nw,nw,n,nw,nw,sw,nw,s,nw,nw,n,s,s,se,n,nw,nw,nw,nw,nw,nw,n,sw,nw,sw,nw,nw,nw,nw,sw,ne,nw,nw,ne,se,nw,nw,n,nw,nw,nw,nw,se,nw,nw,sw,ne,nw,nw,nw,nw,sw,ne,nw,nw,sw,s,sw,sw,n,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,sw,ne,sw,nw,sw,nw,nw,nw,sw,nw,se,ne,s,nw,nw,ne,nw,s,nw,sw,sw,sw,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,n,nw,nw,ne,s,nw,sw,nw,nw,ne,nw,nw,n,nw,se,sw,nw,sw,nw,nw,nw,nw,nw,nw,nw,sw,n,sw,n,nw,nw,se,nw,nw,nw,nw,nw,nw,nw,ne,sw,n,nw,se,nw,s,nw,n,nw,nw,nw,sw,se,sw,nw,nw,nw,nw,n,nw,sw,n,nw,nw,se,nw,s,nw,sw,nw,nw,sw,ne,nw,se,sw,nw,s,sw,ne,nw,nw,nw,nw,sw,se,nw,sw,nw,sw,ne,sw,nw,sw,nw,sw,sw,nw,nw,nw,nw,nw,sw,nw,nw,n,nw,nw,n,ne,sw,sw,s,sw,nw,s,nw,s,se,n,nw,nw,nw,nw,sw,sw,nw,ne,nw,sw,nw,nw,s,nw,nw,sw,nw,sw,nw,n,se,nw,nw,nw,nw,se,nw,se,nw,sw,nw,nw,nw,nw,sw,nw,s,nw,n,ne,se,sw,n,sw,sw,se,sw,nw,ne,nw,nw,nw,sw,nw,ne,nw,se,nw,sw,nw,sw,nw,nw,se,nw,sw,sw,nw,sw,nw,nw,sw,se,nw,se,sw,nw,sw,sw,sw,nw,sw,nw,sw,sw,sw,nw,sw,sw,sw,se,nw,nw,sw,nw,se,sw,nw,n,sw,nw,nw,sw,nw,nw,nw,sw,sw,ne,sw,nw,sw,se,sw,sw,sw,ne,nw,nw,ne,sw,sw,sw,ne,sw,s,sw,n,sw,sw,nw,sw,se,sw,sw,nw,sw,sw,sw,nw,sw,nw,nw,nw,se,nw,sw,sw,sw,nw,sw,nw,nw,sw,se,sw,n,nw,nw,sw,nw,sw,sw,sw,sw,sw,s,sw,s,s,sw,nw,nw,sw,sw,nw,nw,nw,sw,nw,sw,nw,ne,sw,nw,n,nw,sw,se,nw,sw,se,sw,sw,nw,sw,s,sw,nw,nw,ne,nw,sw,nw,sw,n,nw,sw,sw,sw,nw,ne,nw,sw,se,nw,nw,sw,nw,n,sw,sw,ne,sw,sw,sw,sw,s,nw,nw,sw,nw,sw,s,nw,nw,nw,se,sw,nw,sw,n,sw,nw,nw,ne,sw,sw,nw,nw,sw,se,sw,nw,nw,nw,sw,nw,nw,sw,s,nw,sw,s,sw,sw,sw,n,sw,sw,sw,sw,sw,nw,nw,sw,sw,nw,sw,sw,nw,nw,s,sw,sw,sw,ne,sw,nw,n,sw,sw,sw,sw,se,sw,sw,sw,sw,nw,nw,sw,sw,sw,n,sw,n,sw,nw,s,sw,sw,sw,nw,ne,sw,sw,ne,sw,sw,n,ne,ne,nw,sw,sw,sw,nw,n,nw,ne,sw,nw,sw,nw,sw,n,sw,s,sw,sw,nw,sw,sw,nw,se,sw,sw,n,sw,nw,s,nw,sw,nw,nw,nw,sw,nw,sw,nw,nw,nw,sw,sw,sw,sw,sw,sw,sw,sw,nw,ne,sw,nw,sw,sw,sw,n,sw,sw,sw,sw,ne,nw,sw,ne,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,s,nw,se,se,sw,sw,sw,sw,nw,sw,nw,ne,s,sw,sw,nw,sw,nw,nw,se,n,sw,nw,sw,sw,sw,sw,sw,ne,sw,sw,s,sw,sw,sw,s,nw,se,nw,sw,s,n,sw,s,nw,ne,sw,sw,sw,ne,sw,nw,nw,n,se,sw,nw,n,sw,sw,sw,sw,se,se,sw,sw,sw,n,sw,sw,sw,sw,sw,sw,sw,se,sw,sw,sw,sw,sw,sw,nw,sw,sw,se,s,nw,nw,nw,nw,sw,sw,n,sw,sw,s,ne,sw,nw,sw,sw,sw,sw,sw,n,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,nw,s,n,sw,s,sw,sw,sw,sw,sw,sw,s,nw,ne,sw,sw,sw,sw,sw,sw,nw,s,sw,nw,sw,sw,sw,sw,sw,ne,se,sw,ne,sw,sw,se,s,sw,sw,sw,sw,ne,n,sw,sw,nw,sw,sw,sw,s,n,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,sw,nw,s,sw,sw,sw,sw,n,sw,sw,se,sw,sw,sw,ne,sw,sw,sw,sw,sw,sw,sw,sw,nw,ne,sw,n,n,sw,sw,sw,sw,sw,sw,sw,sw,ne,sw,sw,sw,sw,sw,nw,sw,sw,se,sw,nw,sw,ne,sw,s,sw,sw,s,sw,sw,s,sw,s,sw,s,sw,sw,sw,s,sw,sw,sw,sw,ne,sw,sw,n,sw,sw,s,sw,nw,sw,ne,sw,sw,sw,s,sw,se,sw,sw,sw,n,sw,sw,sw,sw,sw,sw,s,s,s,n,n,sw,nw,sw,s,sw,sw,sw,s,sw,sw,sw,s,sw,nw,s,sw,sw,sw,se,sw,sw,sw,sw,sw,sw,sw,s,sw,s,se,ne,sw,sw,sw,sw,sw,sw,s,sw,s,se,nw,n,nw,sw,sw,sw,sw,sw,sw,n,sw,sw,sw,sw,sw,sw,s,sw,sw,sw,se,sw,nw,sw,nw,s,n,s,s,sw,sw,sw,s,se,sw,s,sw,sw,sw,s,se,s,sw,sw,sw,sw,sw,sw,sw,sw,sw,n,sw,nw,sw,se,sw,sw,sw,n,sw,sw,sw,s,sw,sw,sw,sw,sw,sw,s,sw,sw,sw,se,s,sw,ne,ne,sw,sw,sw,sw,s,s,sw,sw,sw,sw,s,se,sw,sw,sw,nw,s,s,se,sw,n,sw,s,sw,n,sw,sw,sw,sw,s,sw,sw,sw,ne,sw,sw,se,sw,se,sw,s,sw,sw,s,n,sw,sw,sw,sw,s,s,s,sw,sw,sw,s,sw,ne,nw,n,sw,nw,sw,sw,sw,sw,s,s,sw,sw,sw,s,sw,sw,s,nw,se,s,sw,sw,sw,sw,sw,sw,se,s,sw,ne,s,se,s,sw,sw,sw,s,sw,sw,sw,sw,s,s,s,s,nw,s,ne,s,se,sw,sw,sw,nw,s,sw,nw,s,sw,s,sw,s,sw,nw,sw,sw,sw,sw,sw,se,sw,sw,s,s,nw,sw,sw,sw,sw,sw,sw,n,sw,nw,n,sw,n,ne,n,n,sw,s,s,sw,s,sw,s,sw,s,sw,sw,s,s,s,s,n,sw,s,sw,ne,n,sw,sw,s,s,sw,sw,sw,s,sw,s,sw,sw,s,s,nw,sw,sw,sw,sw,sw,sw,s,s,sw,s,sw,sw,sw,sw,n,s,s,ne,n,sw,s,sw,s,nw,sw,s,sw,sw,s,s,sw,s,sw,sw,sw,s,sw,nw,s,sw,sw,nw,s,sw,s,sw,sw,sw,s,nw,sw,nw,sw,sw,s,sw,sw,s,sw,sw,s,ne,sw,n,sw,sw,sw,s,sw,sw,sw,sw,ne,sw,n,n,sw,n,sw,s,s,s,sw,sw,s,s,sw,sw,nw,sw,s,s,sw,sw,se,nw,sw,sw,sw,sw,n,s,sw,s,nw,s,s,sw,s,s,n,ne,sw,s,s,s,s,nw,s,s,sw,sw,sw,sw,s,s,s,s,sw,s,s,n,se,s,s,n,s,s,sw,nw,s,s,ne,s,s,s,se,sw,sw,sw,s,sw,sw,se,s,sw,s,n,sw,se,s,n,ne,se,s,se,sw,sw,sw,s,sw,nw,sw,s,sw,sw,sw,s,sw,s,sw,s,se,sw,s,s,s,sw,sw,s,s,sw,s,ne,se,s,sw,s,s,n,sw,s,sw,sw,s,s,nw,s,se,sw,s,se,n,sw,sw,ne,sw,s,sw,sw,sw,se,s,nw,n,sw,ne,se,sw,s,s,sw,s,ne,sw,s,s,sw,s,s,ne,s,s,nw,sw,se,sw,se,sw,s,s,s,sw,sw,s,sw,s,s,sw,ne,s,n,se,sw,s,n,s,sw,s,s,sw,sw,s,se,s,s,s,s,se,sw,sw,s,s,s,s,s,s,se,s,sw,s,s,s,s,se,s,n,s,s,s,sw,n,n,nw,ne,se,s,sw,s,s,sw,sw,s,s,sw,n,s,sw,sw,ne,s,nw,ne,s,s,s,s,s,s,se,s,s,s,sw,s,n,nw,s,s,sw,sw,s,s,s,s,s,ne,s,sw,sw,s,s,sw,s,sw,s,sw,nw,sw,s,s,sw,sw,sw,sw,s,se,s,s,s,sw,s,n,sw,nw,sw,s,s,nw,sw,s,s,sw,s,s,sw,sw,sw,s,s,s,se,s,sw,s,s,sw,s,s,s,s,s,s,s,s,s,nw,s,s,sw,s,s,s,s,ne,s,ne,sw,sw,s,n,sw,s,s,s,sw,s,sw,sw,s,sw,s,sw,sw,sw,ne,s,s,s,s,s,s,s,n,sw,s,ne,s,s,s,sw,s,s,sw,s,s,sw,s,n,s,se,s,se,s,n,s,sw,s,s,s,s,sw,sw,se,sw,ne,sw,sw,s,s,sw,s,s,s,s,s,s,s,sw,ne,s,s,s,s,s,sw,se,s,s,s,sw,s,s,s,s,sw,s,sw,sw,s,s,nw,ne,n,sw,sw,s,nw,s,s,ne,ne,s,s,sw,s,s,s,s,s,ne,s,s,s,s,s,s,s,se,s,s,s,s,s,s,s,n,s,s,sw,s,s,s,s,s,s,s,n,s,s,s,s,s,s,sw,s,s,s,s,n,s,n,s,s,s,s,s,s,s,s,n,s,s,ne,s,s,s,s,s,s,s,n,s,s,s,s,s,s,sw,s,s,s,s,s,s,s,nw,nw,s,s,s,s,se,s,s,ne,s,s,sw,s,sw,s,s,sw,sw,n,s,n,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,n,s,s,ne,s,s,s,sw,s,s,s,s,s,s,s,s,s,s,s,s,n,s,s,s,se,nw,s,s,s,s,s,nw,s,s,s,s,sw,s,s,s,ne,s,s,s,s,s,s,s,s,n,s,s,nw,s,s,se,s,s,s,se,s,s,s,sw,s,s,s,s,s,nw,s,s,se,s,s,s,s,s,sw,sw,s,s,s,s,s,s,s,se,s,s,s,s,se,s,s,s,s,s,s,s,s,s,s,s,s,sw,s,s,s,ne,s,nw,s,s,se,s,se,s,s,s,s,s,s,s,ne,se,sw,sw,se,se,s,s,s,s,s,s,s,s,s,ne,ne,s,s,s,s,nw,s,s,s,s,s,n,sw,s,s,se,se,sw,nw,nw,s,s,s,s,s,s,n,s,s,s,s,s,s,se,s,ne,s,se,s,s,s,s,s,sw,n,ne,n,s,ne,se,se,s,s,s,s,nw,s,s,ne,s,s,s,n,s,s,s,s,s,s,s,s,s,s,s,s,nw,s,s,ne,s,s,n,s,s,se,sw,s,nw,s,sw,ne,s,s,s,ne,s,s,nw,s,s,s,s,s,s,s,s,s,se,nw,s,s,s,se,se,se,s,nw,s,s,s,se,s,s,se,sw,ne,s,se,s,se,s,se,nw,n,se,s,se,ne,sw,s,s,s,s,s,s,s,se,s,s,s,sw,s,s,s,s,nw,s,se,s,s,n,ne,s,s,s,s,se,s,s,s,s,s,se,s,sw,s,s,se,se,s,s,s,s,s,n,ne,nw,s,s,s,se,ne,s,se,se,nw,s,s,s,s,s,s,s,s,s,s,s,s,s,n,s,s,s,n,s,s,se,s,s,se,s,s,s,nw,s,s,s,se,s,sw,sw,s,se,s,se,s,s,s,se,se,s,sw,se,s,s,s,s,s,s,se,s,s,s,se,se,s,s,s,s,s,s,s,s,ne,s,nw,s,s,s,se,se,se,s,se,se,s,s,s,s,nw,s,se,s,se,s,se,se,s,se,sw,s,s,se,se,s,ne,s,ne,nw,s,s,s,s,se,se,se,se,s,se,ne,se,se,s,s,se,ne,nw,s,se,s,s,s,nw,s,s,s,s,nw,s,s,s,s,se,sw,s,sw,s,s,s,se,nw,s,se,sw,s,ne,s,s,s,s,n,se,se,s,nw,s,s,s,se,se,s,s,s,s,se,se,s,s,s,se,s,s,ne,s,s,se,sw,se,n,ne,s,s,s,s,s,s,s,nw,se,se,s,s,s,se,s,se,n,s,sw,s,se,s,se,s,s,s,se,s,n,se,s,se,se,s,se,s,se,s,se,sw,s,se,s,se,s,s,s,s,s,s,s,se,nw,s,s,se,s,se,s,s,s,se,se,se,s,se,sw,s,ne,s,s,se,s,s,s,s,se,n,se,n,sw,s,se,ne,se,s,sw,s,se,sw,s,ne,se,n,se,nw,ne,s,s,se,s,sw,se,se,se,s,s,s,se,s,s,s,s,se,se,se,se,se,s,s,n,s,s,s,s,s,se,s,s,s,s,s,nw,sw,ne,se,se,s,s,se,se,se,se,se,s,s,ne,s,se,se,se,se,s,nw,se,s,s,s,s,s,ne,s,se,se,se,se,s,s,s,se,n,s,se,s,se,se,se,se,s,s,se,se,se,se,se,s,s,se,s,s,sw,se,sw,sw,se,sw,n,s,s,s,n,s,s,se,sw,ne,n,se,s,se,sw,se,s,se,se,s,se,s,s,s,s,se,se,s,s,nw,se,se,se,se,s,s,s,sw,s,se,se,s,se,nw,se,se,se,s,sw,s,s,se,s,s,s,s,se,s,se,s,se,se,s,s,se,se,s,se,ne,se,s,se,se,se,s,s,n,s,se,n,s,s,s,se,se,se,s,s,se,s,n,s,sw,se,se,s,se,se,se,s,s,se,se,n,n,nw,se,n,ne,se,s,se,se,s,se,s,s,n,s,nw,se,s,s,ne,n,ne,se,s,se,sw,se,se,s,s,se,s,se,s,se,n,s,se,se,sw,se,s,s,se,se,sw,s,s,nw,se,s,se,se,ne,se,se,se,se,se,se,s,se,s,n,s,s,se,s,s,se,se,s,nw,s,se,se,se,s,se,s,s,se,se,se,se,se,se,s,se,nw,se,se,s,s,se,s,sw,se,se,s,s,n,n,n,s,s,se,s,nw,se,s,se,s,se,nw,se,s,s,ne,se,n,s,s,s,se,s,n,se,s,s,se,se,se,s,se,se,se,se,n,nw,se,se,se,se,se,s,se,se,s,se,se,se,s,se,s,se,n,s,se,s,se,se,se,s,se,se,se,se,se,se,s,se,se,s,s,se,s,s,sw,se,n,se,s,se,s,se,se,se,se,s,s,se,se,se,sw,se,s,se,s,s,se,se,s,se,se,se,se,n,se,sw,se,se,sw,sw,s,se,sw,s,se,se,s,se,se,sw,s,s,s,se,nw,se,s,s,se,se,se,s,se,se,se,s,n,se,se,se,s,s,se,se,se,sw,se,s,sw,s,se,se,se,s,n,se,s,s,s,s,se,ne,se,sw,s,sw,se,se,se,nw,sw,s,se,se,s,se,se,sw,se,s,s,n,se,se,se,ne,s,s,se,s,s,se,nw,s,se,s,se,se,se,se,se,se,se,s,s,s,s,n,se,se,s,ne,se,se,se,sw,se,s,ne,se,s,se,se,se,se,s,s,se,se,se,s,ne,s,s,se,se,s,se,se,se,se,se,s,se,se,se,se,sw,se,s,se,ne,s,se,se,se,se,s,se,n,n,s,se,se,s,se,s,s,se,se,se,se,ne,sw,se,sw,nw,se,se,se,se,se,se,se,s,se,s,se,s,se,s,s,n,se,se,se,s,se,se,se,se,se,s,se,se,se,nw,se,ne,se,se,se,se,nw,n,se,n,se,s,se,se,s,s,se,n,s,s,nw,se,s,n,sw,se,n,se,se,s,nw,se,se,se,se,se,nw,se,se,se,se,n,se,se,se,se,se,se,s,se,se,se,ne,se,se,se,nw,s,se,s,se,se,ne,se,s,ne,s,se,ne,se,se,se,se,ne,n,se,se,s,se,se,sw,se,s,se,sw,se,se,se,n,se,se,se,se,ne,se,s,sw,se,se,se,s,s,se,se,se,se,se,se,se,se,s,se,se,n,se,se,n,n,se,se,se,s,se,se,se,se,nw,se,se,se,sw,se,se,se,s,se,n,se,se,se,s,se,s,se,s,se,se,se,n,sw,se,se,se,n,se,se,nw,se,se,se,se,se,n,se,se,se,nw,se,se,se,se,se,se,se,se,s,se,ne,se,se,se,se,se,sw,se,nw,se,se,s,nw,se,se,se,se,s,ne,se,se,se,se,s,s,se,n,s,se,nw,s,se,se,se,se,s,ne,ne,se,s,se,s,se,se,se,se,se,nw,se,s,se,se,se,se,se,se,se,se,se,s,se,se,se,ne,nw,se,se,se,se,se,se,se,se,nw,se,se,se,se,se,se,se,se,se,se,nw,se,se,n,se,ne,se,se,se,se,s,s,se,se,se,se,se,se,se,se,se,se,se,se,se,se,nw,n,se,se,se,s,se,se,sw,s,s,se,se,nw,se,se,se,se,ne,sw,se,s,se,se,se,se,s,se,se,se,se,se,s,se,se,se,se,se,se,se,se,sw,se,se,se,se,n,se,se,n,s,se,n,se,se,se,se,se,se,se,se,s,se,se,se,se,se,se,se,se,ne,sw,n,se,se,s,se,se,se,se,se,sw,nw,sw,nw,sw,s,se,nw,n,sw,nw,n,n,n,ne,ne,ne,n,ne,n,ne,sw,se,ne,ne,ne,ne,se,ne,ne,ne,n,se,ne,se,se,n,se,se,se,ne,se,se,n,se,sw,se,ne,se,se,s,se,se,s,s,n,nw,s,sw,n,s,s,ne,s,se,sw,se,sw,sw,sw,sw,ne,sw,se,s,s,sw,nw,s,sw,s,s,s,sw,sw,s,nw,sw,sw,sw,sw,sw,s,sw,sw,sw,sw,sw,sw,nw,sw,nw,nw,s,sw,s,sw,sw,sw,sw,sw,nw,sw,sw,se,sw,sw,sw,sw,ne,nw,nw,nw,nw,sw,nw,se,nw,ne,ne,ne,sw,nw,sw,nw,sw,nw,sw,nw,nw,s,nw,s,nw,n,nw,nw,nw,nw,nw,n,n,s,nw,se,ne,nw,nw,nw,nw,nw,nw,se,sw,n,nw,nw,nw,n,nw,n,nw,sw,se,nw,ne,nw,nw,n,ne,ne,n,nw,ne,nw,n,n,nw,n,nw,nw,n,n,nw,n,s,n,nw,ne,nw,n,nw,n,sw,n,n,n,n,n,nw,n,sw,s,n,n,n,n,n,n,n,n,n,nw,n,se,n,n,s,ne,n,sw,se,n,ne,s,s,n,n,n,n,n,ne,n,n,ne,n,se,s,n,se,sw,ne,sw,s,s,n,ne,n,se,ne,ne,n,ne,ne,n,ne,n,n,sw,nw,ne,n,n,se,ne,ne,s,s,ne,n,s,sw,ne,ne,ne,n,ne,ne,n,ne,ne,n,se,ne,ne,se,ne,ne,ne,ne,nw,ne,sw,n,n,ne,ne,ne,n,se,ne,n,ne,ne,ne,sw,ne,ne,sw,nw,se,ne,ne,ne,ne,ne,n,ne,se,ne,sw,sw,ne,ne,ne,ne,ne,ne,ne,n,ne,ne,se,ne,n,n,se,ne,se,ne,ne,ne,ne,ne,ne,se,ne,ne,ne,ne,ne,s,sw,se,ne,se,ne,se,ne,ne,sw,ne,ne,se,ne,ne,se,ne,se,ne,se,ne,ne,ne,nw,ne,se,se,ne,se,se,se,sw,se,se,ne,se,se,se,ne,se,ne,se,ne,se,se,nw,ne,sw,se,se,se,sw,ne,se,ne,se,se,se,se,sw,se,nw,nw,se,se,se,se,s,nw,se,sw,n,ne,nw,ne,se,se,se,se,ne,s,s,se,se,se,ne,nw,ne,se,se,ne,se,se,se,se,se,se,se,s,se,se,se,se,se,se,s,se,se,se,se,se,se,se,se,se,nw,se,se,se,se,se,se,se,se,se,se,se,se,se,s,ne,se,s,se,se,ne,s,se,ne,se,sw,sw,se,se,s,se,se,se,s,sw,s,s,s,sw,n,s,ne,se,se,s,se,se,se,s,se,se,se,se,se,se,se,s,s,ne,se,se,se,se,nw,n,se,se,se,n,s,se,se,se,se,se,se,s,se,s,ne,s,nw,se,s,se,s,s,n,s,se,se,n,se,s,sw,ne,s,se,s,s,se,s,n,se,s,s,s,se,nw,s,sw,sw,s,s,nw,s,se,s,se,s,se,sw,se,se,s,se,s,se,s,s,s,se,s,nw,nw,sw,se,s,nw,s,s,sw,s,s,s,se,s,se,s,s,se,s,sw,s,n,sw,se,s,s,s,s,nw,se,s,s,s,se,s,s,ne,se,s,se,se,s,s,se,s,s,se,s,n,s,se,s,sw,s,s,s,s,s,s,ne,s,s,ne,s,s,s,s,s,s,s,s,se,sw,s,sw,s,s,sw,s,s,s,s,s,sw,s,ne,nw,s,sw,s,s,s,s,s,s,s,sw,sw,s,nw,s,s,s,se,se,s,sw,s,nw,s,sw,s,s,sw,se,s,se,s,nw,s,s,s,n,s,s,s,n,s,s,ne,nw,n,s,s,s,s,s,s,s,n,s,sw,sw,sw,s,s,s,s,s,s,sw,s,s,s,s,s,s,ne,se,sw,se,s,sw,sw,se,s,s,s,sw,n,sw,s,s,sw,s,s,s,s,sw,nw,s,ne,s,s,s,s,s,s,s,sw,s,sw,sw,s,s,sw,s,sw,s,s,s,s,sw,sw,s,s,s,s,s,sw,sw,s,s,sw,s,nw,s,s,sw,sw,s,nw,ne,sw,s,sw,s,sw,s,s,ne,s,ne,s,sw,s,sw,sw,s,s,s,sw,sw,sw,sw,sw,s,sw,ne,s,s,s,sw,s,n,sw,sw,sw,sw,sw,sw,sw,n,s,sw,nw,sw,sw,sw,n,se,sw,sw,s,sw,n,sw,s,s,s,s,s,s,s,sw,s,sw,sw,se,sw,sw,sw,n,sw,nw,sw,se,s,sw,nw,se,sw,sw,sw,n,sw,se,sw,sw,s,sw,sw,sw,s,s,n,sw,n,sw,sw,sw,sw,sw,s,sw,sw,sw,ne,s,n,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,s,ne,sw,ne,sw,sw,sw,ne,sw,sw,s,se,n,sw,sw,s,n,sw,sw,sw,sw,sw,sw,nw,sw,sw,sw,sw,sw,sw,n,sw,ne,se,sw,nw,s,sw,sw,sw,n,sw,sw,sw,sw,n,sw,sw,sw,ne,sw,se,ne,sw,se,ne,nw,sw,sw,sw,sw,nw,ne,sw,sw,nw,nw,sw,nw,sw,sw,nw,sw,s,n,se,sw,nw,sw,ne,sw,nw,sw,sw,sw,sw,sw,sw,se,se,nw,sw,ne,sw,nw,sw,sw,sw,sw,s,sw,sw,ne,sw,sw,sw,sw,sw,sw,sw,nw,sw,se,sw,sw,nw,n,s,sw,s,sw,sw,sw,ne,sw,nw,se,nw,nw,sw,nw,nw,sw,nw,nw,se,sw,sw,sw,sw,nw,nw,sw,nw,se,sw,sw,nw,ne,sw,sw,sw,se,sw,sw,sw,sw,ne,ne,nw,ne,nw,sw,sw,sw,n,s,nw,n,sw,nw,sw,nw,se,sw,nw,nw,nw,sw,nw,nw,sw,sw,nw,nw,sw,sw,sw,nw,sw,nw,nw,ne,sw,sw,nw,nw,sw,n,se,sw,nw,nw,sw,n,sw,s,sw,sw,nw,nw,sw,nw,se,n,sw,s,sw,sw,nw,nw,sw,nw,nw,sw,sw,sw,sw,nw,nw,sw,nw,nw,sw,nw,sw,sw,nw,se,nw,sw,sw,sw,sw,se,s,sw,nw,n,n,ne,nw,sw,nw,sw,s,sw,sw,sw,nw,s,nw,ne,s,sw,ne,nw,nw,nw,nw,sw,nw,nw,sw,nw,sw,sw,sw,sw,nw,nw,nw,sw,s,sw,nw,nw,sw,nw,sw,nw,nw,s,nw,nw,sw,sw,sw,sw,sw,sw,sw,sw,nw,nw,nw,nw,nw,nw,nw,nw,sw,sw,nw,sw,nw,nw,sw,nw,se,s,sw,nw,nw,nw,nw,nw,nw,nw,sw,nw,nw,sw,sw,s,nw,nw,nw,nw,nw,nw,nw,sw,sw,nw,nw,nw,n,ne,s,sw,s,se,nw,nw,s,nw,nw,nw,sw,s,ne,nw,nw,nw,nw,s,nw,nw,nw,ne,nw,sw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,ne,ne,sw,nw,ne,nw,nw,nw,nw,nw,sw,nw,nw,nw,nw,nw,nw,nw,s,nw,nw,nw,nw,nw,nw,se,sw,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,s,s,nw,nw,ne,nw,sw,nw,s,nw,nw,nw,nw,n,nw,sw,nw,nw,nw,nw,nw,nw,ne,nw,nw,nw,nw,nw,nw,nw,ne,nw,sw,nw,nw,nw,nw,nw,nw,nw,nw,n,n,nw,nw,nw,se,s,s,nw,nw,nw,nw,n,nw,nw,nw,sw,se,nw,nw,n,nw,n,nw,nw,se,nw,nw,nw,nw,nw,nw,nw,se,nw,nw,n,nw,nw,nw,se,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,ne,nw,nw,n,nw,nw,ne,nw,nw,n,nw,nw,n,n,nw,n,ne,nw,nw,nw,nw,nw,nw,s,nw,nw,nw,nw,ne,nw,nw,n,nw,ne,n,nw,nw,nw,nw,nw,nw,s,nw,nw,nw,nw,ne,sw,nw,nw,nw,n,nw,nw,nw,nw,n,nw,n,nw,nw,nw,nw,nw,nw,sw,nw,ne,nw,nw,sw,nw,nw,n,nw,nw,nw,s,s,s,nw,nw,nw,nw,n,nw,se,sw,s,nw,nw,nw,sw,n,n,nw,nw,ne,nw,n,se,n,nw,n,nw,nw,nw,n,nw,nw,nw,nw,n,nw,s,n,nw,n,nw,nw,nw,nw,nw,n,ne,nw,sw,nw,n,nw,nw,nw,n,s,nw,n,se,nw,ne,n,nw,nw,nw,n,nw,ne,nw,n,n,nw,n,s,nw,ne,ne,n,n,nw,se,nw,n,s,n,nw,n,n,n,n,n,nw,nw,s,nw,n,nw,nw,n,n,n,se,n,nw,nw,s,n,nw,n,nw,n,nw,nw,n,n,nw,n,n,se,sw,n,n,n,nw,nw,n,nw,nw,n,n,nw,n,se,n,n,n,n,nw,n,sw,n,nw,nw,nw,nw,ne,nw,n,n,n,n,n,n,nw,nw,se,nw,nw,n,n,n,nw,sw,ne,n,nw,n,n,nw,n,se,se,n,n,n,n,n,nw,n,n,n,s,sw,n,n,s,n,sw,n,se,n,nw,nw,se,nw,n,n,nw,sw,nw,n,n,n,ne,n,n,sw,nw,nw,se,nw,n,nw,sw,ne,sw,nw,n,n,nw,nw,nw,nw,nw,se,nw,n,nw,n,n,nw,sw,n,n,nw,nw,se,sw,n,n,n,n,n,n,nw,nw,nw,n,n,ne,se,n,nw,nw,ne,n,nw,n,n,n,sw,se,n,n,nw,nw,nw,n,n,n,n,se,n,ne,n,s,nw,n,n,n,nw,s,se,n,nw,nw,nw,n,n,nw,n,n,n,n,se,nw,n,n,nw,n,n,nw,n,n,n,n,n,n,n,sw,n,n,n,n,n,se,s,n,n,n,n,s,n,n,n,sw,n,n,nw,n,se,sw,n,sw,n,n,n,n,n,n,ne,n,n,nw,n,n,n,n,n,n,n,se,n,n,n,ne,n,n,n,n,n,n,s,n,nw,n,n,n,n,n,n,n,n,ne,n,n,n,n,sw,n,ne,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,sw,n,n,n,n,n,s,n,n,n,n,n,n,sw,se,n,n,n,n,n,n,s,s,n,nw,n,ne,n,n,n,n,ne,sw,n,n,sw,s,n,n,n,n,n,n,sw,n,nw,n,s,n,n,n,ne,sw,n,n,n,n,n,n,n,n,n,n,n,n,n,n,sw,n,sw,n,n,n,s,sw,n,n,n,s,n,ne,n,sw,nw,n,ne,nw,sw,n,n,n,n,n,n,se,nw,n,nw,sw,n,n,n,n,ne,s,n,ne,s,n,n,n,ne,n,n,nw,n,n,n,n,n,n,s,n,n,n,n,n,n,ne,n,n,n,ne,n,n,n,n,nw,nw,n,n,ne,ne,sw,ne,s,n,n,s,s,ne,nw,n,ne,ne,sw,ne,n,n,se,n,n,ne,s,ne,n,n,n,n,n,n,n,n,n,n,ne,n,nw,ne,n,n,se,ne,ne,ne,n,n,s,ne,n,ne,ne,n,s,ne,n,n,ne,n,sw,s,ne,se,n,n,n,nw,n,n,n,ne,ne,n,nw,n,ne,n,n,ne,n,nw,ne,nw,n,n,n,ne,ne,n,ne,sw,n,ne,n,nw,n,n,n,se,n,n,se,n,ne,n,n,ne,nw,ne,n,n,n,ne,n,nw,ne,n,n,sw,ne,n,s,ne,ne,ne,n,sw,n,n,ne,ne,n,ne,ne,n,se,ne,n,ne,n,n,n,nw,ne,n,n,n,ne,se,n,ne,ne,n,n,n,n,n,se,nw,n,nw,n,se,n,s,n,n,ne,ne,ne,ne,ne,ne,n,se,ne,n,s,s,ne,ne,ne,s,nw,n,n,s,s,n,ne,sw,ne,ne,n,n,ne,sw,ne,ne,sw,n,ne,ne,n,n,s,ne,ne,n,s,ne,ne,ne,n,ne,n,n,ne,ne,n,n,n,ne,n,ne,sw,ne,ne,ne,n,ne,sw,ne,s,se,sw,n,sw,ne,ne,ne,s,nw,nw,s,ne,n,sw,ne,se,ne,n,ne,n,s,se,ne,ne,ne,nw,ne,ne,n,ne,sw,ne,ne,ne,ne,sw,n,ne,se,se,sw,n,ne,n,n,ne,ne,ne,ne,ne,n,n,sw,n,se,n,n,n,n,ne,n,se,n,ne,ne,n,n,n,n,n,ne,ne,n,ne,s,s,ne,n,nw,n,se,ne,ne,n,n,ne,n,ne,s,ne,ne,n,n,n,ne,n,ne,n,n,ne,n,n,n,se,sw,n,ne,ne,n,ne,ne,ne,n,ne,ne,ne,se,ne,ne,ne,n,n,s,ne,nw,ne,n,n,ne,ne,ne,ne,ne,nw,ne,n,ne,n,n,ne,ne,ne,ne,ne,ne,ne,ne,ne,n,ne,ne,ne,ne,ne,s,n,ne,n,ne,ne,ne,ne,ne,ne,n,n,ne,ne,ne,ne,ne,ne,n,s,ne,n,ne,n,n,n,ne,ne,ne,ne,se,n,ne,se,ne,n,ne,n,ne,ne,ne,n,ne,ne,ne,ne,ne,ne,s,nw,se,ne,n,ne,ne,ne,n,ne,ne,ne,se,ne,se,n,ne,ne,ne,ne,sw,ne,n,ne,ne,s,ne,sw,n,n,nw,sw,ne,ne,n,ne,ne,ne,ne,ne,ne,nw,ne,se,ne,ne,ne,n,ne,ne,ne,n,s,ne,ne,ne,n,ne,ne,ne,s,ne,n,ne,n,sw,nw,ne,ne,sw,n,n,s,nw,n,se,ne,nw,ne,n,ne,ne,s,s,ne,sw,ne,n,s,n,ne,ne,ne,ne,n,n,ne,ne,ne,s,ne,ne,ne,ne,ne,ne,s,ne,ne,ne,ne,ne,s,ne,ne,ne,ne,ne,ne,ne,ne,n,ne,n,ne,ne,ne,ne,ne,nw,sw,sw,ne,n,n,ne,ne,nw,s,nw,ne,ne,ne,ne,sw,n,ne,n,ne,sw,s,se,ne,ne,ne,se,ne,ne,se,n,ne,ne,ne,n,n,ne,ne,n,ne,n,se,ne,nw,ne,s,ne,ne,ne,n,nw,n,se,ne,ne,ne,nw,n,sw,ne,ne,se,ne,ne,ne,nw,ne,ne,ne,s,n,ne,se,ne,ne,se,n,ne,ne,ne,ne,s,ne,ne,ne,sw,ne,ne,sw,ne,ne,ne,ne,se,n,ne,ne,se,ne,ne"
            //    .Split(',')
            //    .ToList();
            //Console.WriteLine("Day 11:");
            //Console.WriteLine($"Task1: {Day11.Task1(path)}");
            //Console.WriteLine($"Task2: {Day11.Task2(path)}");
            //Console.WriteLine();

            //var pipes = File
            //   .ReadAllLines("Day12.txt")
            //   .ToList();
            //Console.WriteLine("Day 12:");
            //Console.WriteLine($"Task1: {Day12.Task1(pipes)}");
            //Console.WriteLine($"Task2: {Day12.Task2(pipes)}");
            //Console.WriteLine();

            //var layers = File
            //   .ReadAllLines("Day13.txt")
            //   .ToList();
            //Console.WriteLine("Day 13:");
            //Console.WriteLine($"Task1: {Day13.Task1(layers)}");
            //Console.WriteLine($"Task2: {Day13.Task2(layers)}");
            //Console.WriteLine();

            //var key = "nbysizxe";
            //Console.WriteLine("Day 14:");
            //Console.WriteLine($"Task1: {Day14.Task1(key)}");
            //Console.WriteLine($"Task2: {Day14.Task2(key)}");
            //Console.WriteLine();

            //Console.WriteLine("Day 15:");
            //Console.WriteLine($"Task1: {Day15.Task1(512, 191)}");
            //Console.WriteLine($"Task2: {Day15.Task2(512, 191)}");
            //Console.WriteLine();

            //var danceMoves = File
            //   .ReadAllText("Day16.txt");
            //Console.WriteLine("Day 16:");
            //Console.WriteLine($"Task1: {Day16.Task1(16, danceMoves)}");
            //Console.WriteLine($"Task2: {Day16.Task2(16, danceMoves, 1_000_000_000)}");
            //Console.WriteLine();

            //Console.WriteLine("Day 17:");
            //Console.WriteLine($"Task1: {Day17.Task1(335)}");
            //Console.WriteLine($"Task2: {Day17.Task2(335)}");
            //Console.WriteLine();

            //var instructions2 = File
            //   .ReadAllLines("Day18.txt")
            //   .ToArray();
            //Console.WriteLine("Day 18:");
            //Console.WriteLine($"Task1: {Day18.Task1(instructions2)}");
            //Console.WriteLine($"Task2: {Day18.Task2(instructions2)}");
            //Console.WriteLine();

            //var routingDiagram = File
            //   .ReadAllLines("Day19.txt")
            //   .ToArray();
            //Console.WriteLine("Day 19:");
            //Console.WriteLine($"Task1: {Day19.Task1(routingDiagram)}");
            //Console.WriteLine($"Task2: {Day19.Task2(routingDiagram)}");
            //Console.WriteLine();

            //var particles = File
            //   .ReadAllLines("Day20.txt")
            //   .ToArray();
            //Console.WriteLine("Day 20:");
            //Console.WriteLine($"Task1: {Day20.Task1(particles)}");
            //Console.WriteLine($"Task2: {Day20.Task2(particles)}");
            //Console.WriteLine();

            //var rules = File
            //   .ReadAllLines("Day21.txt")
            //   .ToArray();
            //Console.WriteLine("Day 21:");
            //Console.WriteLine($"Task1: {Day21.Task1(rules, 5)}");
            //Console.WriteLine($"Task2: {Day21.Task1(rules, 18)}");
            //Console.WriteLine();

            var rows = File
               .ReadAllLines("Day22.txt")
               .ToArray();
            Console.WriteLine("Day 22:");
            Console.WriteLine($"Task1: {Day22.Task1(rows, 10_000)}");
            Console.WriteLine($"Task2: {Day22.Task2(rows, 10_000_000)}");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
