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
        
        
            // 숙제 2. 테스트
            IStudy mySol = new ArrayToBinaryTree.Solution();
            mySol.DoAction();
        }
    }


    // 숙제 1. 막대 자르기



}
namespace ArrayToBinaryTree
{
    // 숙제 2. 이진 트리를 구현하고 depth, heigth 구하기
    public class Solution : IStudy
    {
        public void DoAction()
        {
            Console.Write("배열 입력하시오(쉼표로 구분) : ");
            int[] array = SortArray(GetArrayByString(Console.ReadLine()));
            
            //for test
            ShowArray(array);
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
        
    }


    public class MyTree
    {
        private MyTreeNode m_root;
        public MyTreeNode Root { get { return m_root; } }
        public MyTreeNode GetNodeByValue(int value)
        {
            throw new NotImplementedException();
        }

        public void AddNode(MyTreeNode parent, int value)
        {
            if(parent == null)
            {
                AddRootNodeByValue(value);
            }
            MyTreeNode childNode = new MyTreeNode(parent, value);
            int childIndex = value <= parent.m_value ? 0 : 1;
            parent.m_child[childIndex] = childNode;
        }
        private void AddRootNodeByValue(int value)
        {
            //[추구 구현] .Clear();
            m_root = new MyTreeNode(null, value);
        }
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
