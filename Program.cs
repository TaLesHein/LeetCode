using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        SearchInsertLog([1, 3, 5, 6], 2);
        Console.WriteLine("Hello, World!");
    }

    public static int[] TwoSum(int[] nums, int target)
    {
       Dictionary<int, int> match = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var value = target - nums[i];

            if (match.ContainsKey(value))
            {
                return [match[value], i];
            }

            match[nums[i]] = i;
        }

        throw new ArgumentException("Nenhuma solução encontrada");
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Garante que nums1 é o menor (otimiza a busca binária)
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int metadeEsquerda = (m + n + 1) / 2;

        int low = 0, high = m;

        while (low <= high)
        {
            int i = (low + high) / 2;       // corte em nums1
            int j = metadeEsquerda - i;      // corte correspondente em nums2

            // Trata bordas (quando o corte é no início ou fim do array)
            int esquerda1 = (i == 0) ? int.MinValue : nums1[i - 1];
            int direita1 = (i == m) ? int.MaxValue : nums1[i];
            int esquerda2 = (j == 0) ? int.MinValue : nums2[j - 1];
            int direita2 = (j == n) ? int.MaxValue : nums2[j];

            if (esquerda1 <= direita2 && esquerda2 <= direita1)
            {
                // Corte perfeito encontrado!
                if ((m + n) % 2 == 1)
                {
                    return Math.Max(esquerda1, esquerda2);
                }
                else
                {
                    return (Math.Max(esquerda1, esquerda2) + Math.Min(direita1, direita2)) / 2.0;
                }
            }
            else if (esquerda1 > direita2)
            {
                high = i - 1; // i grande demais, diminui
            }
            else
            {
                low = i + 1; // i pequeno demais, aumenta
            }
        }

        throw new ArgumentException("Arrays de entrada inválidos");
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        Array.Sort(strs);
        string s = "";
        int i = 0;
        int length = strs.Length;

        while (i < strs[0].Length)
        {
            if (strs[0][i] == strs[length - 1][i])
                s += strs[0][i];
            else 
                break;

            i++;
        }

        Console.WriteLine(s);

        return s;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        var quantity = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            var x = nums[i];
            var y = nums[i - 1];

            if (x != y)
            {
                nums[quantity] = nums[i];
                quantity++;
            }
        }

        return quantity;
    }

    public static int RemoveElement(int[] nums, int val)
    {
        var quantity = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != val)
            {
                nums[quantity] = nums[i];

                quantity++;
            } 
        }

        return quantity;
    }

    // O(n)
    public static int SearchInsert(int[] nums, int target)
    {
        var index = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > target) index++;
        }

        return index;
    }

    // O(log n)
    public static int SearchInsertLog(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        if (nums[left] > target) return left;
        else if (nums[right] < target) return right + 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target) return mid;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return left;
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var finalList = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            var j = i + 1;
            var k = nums.Length - 1;

            while (j < k)
            {
                var sumResult = nums[i] + nums[j] + nums[k];

                if (sumResult > 0) k--;
                else if (sumResult < 0) j++;
                else
                {
                    var combination = new List<int>() { nums[i], nums[j], nums[k] };
                    finalList.Add(combination);
                    
                    j++;
                }
            }
        }

        return finalList;
    }
}