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