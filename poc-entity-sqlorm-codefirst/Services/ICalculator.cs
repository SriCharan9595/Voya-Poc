namespace poc_voya_entity.Services
{
    public interface ICalculator
    {
        string getName(string name);
        string getAdd(int num1, int num2);
        string getSub(int num1, int num2);
        string getProd(int num1, int num2);
        string getDiv(int num1, int num2);
    }
}
