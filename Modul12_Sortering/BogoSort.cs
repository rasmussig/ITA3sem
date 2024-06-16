using System;

namespace Sortering
{
    public static class BogoSort
    {
        private static Random random = new Random();

        public static void Sort(int[] array)
        {
            while (!IsSorted(array))
            {
                Shuffle(array);
            }
        }

        private static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = random.Next(array.Length);
                int temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }
    }
}
