using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                // Declaring maximum value based on the length of the sequence
                int max = nums.Length;
                // Creating a list to store the numbers that are missing
                List<int> absent = new List<int>();
                // Initializing a boolean array to track presence of numbers in the sequence
                bool[] found = new bool[max + 1];
                // Iterating through each number in the input sequence
                foreach (int num in nums)
                {
                    if (num <= max)  // Checking if number is within the expected range

                        found[num] = true;  // Marking the number as found

                }
                // Looping from 1 to max to identify which numbers were not found
                for (int i = 1; i <= max; i++)
                {
                    if (!found[i])  // If a number is not found
                        absent.Add(i);  // Add it to the list of missing numbers
                }
                return absent;         // Return the absent

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                // Creating a new array to hold sorted elements
                int[] reordered = new int[nums.Length];
                // Initializing pointers for placing even at the start and odd at the end
                int left = 0, right = nums.Length - 1;
                // Looping through each element in the input array
                foreach (int item in nums)
                {
                    if (item % 2 == 0)  // Check if the element is even
                        reordered[left++] = item;   // Placing even elements at the start
                    else
                        reordered[right--] = item;  // Placing odd elements at the end

                }
                return reordered;          // Returning the sorted array

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                // Creating a dictionary to map each number's value to its index
                Dictionary<int, int> indices = new Dictionary<int, int>();
                // Iterating through the array with an index
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculating needed complement to reach targetSum
                    if (indices.ContainsKey(complement)) // Checking if the complement is already in the dictionary
                    {
                        // Returning the indices of the current element and its complement
                        return new int[] { indices[complement], i };
                    }
                    // Storing the index of each element in the dictionary
                    indices[nums[i]] = i;
                }
                // Returning an empty array if no pair is found
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                // Checking if the array has at least three elements to form a product
                if (nums.Length < 3)
                    throw new ArgumentException("At least three numbers are needed.");
                // Sorting the numbers in the array
                Array.Sort(nums);
                // Get the number of elements in the array
                int total = nums.Length;
                // Calculating the maximum product by comparing two possible products:
                // Product of the three largest numbers at the end of the sorted array
                // Product of the two smallest and the largest number (this accounts for negative numbers)
                return Math.Max(nums[0] * nums[1] * nums[total - 1], nums[total - 1] * nums[total - 2] * nums[total - 3]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                // Checking if the input number is non-negative, as binary representation for negatives isn't handled here
                if (decimalNumber < 0)
                    throw new ArgumentException("Input must be a non-negative integer.");
                // Converting the decimal number to its binary string representation
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                // Begin a binary search to identify the point of minimum value
                int start = 0, end = nums.Length - 1;
                // Continue searching while the start is less than the end
                while (start < end)
                {
                    int mid = (start + end) / 2;  // Calculating the midpoint for the current segment
                    if (nums[mid] > nums[end])
                        start = mid + 1;  // The minimum is in the right half
                    else
                        end = mid; // The minimum is in the left half or at mid
                }
                // The smallest element is located at the 'start' index
                return nums[start];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                // Negative numbers cannot be palindromes
                if (x < 0) return false;
                // Variable to hold the reversed number
                int reverse = 0, original = x;
                while (x > 0)
                {
                    reverse = reverse * 10 + x % 10; // Append the last digit of 'temp' to 'reverse'

                    x /= 10; // Remove the last digit from 'temp'
                }
                return original == reverse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                // Check for valid Fibonacci position (non-negative)
                if (n < 0)
                    throw new ArgumentException("Position must be non-negative.");
                int a = 0, b = 1; // Initialize the first two Fibonacci numbers
               // Calculate Fibonacci number using an iterative approach
                for (int i = 0; i < n; i++) 
                {
                    int temp = a; // Temporary variable to hold the previous Fibonacci number

                    a = b; // Move to the next number

                    b = temp + b; // Update 'b' to the next Fibonacci number
                }
                return a;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
