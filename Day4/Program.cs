using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input4.txt")).Split(Environment.NewLine);
            List<string> candidates = FindPotentialPassports(input);


            Console.WriteLine("{0} passports are available", Part1(candidates));
            Console.WriteLine("{0} passports are valid", Part2(candidates));
        }

        private static int Part1(List<String> candidates)
        {
            int count = 0;

            foreach (string passport in candidates)
            {
                if (DoesPassportHaveAllFields(passport))
                {
                    count++;
                }
            }

            return count;
        }
       
        private static int Part2(List<String> candidates)
        {
            int count = 0;

            foreach (string passport in candidates)
            {
                if (IsDataValid(passport))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool DoesPassportHaveAllFields(string passport)
        {
            List<string> data = new List<string>() { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            foreach (string dataName in data)
            {
                if (!passport.Contains(dataName))
                {
                    return false;
                }
            }

            return true;
        }

        //You can continue to ignore the cid field, but each other field has strict rules about what values are valid for automatic validation:

        //byr(Birth Year) - four digits; at least 1920 and at most 2002.
        //iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        //hgt(Height) - a number followed by either cm or in:
        //If cm, the number must be at least 150 and at most 193.
        //If in, the number must be at least 59 and at most 76.
        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        //pid(Passport ID) - a nine-digit number, including leading zeroes.
        //cid(Country ID) - ignored, missing or not.
        //Your job is to count the passports where all required fields are both present and valid according to the above rules.
        private static List<string> FindPotentialPassports(string[] input)
        {
            List<string> passports = new List<string>();
            string passportData = string.Empty;
            foreach (string data in input)
            {
                if (data == string.Empty)
                {
                    passportData.Trim();
                    passports.Add(passportData);
                    passportData = String.Empty;
                    continue;
                }

                passportData = passportData + " " + data;
            }

            passports.Add(passportData);
            return passports.Where(x => x.Split(" ").Length > 7).Select(x => x).ToList();
        }
        private static bool IsDataValid(string password)
        {
            List<string> data = new List<string>() { @"byr:(200[0-2]|19[2-9][0-9])",
                //byr(Birth Year) - four digits; at least 1920 and at most 2002.
                @"iyr:(2020|201[0-9])",
                //iyr(Issue Year) - four digits; at least 2010 and at most 2020
                @"eyr:(2030|202[0-9])",
                //hgt(Height) - a number followed by either cm or in:   
                @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in",
                //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                 @"hcl:(#[0-9a-f]{6})",
                //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                 //TIL \b in regex
                    @"pid:(\d{9}\b)" };

            return data.All(reg => Regex.IsMatch(password, reg));
        }
    }

}
