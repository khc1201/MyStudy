using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        IStudy myStudy = new Application.Study0730();
        myStudy.DoAction();
    }
}
public interface IStudy
{
    public void DoAction();
}


public class MTree
{
    private MTreeNode m_root;
    private int m_count = 0;
    public int Count { get { return m_count; } }

    public void Append(int value)
    {
        if (m_root == null)
        {
            m_root = new MTreeNode(this, null, value);
            m_count++;
            return;
        }

        MTreeNode node = m_root;
        while (node != null)
        {
            if (node.m_value > value)
            {
                if (node.m_child_left == null)
                {
                    node.m_child_left = new MTreeNode(this, node, value);
                    m_count++;
                    break;
                }
                else
                {
                    node = node.m_child_left;
                }
            }
            else if (node.m_value < value)
            {
                if (node.m_child_right == null)
                {
                    node.m_child_right = new MTreeNode(this, node, value);
                    m_count++;
                    break;
                }
                else
                {
                    node = node.m_child_right;
                }
            }
            else
            {
                throw new Exception($"[System : Error!!!] value({value})의 값은 중복입니다. 유니크한 값이 보장되어야 합니다.");
            }
        }
    }
    public void Append(int value, char charValue)
    {
        if (m_root == null)
        {
            m_root = new MTreeNode(this, null, value, charValue);
            m_count++;
            return;
        }

        MTreeNode node = m_root;
        while (node != null)
        {
            if (node.m_value > value)
            {
                if (node.m_child_left == null)
                {
                    node.m_child_left = new MTreeNode(this, node, value, charValue);
                    m_count++;
                    break;
                }
                else
                {
                    node = node.m_child_left;
                }
            }
            else if (node.m_value < value)
            {
                if (node.m_child_right == null)
                {
                    node.m_child_right = new MTreeNode(this, node, value, charValue);
                    m_count++;
                    break;
                }
                else
                {
                    node = node.m_child_right;
                }
            }
            else
            {
                throw new Exception($"[System : Error!!!] value({value})의 값은 중복입니다. 유니크한 값이 보장되어야 합니다.");
            }
        }
    }

    public MTreeNode GetTreeNodeByValue(int value)
    {
        if (m_root == null)
        {
            throw new NullReferenceException($"[System : Error!!!] root 가 존재하지 않습니다.");
        }

        MTreeNode resultNode = CompareNodeValue(m_root, value);
        if (resultNode == null)
        {
            throw new NullReferenceException($"[System : Error!!!] findValue({value})가 tree 내에 존재하지 않습니다.");
        }
        return resultNode;
    }
    private MTreeNode CompareNodeValue(MTreeNode node, int findValue)
    {
        if (node.m_value == findValue)
        {
            return node;
        }
        else if (node.m_value > findValue)
        {
            if (node.m_child_left != null) return CompareNodeValue(node.m_child_left, findValue);
        }
        else if (node.m_value < findValue)
        {
            if (node.m_child_right != null) return CompareNodeValue(node.m_child_right, findValue);
        }
        return null;
    }

    StringBuilder m_sb = new StringBuilder();
    public enum ShowType {PreOrder, InOrder, PostOrder}
    public void ShowTree(ShowType type, bool isShowChar = false)
    {
        m_sb.Clear();
        m_sb.Append('[');
        string typeString = "";
        switch (type)
        {
            case ShowType.PreOrder:
                {
                    typeString = "PreOrder";

                    ShowNode_Recursive_PreOrder(m_root, isShowChar);
                    break;
                }
            case ShowType.InOrder:
                {
                    typeString = "InOrder";
                    ShowNode_Recursive_InOrder(m_root, isShowChar);

                    break;
                }
            case ShowType.PostOrder:
                {
                    typeString = "PostOrder";
                    ShowNode_Recursive_PostOrder(m_root, isShowChar);

                    break;
                }
        }
        //PreOrder
        
        
        m_sb.Append(']');
        Console.WriteLine($"[Test] ShowTree() - Type({typeString}) : " + m_sb.ToString());
    }
    public void Clear()
    {
        m_root = null;
        m_count = 0;
    }
    private void ShowNode_Recursive_PreOrder(MTreeNode node, bool isShowChar)
    {

        if (isShowChar)
        {
            m_sb.Append((char)node.m_charValue);
        }
        else
        {
            m_sb.Append(node.m_value + ", ");
        }

        if (node.m_child_left != null)
        {
            ShowNode_Recursive_PreOrder(node.m_child_left, isShowChar);
        }
        if (node.m_child_right != null)
        {
            ShowNode_Recursive_PreOrder(node.m_child_right, isShowChar);
        }
    }
    private void ShowNode_Recursive_InOrder(MTreeNode node, bool isShowChar)
    {

        if (node.m_child_left != null)
        {
            ShowNode_Recursive_InOrder(node.m_child_left, isShowChar);
        }
        if (isShowChar)
        {
            m_sb.Append((char)node.m_charValue);
        }
        else
        {
            m_sb.Append(node.m_value + ", ");
        }
        if (node.m_child_right != null)
        {
            ShowNode_Recursive_InOrder(node.m_child_right, isShowChar);
        }
    }
    private void ShowNode_Recursive_PostOrder(MTreeNode node, bool isShowChar)
    {
        if (node.m_child_left != null)
        {
            ShowNode_Recursive_PostOrder(node.m_child_left, isShowChar);
        }
        if (node.m_child_right != null)
        {
            ShowNode_Recursive_PostOrder(node.m_child_right, isShowChar);
        }
        if (isShowChar)
        {
            m_sb.Append((char)node.m_charValue);
        }
        else
        {
            m_sb.Append(node.m_value + ", ");
        }
    }

}
public class MTreeNode
{
    public MTree m_tree;
    public MTreeNode m_parent;
    public MTreeNode m_child_left;
    public MTreeNode m_child_right;

    public int m_value;
    public int m_charValue;

    public MTreeNode(MTree tree, MTreeNode parent, int value, char charValue = ' ')
    {
        m_tree = tree;
        m_parent = parent;
        m_value = value;
        m_charValue = charValue;
    }
}