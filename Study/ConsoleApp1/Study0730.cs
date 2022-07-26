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
        public void DoAction()
        {

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
        public void DoAction()
        {

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
