using UnityEngine;

delegate int Operation(int x, int y);
public class DelegateTest : MonoBehaviour
{
    private Operation operation;
    private int _result;
    int Add(int x, int y) => x + y;
    int Multiply(int x, int y) => x * y;
    
    

    private void Start()
    {
        operation += Add;
        operation += Multiply;
        _result += operation(4, 5);
        print(_result);
        print(operation.GetInvocationList().Length);
    }
}
