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