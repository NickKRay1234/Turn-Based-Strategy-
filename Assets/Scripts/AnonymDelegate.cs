using UnityEngine;

// Продемонтстрировать применение анонимного метода.
public class AnonymDelegate : MonoBehaviour
{
    // Объявить тип делегата.
    delegate int CountIt(int end);
    
    private int _test;
    // Далее следует код для подсчета чисел, передаваемый делегату в качестве анонимного метода.
    private CountIt count = delegate(int end)
    {
        int _sum = 0;
        // Этот кодовый блок передается делегату
        for (int i = 0; i <= end; i++)
        {
            _sum += i;
        }
        return _sum;
    };

    private void Start()
    {
        _test = count(3);
        print("Sum: " + _test);
        _test = count(5);
        print("Sum: " + _test);
    }

    public void Text() => print("Text");
}
