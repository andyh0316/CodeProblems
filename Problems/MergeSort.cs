namespace CodeProblems.Problems
{
    public class MergeSort
    {
        public static void Start()
        {
            int[] nums = new int[] { 5, 2, 4, 1 };
            SortArray(nums);
            ArrayHelper.PrintArray(nums);
        }

        public static int[] SortArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[0];
            int[] temp = new int[nums.Length];
            MergeSortRecursive(nums, 0, nums.Length - 1, temp);
            return nums;
        }

        private static void MergeSortRecursive(int[] nums, int start, int end, int[] temp)
        {
            if (start >= end)
            {
                return;
            }

            //printMergeSort(nums, start, end);

            MergeSortRecursive(nums, start, (start + end) / 2, temp);
            MergeSortRecursive(nums, (start + end) / 2 + 1, end, temp);

            Merge(nums, start, end, temp);
        }

        private static void Merge(int[] nums, int start, int end, int[] temp)
        {
            int middle = (start + end) / 2;
            int leftStart = start, rightStart = middle + 1;
            int index = leftStart;

            while (leftStart <= middle && rightStart <= end)
            {
                if (nums[leftStart] < nums[rightStart])
                {
                    temp[index++] = nums[leftStart++];
                }
                else
                {
                    temp[index++] = nums[rightStart++];
                }
            }

            while (leftStart <= middle)
            {
                temp[index++] = nums[leftStart++];
            }
            while (rightStart <= end)
            {
                temp[index++] = nums[rightStart++];
            }
            // when we finish placing merging result in the temp, we update the result array
            // update until index end
            for (int i = 0; i <= end; i++)
            {
                nums[i] = temp[i];
            }
        }
    }
}