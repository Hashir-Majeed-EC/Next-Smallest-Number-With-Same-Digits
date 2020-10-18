using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NextSmaller(631249));
        }
        public static long NextSmaller(long n)
        {
            string x = n.ToString();
            int[] nums = new int[x.Length];
            bool found = false;
            int firstIndex = x.Length - 1;
            int secondIndex = -1;
            int maximum;

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToInt32(Convert.ToString(x[i]));
            }
            try
            {
                while (!found)
                {
                    if (nums[firstIndex - 1] > nums[firstIndex])
                    {
                        found = true;
                    }
                    firstIndex--;
                }
            }
            catch
            {
                return -1;
            }

            maximum = nums[firstIndex + 1];
            for (int i = firstIndex + 1; i < nums.Length; i++)
            {
                if (nums[i] >= maximum && nums[i] < nums[firstIndex])
                {
                    secondIndex = i;
                    maximum = nums[i];
                }
            }

            if (secondIndex != -1)
            {
                swap(nums, firstIndex, secondIndex);
            }
            else
            {
                secondIndex = nums.Length - 1;
                swap(nums, firstIndex, secondIndex);
            }

            for (int j = firstIndex + 1; j < nums.Length - 1; j++)
            { 
                for (int i = firstIndex +  1; i < nums.Length - 1; i++)
                {
                    if (nums[i] < nums[i + 1])
                    {
                        swap(nums, i, i + 1);
                    }
                }             
            }

            string result = string.Join("", nums);
            long answer = Convert.ToInt64(result);
            if (answer > n || result.Length == 1 || nums[0] == 0)
            {
                answer = -1;
            }

            return answer;

        }
        public static void swap(int[] nums, int firstIndex, int secondIndex)
        {
            int temp = nums[firstIndex];
            nums[firstIndex] = nums[secondIndex];
            nums[secondIndex] = temp;
        }
    }
}
