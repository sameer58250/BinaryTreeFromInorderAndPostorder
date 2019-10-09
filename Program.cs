using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeFrom_InAndPost_order
{
    public class TreeNode
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
   }
    class Program
    {
        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            TreeNode root = null;
            construct(ref root, inorder, postorder, 0, inorder.Length - 1);
            return root;
        }
        private static int findRoot(int[] inorder, int[] postorder, int startIdx, int endIdx)
        {
            int maxIdx = 0, temp;
            for (int i = startIdx; i <= endIdx; i++)
            {
                temp = Array.IndexOf(postorder, inorder[i]);
                if (maxIdx <= temp)
                    maxIdx = temp;
            }
            return postorder[maxIdx];
        }
        private static void construct(ref TreeNode root, int[] inorder, int[] postorder, int startIdx, int endIdx)
        {
            if (startIdx > endIdx || startIdx < 0 || endIdx > inorder.Length - 1)
            {
                root = null;
                return;
            }
            int r = findRoot(inorder, postorder, startIdx, endIdx);
            int idx = Array.IndexOf(inorder, r);
            root = new TreeNode(r);
            construct(ref root.left, inorder, postorder, startIdx, idx - 1);
            construct(ref root.right, inorder, postorder, idx + 1, endIdx);
        }
        static void Main(string[] args)
        {
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };
            TreeNode root = BuildTree(inorder, postorder);
            Console.WriteLine();
        }
    }
}
