using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Study0723 : IStudy
    {
        public void DoAction() 
        {
            IStudy mySol = new ArrayToBinaryTree.Solution();
            mySol.DoAction();
        }
    }
}

namespace MakeOne
{
    public class Solution : IStudy
    {
        public void DoAction()
        {
            Console.Write("[System : Input] 숫자는? : ");
            int inputNumber = int.Parse(Console.ReadLine());
            array = new int[inputNumber+1];
            MakeOne(inputNumber);

            Console.WriteLine("[System] 최소 연산 = " + array.Last());
            foreach(var e in array)
            {
                Console.Write(e + ", ");
            }
        }

        int[] array = new int[1000000];
        private void MakeOne(int length)
        {
            array[1] = 0;
            for(int i = 2; i <= length; i++)
            {
                Console.WriteLine($"[MakeOne] i = {i} / array[i] = {array[i]} / array[i-1] = {array[i - 1]}");
                array[i] = array[i - 1] + 1;
                if (i % 2 == 0)
                {
                    array[i] = GetMinValue(array[i], array[i / 2] + 1);
                }
                if (i % 3 == 0)
                {
                    array[i] = GetMinValue(array[i], array[i / 3] + 1);
                }
            }
        }
        private int GetMinValue(int a, int b)
        {
            return a > b ? b : a;
        }
    }

}
namespace ArrayToBinaryTree
{
    // 숙제 2. 이진 트리를 구현하고 depth, heigth 구하기
    
    public class Solution : IStudy
    {
        int[] myArray;
        MyTree myTree;
        public void DoAction()
        {   /*
            while (true)
            {
                
                try
                {
                    Console.Write("배열 입력하시오(쉼표로 구분) : ");
                    myArray = SortArray(GetArrayByString(Console.ReadLine()));
                    myTree = new MyTree();
                    //SetTree(myArray);
                    
                    ShowTree(myTree);
                }
                catch { }
                finally { Console.WriteLine(); }

            }
            */

            MyTree mTree = new MyTree();
            mTree.AddNode(5);
            mTree.AddNode(1);
            mTree.AddNode(7);
            mTree.AddNode(2);
            mTree.AddNode(6);
            mTree.AddNode(9);
            mTree.AddNode(3);


            //Console.WriteLine($"GetNodeByValue(7) = parent({mTree.GetNodeByValue(7).m_parent.m_value}) / Left({mTree.GetNodeByValue(7).m_child[0].m_value}) / Right({mTree.GetNodeByValue(7).m_child[1].m_value})");
            //Console.WriteLine($"Root 의 자식 = left : {mTree.Root.m_child[0].m_value}, Right : {mTree.Root.m_child[1].m_value}");
            //Console.WriteLine($"GetDepthByValue(6) = {mTree.GetDepthByValue(6)}");
            Console.WriteLine($"GetHeight() = {mTree.GetHeight()}");

        }
        private void SetTree(int[] source)
        {
            if(source.Length < 1) { return; }
            else if(source.Length == 1)
            {
                myTree.AddNode(source[0]);

                return;
            }
            else
            {
                int index = source.Length / 2;
                myTree.AddNode(source[index]);

                int[] tempRightArray = SliceArray(source, 0, index);
                int[] tempLeftArray = SliceArray(source, index + 1, source.Length);

                SetTree(tempRightArray);
                SetTree(tempLeftArray);
            }
        }
        private int[] SliceArray(int[] target, int start, int end)
        {
            List<int> tempList = new List<int>();
            for(int i = start; i< end; i++)
            {
                tempList.Add(target[i]);
            }
            return tempList.ToArray();
        }
        private int[] GetArrayByString(string source)
        {
            source.Replace(" ", "");
            
            //Exception : 가장 첫 번째 혹은 마지막이 ','일 때 에러 발생

            string[] tempSplit = source.Split(',');
            int[] tempArray = new int[tempSplit.Length];
            for(int i = 0; i < tempSplit.Length; i++)
            {
                tempArray[i] = int.Parse(tempSplit[i]);
            }

            return tempArray;
        }
        private int[] SortArray(int[] source)
        {
            List<int> tempList = new List<int>();
            for(int i = 0; i < source.Length; i++)
            {
                tempList.Add(source[i]);
            }
            tempList.Sort();

            return tempList.ToArray();
        }
        private void ShowArray(int[] source)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tempArray = [");
            for (int i = 0; i < source.Length; i++)
            {
                sb.Append(source[i]);
                if (i != source.Length - 1)
                {
                    sb.Append(',');
                }
            }
            sb.Append(']');
            Console.WriteLine(sb);
        }
        public void ShowTree(MyTree source)
        {
            if (source.Root == null) return;

            MyTreeNode node = source.Root;
            
            dictNode = new Dictionary<int, List<MyTreeNode>>();
            depth = 0;

            ShowNode(node, depth);


            for (int i = 0; i < dictNode.Count; i++)
            {
                foreach (var e in dictNode[i])
                {
                    Console.Write(e.m_value + ',');
                }
            }
        }
        Dictionary<int, List<MyTreeNode>> dictNode = new Dictionary<int, List<MyTreeNode>>();
        int depth = 0;

        private void ShowNode(MyTreeNode node, int depth)
        {
            if (node == null) return;

            //for test
            string left = "null";
            string right = "null";
            if (node.m_child[0] != null)
            {
                left = node.m_child[0].m_value.ToString();
            }
            else if(node.m_child[1] != null)
            {
                right = node.m_child[1].m_value.ToString();
            }
            Console.WriteLine($"[Test] node = {node.m_value} / depth = {depth} / node.child[0] = {left} / node.child[1] = {right}");

            if (dictNode[depth] == null)
            {
                dictNode[depth] = new List<MyTreeNode>();
            }
            dictNode[depth].Add(node);
            
            int nextDepth = depth + 1;

            for(int i = 0; i < 2; i++)
            {
                if(node.m_child[i] != null) ShowNode(node.m_child[i], nextDepth);
            }
        }
    }


    public class MyTree
    {
        private MyTreeNode m_root;
        public MyTreeNode Root { get { return m_root; } }
        public MyTreeNode GetNodeByValue(int value)
        {
            MyTreeNode tempNode = m_root;
            while (tempNode != null)
            {
                if(value == tempNode.m_value)
                {
                    return tempNode;
                }

                if (tempNode.m_child[0] == null && tempNode.m_child[1] == null)
                {
                    return null;
                }
                else if (value > tempNode.m_value)
                {
                    tempNode = tempNode.m_child[1];
                }
                else
                {
                    tempNode = tempNode.m_child[0];
                }
            }
            return null;
        }
        public int GetDepthByValue(int value)
        {
            int depth = 0;
            MyTreeNode node = GetNodeByValue(value);
            while(node != m_root)
            {
                depth++;
                node = node.m_parent;
            }
            return depth;
        }
        private int m_height = 0;
        public int GetHeight()
        {
            m_height = 0;
            GetNodeHeight(Root);
            return m_height;
        }
        private void GetNodeHeight(MyTreeNode node)
        {
            if (node.m_child[0] == null && node.m_child[1] == null)
            {
                int thisDepth = GetDepthByValue(node.m_value);
                m_height = m_height < thisDepth ? thisDepth : m_height;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (node.m_child[i] != null)
                    {
                        GetNodeHeight(node.m_child[i]);
                    }
                }
            }
        }

        public void AddNode(MyTreeNode parent, int value)
        {
            MyTreeNode childNode = new MyTreeNode(parent, value);
            if (parent == null)
            {
                AddRootNode(childNode);
                return;
            }
            else 
            {
                int childIndex = value <= parent.m_value ? 0 : 1;
                parent.m_child[childIndex] = childNode;
            }
        }
        public void AddNode(int value)
        {
            if (m_root == null)
            {
                AddRootNode(new MyTreeNode(null, value));
            }
            else
            {
                CompareAndAddNode(m_root, value);
            }
        }
        private void CompareAndAddNode(MyTreeNode node, int value)
        {
            int i = node.m_value > value ? 0 : 1;
            if (node.m_child[i] == null)
            {
                node.m_child[i] = new MyTreeNode(node, value);
            }
            else
            {

                CompareAndAddNode(node.m_child[i], value);
            }
        }
        private void AddRootNode(MyTreeNode root)
        {
            //[추구 구현] .Clear();
            m_root = root;
        }

        public MyTree(){}
    }
    public class MyTreeNode
    {
        internal MyTreeNode m_parent = null;
        internal MyTreeNode[] m_child = new MyTreeNode[2] { null, null };
        internal int m_value = -1;

        public MyTreeNode(MyTreeNode parent, int value)
        {
            m_parent = parent;
            m_value = value;
        }
    }
}
