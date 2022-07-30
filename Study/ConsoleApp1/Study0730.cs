using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application
{
    internal class Study0730 : IStudy
    {
        public void DoAction()
        {
            IStudy hw = new HomeWork0730_1.Homework();
            hw.DoAction();
        }
    }
}

namespace HomeWork0730_1
{
    /*
     * Draw a (single) Binary Tree T, such that: Each node of T stores a single character
     * 아래 두 가지를 모두 만족해야 함
     * An inorder traversal of T yield MAFXUEN
     * A preoreder traversal of T yiels EXAMFUN
     */
    public class Homework : IStudy
    {
        /*
        *         E              
        *      /     \
        *     X       N
        *    / \
        *   A   U
        *  / \
        * M   F
        */
        public void DoAction()
        {
            char[] charArray = { 'E', 'X', 'N', 'A', 'U', 'M', 'F' };
            int[] indexArray = {5,3,6,1,4,0,2};
            

            MTree myTree = new MTree();
            for(int i =0; i < charArray.Length; i++)
            {
                myTree.Append(indexArray[i], charArray[i]);
            }

            myTree.ShowTree(ShowType.PreOrder, true);
            myTree.ShowTree(ShowType.InOrder, true);
            myTree.ShowTree(ShowType.PostOrder, true);

        }
       

    }

}
namespace HomeWork0730_2
{
    /*
     * 1로 수렴하는 알고리즘 DP + 탑다운 + 메모리제이션으로 새로 해보기
     */
    public class Homework : IStudy
    {
        int[] array;

        public void DoAction()
        {
            while (true)
            {
                Console.Write("[System : Input] 값 입력 = ");
                int input = int.Parse(Console.ReadLine());
                if (input == 0) 
                {
                    Console.WriteLine("[System : Error] input 값이 정상적이지 않습니다. input = " + input);
                    continue; 
                }

                array = new int[input+1]; //초기화. 값이 가장 마지막이므로 +1을 함 (0은 사용하지 않을 예정?)

                Console.WriteLine("[System : Result] 최솟값 = " + Recursive(input));
                Console.WriteLine("[System : Appendix] 최소값 배열 = " + GetArrayString()); 
                Console.WriteLine("---------------------------------------------");
            }
        }
        private string GetArrayString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');

            for(int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
                if (i != array.Length - 1) sb.Append(", ");
            }

            sb.Append(']');
            return sb.ToString();
        }
        private int Recursive(int value)
        {
            if(value == 1)
            { 
                return 0; //0을 반환하여 아무것도 늘리지 않음. 더이상 순회하지 않고 종료함.
            }

            if (array[value] > 0)
            {
                //이 경우에는 이미 값이 존재하는 경우이므로 바로 자신의 값을 반환.
                return array[value];
            }

            array[value] = Recursive(value - 1) + 1; //일단 1을 뺀값에서 + 1(횟수) 함.
            if(value%3 == 0)
            {
                int tempCount = Recursive(value / 3) + 1; //3으로 나눈 값 중 +1(횟수) 함.
                if(array[value] > tempCount)
                {
                    //3으로 나눈 값과 다른 값들이 각각 최솟값을 갖는지 확인
                    //for test
                    Console.WriteLine($" ㄴ[Test - value % 3] 현재 등록된 array[{value}]의 최소값은 ({array[value]}) 였는데, %3+1 했을 때 이 값이 더 작으므로 ({tempCount})를 최소값으로 변경!");
                    array[value] = tempCount;
                } 
            }
            if(value%2 == 0)
            {
                int tempCount = Recursive(value / 2) + 1;
                if (array[value] > tempCount)
                {
                    //for test
                    Console.WriteLine($" ㄴ[Test - value % 2] 현재 등록된 array[{value}]의 최소값은 ({array[value]}) 였는데, %2+1 했을 때 이 값이 더 작으므로 ({tempCount})를 최소값으로 변경!");

                    //3으로 나눈 값과 다른 값들이 각각 최솟값을 갖는지 확인
                    array[value] = tempCount;
                }
            }

            return array[value];
        }


    }
}

namespace MyStudy0730
{
    //트리 다시 만들어보기
    public class Homework : IStudy
    { 

        public void DoAction()
        {
            int[] input = { 1000,100,10000,10,101,1001,10001,5,50 };

            MTree myTree = new MTree();
            
            foreach(int value in input)
            {
                myTree.Append(value);
            }

        }
    }
}


namespace BST
{
    public class KClass : IStudy
    {
        public void DoAction()
        {
            Console.WriteLine("[Test - Typeof] = " + typeof(int));
            KTree<string> ktree = new KTree<string>();
            ktree.TestCompare();
        }
    }
    public class KTree<T>
    {
        private KTreeNode<T> m_root = null;

        #region 구현 필요 영역 (구현 되면 밖으로 뺄 것)
        public void Append(T value)
        {
            KTreeNode<T> node = new KTreeNode<T>(this, null, value);
            if (m_root == null)
            {
                m_root = node;
                return;
            }

            /*
             * 목표값이 node 보다 크면 오른쪽, 작으면 왼쪽
             */
            KTreeNode<T> targetNode = m_root;            
            while (targetNode != null)
            {
            }
        }
        public void TestCompare()
        {
            switch (typeof(T))
            {
                case Type intType when intType == typeof(int):
                    {
                        Console.WriteLine("T는 인트값입니다.");
                        break;
                    }
                case Type stringType when stringType == typeof(string):
                    {
                        Console.WriteLine("T는 스트링입니다.");
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }

        }
        private bool CompareValue(T value, T target)
        {
            switch (typeof(T))
            {
                case Type intType when intType == typeof(int):
                    {
                        Console.WriteLine("T는 인트값입니다.");
                        break;
                    }
            }

            throw new NotImplementedException();
        }
        public KTreeNode<T> FindTreeNodeByValue(T value)
        {
            throw new NotImplementedException();
            
        }
        public void RemoveByValue(T value)
        {
            throw new NotImplementedException();

        }

        #endregion
    }
    public class KTreeNode<T>
    {
        private KTree<T> m_tree = null;
        private KTreeNode<T> m_parent = null;
        private KTreeNode<T>[] m_child = { null, null };
        private T m_value;

        public KTreeNode<T> Parent { get { return m_parent; } }
        public KTreeNode<T>[] Child { get { return m_child; } }
        public T Value { get { return m_value;} }
        public KTree<T> Tree { get { return m_tree; } }

        public KTreeNode(KTree<T> tree, KTreeNode<T> parent, T value)
        {
            m_tree = tree;
            m_parent = parent;
            m_value = value;
        }
        public void AddChild(KTreeNode<T> node)
        {
        }
        public void SetParent(KTreeNode<T> node)
        {
            m_parent = node;
        }
    }
}
