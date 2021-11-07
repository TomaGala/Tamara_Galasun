using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Homework1
{
    [TestFixture]
    // FIRST TASK:
     public class Class1
     {
        [Test]
        public void Test_GetInteger_1()
        {
            IEnumerable<int> result = GetIntegerFromList(new List<object>() { 1, 2, "a", "b" });
            Assert.AreEqual(result, new List<object>() { 1, 2, });
        }

        [Test]
        public void Test_GetInteger_2()
        {
            IEnumerable<int> result = GetIntegerFromList(new List<object>() { "abc", 2, 0, "b", 7, "ber" });
            Assert.AreEqual(result, new List<object>() { 2, 0, 7 });
        }

        [Test]
        public void Test_GetInteger_3()
        {
            IEnumerable<int> result = GetIntegerFromList(new List<object>() { "abc", "b", "c", "ber" });
            Assert.AreEqual(result, new List<object>() {  });
        }

        public IEnumerable<int> GetIntegerFromList(List<object> input)
        {
            return input.OfType<int>();
        }
     }

    // SECOND TASK:
    public class Class2
    {
        [Test]
        public void Test_FirstNonRepeatingLetter_1()
        {
            string word = "abcabdd";
            char result = FirstNonRepeatingLetter(word);
            Assert.AreEqual(result, 'c');
        }

        [Test]
        public void Test_FirstNonRepeatingLetter_2()
        {
            string word = "AbcaBDC";
            char result = FirstNonRepeatingLetter(word);
            Assert.AreEqual(result, 'D');
        }

        [Test]
        public void Test_FirstNonRepeatingLetter_3()
        {
            string word = "AaBbcCdD";
            char result = FirstNonRepeatingLetter(word);
            Assert.AreEqual(result, ' ');
        }

        static char FirstNonRepeatingLetter(string input)
        {
            char[] input_lower = input.ToLower().ToCharArray();
            int letter_index = -1;
            for (int i = 0; i < input_lower.Length; i++)
            {
                for (int j = 0; j < input_lower.Length; j++)
                {
                    if (input_lower[i] == input_lower[j] && j != i)
                    {
                        letter_index = -1;
                        break;
                    }
                    else
                    {
                        letter_index = i;
                    }
                }
                if (letter_index != -1)
                {
                    break;
                }
            }
            if (letter_index == -1)
            {
                return ' ';
            }
            else
            {
                input.ToCharArray();
                return input[letter_index];
            }
        }
    }


        // THIRD TASK:
        public class Class3
    {
        [Test]
        public void Test_DigitalRoot_1()
        {
            int result = DigitalRoot(72);
            Assert.AreEqual(result, 9);
        }

        [Test]
        public void Test_DigitalRoot_2()
        {
            int result = DigitalRoot(957352);
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void Test_DigitalRoot_3()
        {
            int result = DigitalRoot(5);
            Assert.AreEqual(result, 5);
        }

        public static int DigitalRoot(int original_number)
        {
            int sum = 0;
            while (original_number != 0 || sum >= 10)
            {
                if (original_number == 0)
                {
                    original_number = sum;
                    sum = 0;
                }
                sum += original_number % 10;
                original_number /= 10;
            }
            return sum;
        }
    }

    // FOURTH TASK:
    public class Class4
    {
        [Test]
        public void Test_GetNumberOfPairs_1()
        {
            int result = GetNumberOfPairs(new int[] {2, 1, 4, 5, 0, 3, 4, 7, 6, 8}, 8);
            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Test_GetNumberOfPairs_2()
        {
            int result = GetNumberOfPairs(new int[] { 1, 4, 5, 3, 0, 2, 6 }, 5);
            Assert.AreEqual(result, 3);
        }

        [Test]
        public void Test_GetNumberOfPairs_3()
        {
            int result = GetNumberOfPairs(new int[] { 1, 4, 3, 0, 2 }, 9);
            Assert.AreEqual(result, 0);
        }

        public static int GetNumberOfPairs(int[] array, int target)
        {
            int NumberOfPairs = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)
                    {
                        NumberOfPairs++;
                    }
                }
            }
            return NumberOfPairs;
        }
    }


    // FIFTH TASK:
    public class Class5
    {
        [Test]
        public void Test_Sort_1()
        {
            string list = "Марія: Шевченко; Антон: Андрієнко; Володимир: Винниченко";
            string result = Sort(list);
            Assert.AreEqual(result, "( АНДРІЄНКО,  АНТОН ) ( ВИННИЧЕНКО,  ВОЛОДИМИР ) ( ШЕВЧЕНКО, МАРІЯ )");
        }

        [Test]
        public void Test_Sort_2()
        {
            string list = "Марія: Шевченко; Антон: Андрієнко; Володимир: Винниченко; Тарас: Шевченко; Аліна: Винниченко";
            string result = Sort(list);
            Assert.AreEqual(result, "( АНДРІЄНКО,  АНТОН ) ( ВИННИЧЕНКО,  АЛІНА ) ( ВИННИЧЕНКО,  ВОЛОДИМИР ) ( ШЕВЧЕНКО,  ТАРАС ) ( ШЕВЧЕНКО, МАРІЯ )");
        }

        public static string Sort(string list)
        {
        return "(" + string.Join(" ) (",
        list.ToUpper().Split(';').
        Select(name => name.Split(':')).
        Select(surname => string.Join(", ", surname.Reverse())).
        OrderBy(name => name)) + " )";
        }
    }


    // FIRST ADDITIONAL TASK:
    public class Additional1
    {
        [Test]
        public void Test_NextBigger_1()
        {
            int result = NextBigger(579);
            Assert.AreEqual(result, 597);
        }

        [Test]
        public void Test_NextBigger_2()
        {
            int result = NextBigger(222);
            Assert.AreEqual(result, -1);
        }

        public static int NextBigger(int input)
        {
            List<int> Int_List = new List<int>();
            List<int> Copy1 = new List<int>();
            List<int> Copy2 = new List<int>();

            while (input > 0)
            {
                Int_List.Add(input % 10);
                Copy1.Add(input % 10);
                Copy2.Add(input % 10);
                input = input / 10;
            }
            Copy1.Reverse();
            Copy2.Reverse();
            Int_List.Reverse();
            var pivot_index = -1;

            for (int i = Int_List.Count - 1; i > 0; i--)
            {
                if (Int_List[i] > Int_List[i - 1])
                {
                    pivot_index = i - 1;
                    break;
                }
            }
            if (pivot_index == -1) return pivot_index;

            int n = Int_List.Count, x = Int_List[pivot_index];

            Copy1.RemoveRange(pivot_index, n - pivot_index);
            List<int> left = Copy1;

            Copy2.RemoveRange(0, (left.Count + 1));
            List<int> right = Copy2;
            right.Sort();

            int Smallest_Max = 0;
            for (int i = 0; i < right.Count; i++)
            {
                if (right[i] > x)
                {
                    Smallest_Max = right[i];
                    right.RemoveAt(i);
                    break;
                }
            }

            left.Add(Smallest_Max);

            right.Add(x);
            right.Sort();

            List<int> Final_List = left.Concat(right).ToList();

            int result = int.Parse(string.Join(",", Final_List).Replace(",", ""));

            return result;
        }
    }


    // SECOND ADDITIONAL TASK:
    public class Additional2
    {
        [Test]
        public void Test_IPv4Address_1()
        {
            string result = IPv4Address(32);
            Assert.AreEqual(result, "0.0.0.32");
        }

        [Test]
        public void Test_IPv4Address_2()
        {
            string result = IPv4Address(2149583361);
            Assert.AreEqual(result, "128.32.10.1");
        }

        public static string IPv4Address(uint input)
        {
            return IPAddress.Parse(input.ToString()).ToString();
        }
        
    }
}


